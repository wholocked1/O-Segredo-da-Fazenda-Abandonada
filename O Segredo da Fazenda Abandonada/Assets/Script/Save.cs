using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    private string saveLocal;
    private ControledeInventario controledeInventario;

    // Start is called before the first frame update
    void Start()
    {
        controledeInventario = ControledeInventario.Instance;
        saveLocal = Path.Combine(Application.persistentDataPath, "saveData.json");
        Debug.Log("Save file path: " + saveLocal);

        LoadGame();
    }

    public void SaveGame()
    {
        DadoSalvo dadoSalvo = new DadoSalvo
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            inventorySaveData = controledeInventario.GetitemsInventory()
        };
        File.WriteAllText(saveLocal, JsonUtility.ToJson(dadoSalvo));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocal))
        {
            string json = File.ReadAllText(saveLocal);
            DadoSalvo dadoSalvo = JsonUtility.FromJson<DadoSalvo>(json);
            GameObject.FindGameObjectWithTag("Player").transform.position = dadoSalvo.playerPosition;
            controledeInventario.SetItemsInventory(dadoSalvo.inventorySaveData);
        }
        else
        {
            SaveGame();
        }
    }
}
