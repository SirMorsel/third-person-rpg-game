using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public equipmentSlot equipSlot;
    public int armorModifier;
    public int damageModifier;

    public override void use()
    {
        base.use();
        EquipmentManager.instance.equip(this);
        removeFromInventory();
    }
}

public enum equipmentSlot
{
    Head,
    Chest,
    Weapon,
    Shield,
    Legs,
    Feet
}
