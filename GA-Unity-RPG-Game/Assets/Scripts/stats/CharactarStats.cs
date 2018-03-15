using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharactarStats : MonoBehaviour {

    public int maxHealth = 100;
    public int CurrentHealth; //{ get; private set; }
    public int healthReg;

    public bool isRegenHealth;


    public stat damage;
    public stat armor;

    //Level System start
    public int level;
    public float experience;
    public float experienceRequired;

    
    public void GiveExperience()
    {
        experience += 20;
    }

    //Level system stop
    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damages.");
        
        if (CurrentHealth <= 0)
        {
            Die();
            
        }
    }

 
    public virtual void Die()
    {
        Debug.Log(transform.name + "Deid.");
    }
}