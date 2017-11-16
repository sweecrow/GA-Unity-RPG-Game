using UnityEngine;
using System.Collections;

public class EnemyStats : CharactarStats {

    public override void Die()
    {
        base.Die();

        //Add death animation

        Destroy(gameObject);
    }
}