using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Save : MonoBehaviour
{
    private string saveLocal;
    private ControledeInventario controledeInventario;
    private Item[] items;

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
        items = FindObjectsOfType<Item>();
        Debug.Log("Save file path: " + saveLocal);
    }

    public void SaveGame()
    {
        DadoSalvo dadoSalvo = new DadoSalvo
        {
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
            DadoSalvo dadoSalvo = JsonUtility.FromJson<DadoSalvo>(json);
            GameObject.FindGameObjectWithTag("Player").transform.position = dadoSalvo.playerPosition;
            controledeInventario.SetItemsInventory(dadoSalvo.inventorySaveData);
            LoadStatusItems(dadoSalvo.itemSaveData);
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
                item.loadItem(itemSaveData);
            }
            else
            {
                item.SetColetado(false);
                Debug.LogWarning($"Item {item.id} não encontrado no save. Setando como não coletado.");
            }
        }
    }
}
