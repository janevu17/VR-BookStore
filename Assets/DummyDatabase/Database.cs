using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public ItemDatabase items;
    private static Database instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Item GetItemByID(string ID)
    {
        foreach(Item item in instance.items.allItems)
        {
            if (item.itemID == ID)
                Debug.Log("Item found: " + item.itemName);
                return item;
        }
        Debug.Log("No items found");

        return null;
        //return instance.items.allItems.FirstOrDefault(i => i.itemID == ID);
    }

    public static void Main(string[] args)
    {
       GetItemByID("001");
    }
}
