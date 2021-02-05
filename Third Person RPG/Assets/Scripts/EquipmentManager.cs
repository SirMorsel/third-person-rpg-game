using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    void Awake()
    {
        instance = this;
    }

    Equipment[] currentEquipment;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        int amountSlots = System.Enum.GetNames(typeof(equipmentSlot)).Length;
        currentEquipment = new Equipment[amountSlots];
    }

    public void equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.addToInventory(oldItem);
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void unEquip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.addToInventory(oldItem);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }

    }

    public void unEquipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            unEquip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            unEquipAll();
        }
    }
}
