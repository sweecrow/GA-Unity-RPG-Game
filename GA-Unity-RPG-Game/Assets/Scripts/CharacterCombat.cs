using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharactarStats))]
public class CharacterCombat : MonoBehaviour {

    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharactarStats myStats;

    Animator animi;


    void Start()
    {
        myStats = GetComponent<CharactarStats>();

        animi = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        attackCooldown -= Time.deltaTime;    
    }

    public void Attack(CharactarStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
                
            }

            attackCooldown = 1f / attackSpeed;

            animi.SetTrigger("Attack");
        }
        
    }

    IEnumerator DoDamage (CharactarStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        myStats.GiveExperience();

        stats.TakeDamage(myStats.damage.GetValue());

        
    }
}