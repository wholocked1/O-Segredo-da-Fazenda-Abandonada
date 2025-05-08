using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Save : MonoBehaviour
{
    private string saveLocal;
    private ControledeInventario controledeInventario;
    private Item[] items;

    // Start is called before the first frame update
    void Start()
    {
        InicializarComponentes();
        LoadGame();
    }

    private void InicializarComponentes()
    {
        controledeInventario = ControledeInventario.Instance;
        saveLocal = Path.Combine(Application.persistentDataPath, "saveData.json");
        items = FindObjectsByType<Item>(FindObjectsSortMode.None); // Updated to use FindObjectsByType
        //Debug.Log("Save file path: " + saveLocal);
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
            SaveGame();
        }
    }

    private void LoadStatusItems(List<ItemSaveData> itemSaveDatas)
    {
        foreach (Item item in items)
        {
            ItemSaveData itemSaveData = itemSaveDatas.FirstOrDefault(i => i.ID == item.id);
            if (item != null)
            {
                item.SetColetado(item.foiColetado);
            }
        }
    }
}
