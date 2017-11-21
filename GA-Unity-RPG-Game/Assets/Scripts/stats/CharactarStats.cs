using UnityEngine;
using UnityEngine.UI;


public class CharactarStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Text healthText; 

    public stat damage;
    public stat armor;
    //UI
    void Start()
    {
        healthText = GetComponent<Text>();
        //healthText.text = "Health:" + currentHealth.ToString();
    }
    //UI
    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damages.");

        //UI
        healthText.text = "Health:" + currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    
    
        
    

    public virtual void Die()
    {

        Debug.Log(transform.name + "Deid.");
    }
}