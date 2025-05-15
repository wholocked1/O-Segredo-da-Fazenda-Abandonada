using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private string saveLocal;
    private ControledeInventario controledeInventario;
    private Item[] items;
    private Chest[] baus;
    private DadoSalvo dadoSalvoCarregado;

    void Awake()
    {
        InicializarComponentes();
    }

    void Start()
    {
        LoadGame();
    }

    // Inicializa as referências importantes
    private void InicializarComponentes()
    {
        controledeInventario = ControledeInventario.Instance;
        saveLocal = Path.Combine(Application.persistentDataPath, "saveData.json");

        // Busca os itens e baús da cena atual
        items = FindObjectsByType<Item>(FindObjectsSortMode.None);
        baus = FindObjectsOfType<Chest>();

        Debug.Log("Itens encontrados: " + items.Length);
        Debug.Log("Baús encontrados: " + baus.Length);
        Debug.Log("Caminho do arquivo de save: " + saveLocal);
    }

    // Salva o estado do jogo
    public void SaveGame()
    {
        DadoSalvo dadoSalvo = new DadoSalvo
        {
            ActiveScene = SceneManager.GetActiveScene().name,
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            inventorySaveData = controledeInventario.GetitemsInventory(),
            itemSaveData = PegaStatusItems(),
            saveBau = PegaStatusBaus()
        };

        string json = JsonUtility.ToJson(dadoSalvo, true);
        File.WriteAllText(saveLocal, json);

        Debug.Log("Jogo salvo com sucesso!");
    }

    // Obtém o estado dos baús (aberto ou fechado)
    private List<SaveBau> PegaStatusBaus()
    {
        List<SaveBau> chestStates = new List<SaveBau>();
        foreach (Chest bau in baus)
        {
            SaveBau saveBau = new SaveBau
            {
                chestID = bau.chestID,
                estaAberto = bau.estaAberto
            };
            chestStates.Add(saveBau);
        }
        return chestStates;
    }

    // Obtém o estado dos itens (se foram coletados)
    private List<ItemSaveData> PegaStatusItems()
    {
        List<ItemSaveData> itemSaveData = new List<ItemSaveData>();
        foreach (Item item in items)
        {
            ItemSaveData itemData = new ItemSaveData
            {
                ID = item.id,
                foiColetado = item.foiColetado
            };
            itemSaveData.Add(itemData);
        }
        return itemSaveData;
    }

    // Carrega o jogo, com verificação se o arquivo existe
    public void LoadGame()
    {
        if (File.Exists(saveLocal))
        {
            string json = File.ReadAllText(saveLocal);
            dadoSalvoCarregado = JsonUtility.FromJson<DadoSalvo>(json);

            // Registra o callback para quando a cena terminar de carregar
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Carrega a cena salva
            SceneManager.LoadScene(dadoSalvoCarregado.ActiveScene);

            Debug.Log("Carregando cena: " + dadoSalvoCarregado.ActiveScene);
        }
        else
        {
            Debug.LogWarning("Arquivo de save não encontrado. Criando novo save padrão.");

            // Limpa inventário e itens coletados
            controledeInventario.SetItemsInventory(new List<InventorySaveData>());

            foreach (Item item in items)
            {
                item.SetColetado(false);
            }

            // Salva o estado inicial
            SaveGame();
        }
    }

    // Callback disparado quando a cena termina de carregar
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Remove o callback para não ser chamado mais de uma vez
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Atualiza as referências para os itens e baús da nova cena
        items = FindObjectsByType<Item>(FindObjectsSortMode.None);
        baus = FindObjectsOfType<Chest>();

        // Atualiza o singleton do inventário (caso tenha sido destruído/criado novo)
        controledeInventario = ControledeInventario.Instance;

        if (dadoSalvoCarregado != null)
        {
            // Posiciona o jogador na posição salva
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = dadoSalvoCarregado.playerPosition;
                Debug.Log("Posicionando jogador na posição salva: " + dadoSalvoCarregado.playerPosition);
            }
            else
            {
                Debug.LogWarning("Player não encontrado após carregar a cena.");
            }

            // Atualiza o inventário na UI
            if (controledeInventario != null)
            {
                controledeInventario.SetItemsInventory(dadoSalvoCarregado.inventorySaveData);
                Debug.Log("Inventário carregado.");
            }
            else
            {
                Debug.LogWarning("Controle de Inventário não encontrado após carregar a cena.");
            }

            // Atualiza o estado dos itens no mundo (se estão ativos/desativados)
            LoadStatusItems(dadoSalvoCarregado.itemSaveData);

            // Atualiza o estado dos baús (abertos ou fechados)
            LoadChestState(dadoSalvoCarregado.saveBau);
        }
        else
        {
            Debug.LogError("dadoSalvoCarregado está nulo no OnSceneLoaded!");
        }
    }

    // Atualiza itens no mundo conforme estado salvo (ativar/desativar)
    private void LoadStatusItems(List<ItemSaveData> itemSaveDatas)
    {
        foreach (Item item in items)
        {
            ItemSaveData itemSaveData = itemSaveDatas.FirstOrDefault(i => i.ID == item.id);
            if (itemSaveData != null)
            {
                item.SetColetado(itemSaveData.foiColetado);
                item.loadItem(itemSaveData);
                Debug.Log($"Item ID: {item.id} carregado com foiColetado = {item.foiColetado}");
            }
            else
            {
                // Se não encontrar dados do item, marca como não coletado e ativo
                item.SetColetado(false);
                item.gameObject.SetActive(true);
                Debug.LogWarning($"Item ID: {item.id} não encontrado nos dados de save. Setando para não coletado.");
            }
        }
    }

    // Atualiza os baús conforme o estado salvo (aberto/fechado)
    private void LoadChestState(List<SaveBau> chestState)
    {
        foreach (Chest chest in baus)
        {
            SaveBau chestSaveData = chestState.FirstOrDefault(c => c.chestID == chest.chestID);
            if (chestSaveData != null)
            {
                chest.SetAberto(chestSaveData.estaAberto);
                Debug.Log($"Baú ID: {chest.chestID} carregado com estado aberto = {chest.estaAberto}");
            }
            else
            {
                // Se não encontrar dados do baú, seta como fechado
                chest.SetAberto(false);
                Debug.LogWarning($"Baú ID: {chest.chestID} não encontrado nos dados de save. Setando como fechado.");
            }
        }
    }
}
