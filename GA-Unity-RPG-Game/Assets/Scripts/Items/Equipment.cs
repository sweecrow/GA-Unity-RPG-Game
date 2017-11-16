﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int armorModifier;
    public int damageModifer;

    public override void Use()
    {
        base.Use();
        //equip the item
        EquipmentManager.instance.Equip(this);
        // Remove it from the inventory
        RemoveFromInventory();
    }
}
public enum EquipmentSlot { Head, Cheast, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion { Legs, Arms, Torso}; // hör ihop med body blendshapes