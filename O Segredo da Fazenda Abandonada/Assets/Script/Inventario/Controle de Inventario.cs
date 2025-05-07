using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeInventario : MonoBehaviour
{
    private DicionarioItems dicionarioItems;

    public GameObject inventario;
    public GameObject slotPrefab;
    public int slotsNumber;
    public GameObject[] items;
    public static ControledeInventario Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dicionarioItems = DicionarioItems.Instance;
        //for (int i = 0; i < slotsNumber; i++)
        //{
        //    Slot slot = Instantiate(slotPrefab, inventario.transform).GetComponent<Slot>();
        //    if(i < items.Length)
        //    {
        //        GameObject item = Instantiate(items[i], slot.transform);
        //        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //        slot.itemSlot = item;
        //    }
         
        //}

    }

    public List<InventorySaveData> GetitemsInventory()
    {
        List<InventorySaveData> inventorySaveDataList = new List<InventorySaveData>();
        foreach (Transform slotTransform in inventario.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.itemSlot != null)
            {
               Item item = slot.itemSlot.GetComponent<Item>();
                InventorySaveData inventorySaveData = new InventorySaveData
                {
                    ID = item.id,
                    slotIndex = slotTransform.GetSiblingIndex()
                };
                inventorySaveDataList.Add(inventorySaveData);
            }
        }
        return inventorySaveDataList;
    }

    public void SetItemsInventory(List<InventorySaveData> inventorySaveDataList)
    {
        foreach (Transform slotTransform in inventario.transform)
        {
            Destroy(slotTransform.gameObject);
        }
        for (int i = 0; i < slotsNumber; i++)
        {
            Instantiate(slotPrefab, inventario.transform).GetComponent<Slot>();
        }
        foreach (InventorySaveData inventorySaveData in inventorySaveDataList)
        {
            if(inventorySaveData.slotIndex < slotsNumber)
            {
                Slot slot = inventario.transform.GetChild(inventorySaveData.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = dicionarioItems.GetItem(inventorySaveData.ID);
                if (itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.itemSlot = item;
                }
            }
        }
    }
}
