using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulMonster : MonoBehaviour {

    private Transform player;
    private CharacterController cc;
    private Animator animator;
    public float attackDistance = 2; // 攻击距离和寻路距离
    public float speed = 2;
    public float attackTime = 3;
    private float attackTimer = 0;
    private AtkAndDamage playerAtkAndDamage;
                                     // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerAtkAndDamage = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<AtkAndDamage>();
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (playerAtkAndDamage.hp <= 0)
        {
            animator.SetBool("Walk", false);
            return;
        }

        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        float distance = Vector3.Distance(targetPos, transform.position);
        // 攻击
        if (distance <= attackDistance)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTime)
            {
                animator.SetTrigger("Attack");
                attackTimer = 0;
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        else // 追踪
        {
            attackTimer = attackTime;
            animator.SetBool("Walk", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun"))
            {
                cc.SimpleMove(transform.forward * speed);
            }     
        }
	}
}
