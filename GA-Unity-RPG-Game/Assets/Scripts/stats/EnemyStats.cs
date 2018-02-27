using UnityEngine;
using System.Collections;


public class EnemyStats : CharactarStats {

    Animator myAnimator;
   
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = true;

         
    }

    public override void Die()
    {
        base.Die();

        
       
        //Add death animation
        myAnimator.SetBool("IsDead", true);
        
        Destroy(gameObject);
    }
}