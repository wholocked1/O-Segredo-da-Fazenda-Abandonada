using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadoSalvo
{
    public Vector3 playerPosition;
    public List<InventorySaveData> inventorySaveData;
    public List<ItemSaveData> itemSaveData;
}

[System.Serializable]
public class ItemSaveData
{
    public string ID;
    public bool foiColetado;
}