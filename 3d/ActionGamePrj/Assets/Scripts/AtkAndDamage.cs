using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkAndDamage : MonoBehaviour {


    public float hp = 100;
    public float normalAtk = 50;
    public float attackDistance = 1;
    protected Animator animator;

    public AudioClip deathClip;

    protected void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }

        if(hp > 0)
        {
            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                animator.SetTrigger("Damage");
            }

            if (this.tag == Tags.soulBoss)
            {
                // 实例化特效
                GameObject.Instantiate(Resources.Load("HitBoss"), this.transform.position+Vector3.up, this.transform.rotation);
            }
            else if (this.tag == Tags.soulMonster)
            {
                // 实例化特效
                GameObject.Instantiate(Resources.Load("HitMonster"), this.transform.position + Vector3.up, this.transform.rotation);
            }
        }
        else
        {
            animator.SetBool("Dead", true);

            if (this.tag == Tags.soulBoss || this.tag == Tags.soulMonster)
            {
                SpawnManager._instance.enemyList.Remove(this.gameObject);
                SpawnAward();
                Destroy(this.gameObject, 1);
                this.GetComponent<CharacterController>().enabled = false;
            }

            AudioSource.PlayClipAtPoint(deathClip, transform.position, 0.5f);
        }
    }

    void SpawnAward()
    {
        int count = Random.Range(1, 3);
        for(int i = 0; i < count; i++)
        {
            int index = Random.Range(0, 2);
            if (index == 0)
            {
                GameObject.Instantiate(Resources.Load("Item-DualSword"), transform.position + Vector3.up, Quaternion.identity);
            }
            else
            {
                GameObject.Instantiate(Resources.Load("Item-Gun"), transform.position + Vector3.up, Quaternion.identity);
            }
        }
    }
}
