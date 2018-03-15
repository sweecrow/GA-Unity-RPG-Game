using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats : CharactarStats {

    public Text helthtext;
    public Text leveltext;
    public Text exptext;
    public Text requiredxp;

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

                experienceRequired = 600;
                maxHealth += 5;
                break;
            case 3:

                experienceRequired = 1000;
                maxHealth += 5;
                break;
            case 4:

                experienceRequired = 1500;
                maxHealth += 5;
                break;
            case 5:

                experienceRequired = 2100;
                maxHealth += 5;
                break;
            case 6:

                experienceRequired = 2800;
                maxHealth += 5;
                break;
            case 7:

                experienceRequired = 3200;
                maxHealth += 5;
                break;
            case 8:

                experienceRequired = 4000;
                maxHealth += 5;
                break;
            case 9:

                experienceRequired = 5000;
                maxHealth += 5;
                break;
            case 10:

                experienceRequired = 6300;
                maxHealth += 5;
                break;
        }
    }

    void Exp()
    {
        if (experience >= experienceRequired)
            RankUp();
    }
    
    void Update()
    {
        helthtext.text = "Health: " + CurrentHealth.ToString();
        leveltext.text = "Level: " + level.ToString();
        exptext.text = "XP: " + experience.ToString();
        requiredxp.text = "RequiredXp: " + experienceRequired.ToString();

        Exp();

        if (Input.GetKeyDown(KeyCode.M))
        {
            GiveExperience();
        }

        if (CurrentHealth != maxHealth && !isRegenHealth)
        {
            StartCoroutine(RegainHealthOverTime());
        }

    }

    private IEnumerator RegainHealthOverTime()
    {
        isRegenHealth = true;
        while (CurrentHealth < maxHealth)
        {
            Healthregen();
            yield return new WaitForSeconds(1);
        }
        isRegenHealth = false;
    }

    public void Healthregen()
    {
        CurrentHealth += healthReg;

    }


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