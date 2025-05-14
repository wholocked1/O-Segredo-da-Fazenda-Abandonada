using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicionarioItems : MonoBehaviour
{
    public List<Item> items;
    public static DicionarioItems Instance;
    private Dictionary<string, GameObject> itemDictionary;

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

        itemDictionary = new Dictionary<string, GameObject>();
        foreach (Item item in items)
        {
            itemDictionary.Add(item.id, item.gameObject);
        }
    }

    public GameObject GetItem(string id)
    {
        itemDictionary.TryGetValue(id, out GameObject item);
        if(item == null)
        {
            Debug.LogWarning("Item not found: " + id);
            return null;
        }
        return item;
    }

}
