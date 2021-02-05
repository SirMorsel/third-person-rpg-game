using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item item;
    public override void interact()
    {
        base.interact();
        pickUp();
    }

    void pickUp()
    {
        Debug.Log("Pick up item: " + item.name);
        
        if (Inventory.instance.addToInventory(item))
        {
            Destroy(gameObject);
        }
    }
}
