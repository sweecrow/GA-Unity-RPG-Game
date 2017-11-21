﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{

    public EquipmentSlot equipSlot;	// Slot to store equipment in
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;       // Increase/decrease in armor
    public int damageModifier;      // Increase/decrease in damage

    // When pressed in inventory
    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);  // Equip it
        RemoveFromInventory();                  // Remove it from inventory
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion { Legs, Arms, Torso }; // Corresponds to body blendshapes.
