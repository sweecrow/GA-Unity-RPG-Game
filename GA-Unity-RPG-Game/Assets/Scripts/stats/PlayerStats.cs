using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : CharactarStats {

	// Use this for initialization
	void Start ()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	// Update is called once per frame
	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifer);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifer);
        }


    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}