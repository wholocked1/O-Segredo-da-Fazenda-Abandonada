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
    private DadoSalvo dadoSalvoCarregado;

    void Awake()
    {
        InicializarComponentes();
    }

    void Start()
    {
        LoadGame();
    }

    private void InicializarComponentes()
    {
        controledeInventario = ControledeInventario.Instance;
        saveLocal = Path.Combine(Application.persistentDataPath, "saveData.json");
        items = FindObjectsByType<Item>(FindObjectsSortMode.None); // Updated to use FindObjectsByType
        Debug.Log("Itens encontrados: " + items.Length);
        Debug.Log("Save file path: " + saveLocal);
    }

    public void SaveGame()
    {
        DadoSalvo dadoSalvo = new DadoSalvo
        {
            ActiveScene = SceneManager.GetActiveScene().name,
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            inventorySaveData = controledeInventario.GetitemsInventory(),
            itemSaveData = PegaStatusItems()
        };
        File.WriteAllText(saveLocal, JsonUtility.ToJson(dadoSalvo));
    }

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

    public void LoadGame()
    {
        if (File.Exists(saveLocal))
        {
            string json = File.ReadAllText(saveLocal);
            dadoSalvoCarregado = JsonUtility.FromJson<DadoSalvo>(json);
            SceneManager.LoadScene(dadoSalvoCarregado.ActiveScene);
            GameObject.FindGameObjectWithTag("Player").transform.position = dadoSalvoCarregado.playerPosition;
            controledeInventario.SetItemsInventory(dadoSalvoCarregado.inventorySaveData);
            // Aguarda o carregamento da nova cena
            SceneManager.sceneLoaded += OnSceneLoaded;
            LoadStatusItems(dadoSalvoCarregado.itemSaveData);
        }
        else
        {
            controledeInventario.SetItemsInventory(new List<InventorySaveData>());
            foreach (Item item in items)
            {
                item.SetColetado(false);
            }

            SaveGame();
        }
    }

    private void LoadStatusItems(List<ItemSaveData> itemSaveDatas)
    {
        foreach (Item item in items)
        {
            ItemSaveData itemSaveData = itemSaveDatas.FirstOrDefault(i => i.ID == item.id);
            if (itemSaveData != null)
            {
                item.SetColetado(itemSaveData.foiColetado);
                Debug.Log("Item ID: " + item.id + " foiColetado: " + item.foiColetado);
                item.loadItem(itemSaveData);
            }
            else
            {
                Debug.Log("Não achou ninguem");
                item.SetColetado(false);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Recarrega componentes após a cena estar carregada
        items = FindObjectsByType<Item>(FindObjectsSortMode.None);
        controledeInventario = ControledeInventario.Instance;

        if (dadoSalvoCarregado != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = dadoSalvoCarregado.playerPosition;
            }
            else
            {
                Debug.LogWarning("Player não encontrado após carregar a cena.");
            }

            if (controledeInventario != null)
            {
                controledeInventario.SetItemsInventory(dadoSalvoCarregado.inventorySaveData);
            }
            else
            {
                Debug.LogWarning("Controle de Inventário não foi encontrado após carregar a cena.");
            }

            LoadStatusItems(dadoSalvoCarregado.itemSaveData);
        }
        else
        {
            Debug.LogError("dadoSalvoCarregado está nulo!");
        }
    }

}
