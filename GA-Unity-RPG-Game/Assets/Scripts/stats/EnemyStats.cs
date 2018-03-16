using UnityEngine;
using System.Collections;


public class EnemyStats : CharactarStats {

    public override void Die()
    {
        base.Die();

         Destroy(gameObject);
    }
}