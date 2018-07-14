using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonsterAtkAndDamage : AtkAndDamage {

    private Transform player;

    void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    public void MonAttack()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackDistance)
        {
            player.GetComponent<AtkAndDamage>().TakeDamage(normalAtk);
        }
    }
}
