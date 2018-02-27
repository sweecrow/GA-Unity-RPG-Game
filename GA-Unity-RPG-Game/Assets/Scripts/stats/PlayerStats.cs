using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats : CharactarStats {

    public Text helthtext;
    public Text leveltext;
    public Text exptext;
    public Text requiredxp;

    // Use this for initialization
    void Start ()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;

        level = 1;
        experience = 0;
        experienceRequired = 100;

        helthtext.text = "Health: " + CurrentHealth.ToString();
        leveltext.text = "Level: " + level.ToString();
        exptext.text = "XP: " + experience.ToString();
        requiredxp.text = "RequiredXp: " + experienceRequired.ToString();

        
    }
    /// <summary>
    /// /////////////
    /// </summary>
    void RankUp()
    {
        level += 1;
        experience = 0;

        switch (level)
        {
            case 1:

                experienceRequired = 400;
                break;
            case 2:

                experienceRequired = 1000;
                break;
        }
    }

    void Exp()
    {
        if (experience >= experienceRequired)
            RankUp();

    }
    /// <summary>
    /// ///////////
    /// </summary>
    void Update()
    {
        helthtext.text = "Health: " + CurrentHealth.ToString();
        leveltext.text = "Level: " + level.ToString();
        exptext.text = "XP: " + experience.ToString();
        requiredxp.text = "RequiredXp: " + experienceRequired.ToString();

        Exp();

        if (Input.GetKeyDown(KeyCode.M))
        {
            experience += 100;
        }
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