using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats : CharactarStats {

    public Text helthtext;
    

	// Use this for initialization
	void Start ()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        helthtext.text = "Health: " + CurrentHealth.ToString();
        
	}

    void Update()
    {
        helthtext.text = "Health: " + CurrentHealth.ToString();
    }

    // Update is called once per frame
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }


    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}