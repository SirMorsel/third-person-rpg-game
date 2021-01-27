using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances found!");
            return;
        }
        instance = this;
    }
    #endregion
    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int inventorySpace = 20;

    public bool addToInventory (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Max space of " + inventorySpace + " reached!");
                return false;
            } else
            {
                items.Add(item);
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
            }
        }
        return true;
    }

    public void removeFromInventory(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
