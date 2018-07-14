using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtkAndDamage : AtkAndDamage {

    public float attackB = 80;
    public float attackRange = 100;
    public float attackGun = 100;
    public WeaponGun gun;

    public AudioClip shotClip;
    public AudioClip swordClip;

    public void AttackA()
    {
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float t = Vector3.Distance(go.transform.position, transform.position);
            if (t < distance)
            {
                enemy = go;
                distance = t;
            }
        }

        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            // y方向保持不变
            targetPos.y = transform.position.y;
            // 主角面向敌人
            transform.LookAt(targetPos);
            // 伤害
            enemy.GetComponent<AtkAndDamage>().TakeDamage(normalAtk);
        }

        AudioSource.PlayClipAtPoint(swordClip, transform.position, 1);
    }

    public void AttackB()
    {
        GameObject enemy = null;
        float distance = attackDistance;
        foreach (GameObject go in SpawnManager._instance.enemyList)
        {
            float t = Vector3.Distance(go.transform.position, transform.position);
            if (t < distance)
            {
                enemy = go;
                distance = t;
            }
        }

        if (enemy != null)
        {
            Vector3 targetPos = enemy.transform.position;
            // y方向保持不变
            targetPos.y = transform.position.y;
            // 主角面向敌人
            transform.LookAt(targetPos);
            // 伤害
            enemy.GetComponent<AtkAndDamage>().TakeDamage(attackB);
        }

        AudioSource.PlayClipAtPoint(swordClip, transform.position, 1);
    }

    public void AttackRange()
    {
        List<GameObject> enemyList = new List<GameObject>();

        float distance = attackDistance;
        foreach (GameObject enemy in SpawnManager._instance.enemyList)
        {
            float t = Vector3.Distance(enemy.transform.position, transform.position);
            if (t < distance)
            {
                enemyList.Add(enemy);
            }
        }

        foreach(GameObject enemy in enemyList)
        {
            enemy.GetComponent<AtkAndDamage>().TakeDamage(attackRange);
        }

        AudioSource.PlayClipAtPoint(swordClip, transform.position, 1);
    }

    public void AttackGun()
    {
        gun.attack = attackGun;
        gun.Shot();

        AudioSource.PlayClipAtPoint(shotClip, transform.position, 1);
    }
}
