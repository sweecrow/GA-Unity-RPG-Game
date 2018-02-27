using UnityEngine;
using UnityEngine.UI;


public class CharactarStats : MonoBehaviour {

    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    public stat damage;
    public stat armor;

    //Level System start
    public int level;
    public float experience;
    public float experienceRequired;

    void Start()
    {
        
    }

    

    
    //Level system stop
    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
 
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