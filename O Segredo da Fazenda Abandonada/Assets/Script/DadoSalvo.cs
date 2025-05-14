using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadoSalvo
{
    public string ActiveScene;  
    public Vector3 playerPosition;
    public List<InventorySaveData> inventorySaveData;
    public List<ItemSaveData> itemSaveData;
    public List<SaveBau> saveBau;
}

[System.Serializable]
public class ItemSaveData
{
    public string ID;
    public bool foiColetado;

}

[System.Serializable]
public class SaveBau{
    public string chestID;
    public bool estaAberto;
}