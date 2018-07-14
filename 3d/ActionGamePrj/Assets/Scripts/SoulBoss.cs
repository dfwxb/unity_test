using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBoss : MonoBehaviour {

    private Transform player;
    private CharacterController cc;
    private Animator animator;
    public float attackDistance = 2; // 攻击距离和寻路距离
    public float speed = 2;
    public float attackTime = 3;
    private float attackTimer = 0;
                                     // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

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
                int num = Random.Range(0, 2);
                if (num == 0)
                {
                    animator.SetTrigger("Attack1");
                }
                else
                {
                    animator.SetTrigger("Attack2");
                }
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("BossRun01"))
            {
                cc.SimpleMove(transform.forward * speed);
            }     
        }
	}
}
