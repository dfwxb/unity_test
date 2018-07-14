using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationAttack : MonoBehaviour {

    private Animator animator;
    private bool isCanAttackB;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();

        EventDelegate NormalAttackEvent = new EventDelegate(this, "OnNormalAttack");
        GameObject.Find("NormalAttack").GetComponent<UIButton>().onClick.Add(NormalAttackEvent);

        EventDelegate RangeAttackEvent = new EventDelegate(this, "OnRangeAttack");
        GameObject.Find("RangeAttack").GetComponent<UIButton>().onClick.Add(RangeAttackEvent);

        EventDelegate RedAttackEvent = new EventDelegate(this, "OnRedAttack");
        GameObject redAttack = GameObject.Find("RedAttack");
        redAttack.GetComponent<UIButton>().onClick.Add(RedAttackEvent);
        redAttack.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // 攻击按钮事件
    public void OnNormalAttack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttackA") && isCanAttackB)
        {
            print("AttackB");
            animator.SetTrigger("AttackB");
        }
        else
        {
            print("AttackA");
            animator.SetTrigger("AttackA");
        }
        
    }

    public void OnRangeAttack()
    {
        animator.SetTrigger("AttackRang");
        print("OnRangeAttack");
    }

    public void OnRedAttack()
    {
        animator.SetTrigger("AttackGun");
        print("OnRedAttack");
    }

    public void AttackBEvent1()
    {
        print("AttackBEvent1");
        isCanAttackB = true;
    }

    public void AttackBEvent2()
    {
        print("AttackBEvent2");
        isCanAttackB = false;
    }
}
