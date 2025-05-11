using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        VerificarCanvasCorreto();
    }

    public bool AdicionaItem(GameObject item)
    {
        foreach(Transform slotTransform in inventario.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.itemSlot == null)
            {
                GameObject novoItem = Instantiate(item, slotTransform);
                novoItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.itemSlot = novoItem;
                Debug.Log("Foi");
                return true;
            }
        }
        Debug.Log("Error");
        return false;
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

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(inventario.GetComponent<RectTransform>());

        // For�ar o Canvas a atualizar e garantir que os slots apare�am
        Canvas canvas = inventario.GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;  // Garantir que o Canvas seja renderizado corretamente
        }
    }

    void VerificarCanvasCorreto()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        Canvas canvasCorreto = null;

        foreach (Canvas canvas in canvases)
        {
            if (canvas.CompareTag("Inventario"))
            {
                canvasCorreto = canvas;
                break;
            }
        }

        if (canvasCorreto != null && inventario.transform.parent != canvasCorreto.transform)
        {
            inventario.transform.SetParent(canvasCorreto.transform, false);
        }
        else
        {
            Debug.LogWarning("Canvas com a tag 'Inventario' não encontrado.");
        }
    }
}
