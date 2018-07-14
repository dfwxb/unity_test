using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBossAtkAndDamage : AtkAndDamage {

    private Transform player;
    public AudioClip attackClip;

    void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    public void Attack01()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 1.0f);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackDistance)
        {
            player.GetComponent<AtkAndDamage>().TakeDamage(normalAtk);
        }
    }

    public void Attack02()
    {
        AudioSource.PlayClipAtPoint(attackClip, transform.position, 1.0f);
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < attackDistance)
        {
            player.GetComponent<AtkAndDamage>().TakeDamage(normalAtk);
        }
    }
}
