using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 3;
    private CharacterController cc;
    private Animator animator;
    

    void Awake()
    {
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 以虚拟摇杆为优先
        if (JoyStick.h != 0 || JoyStick.v != 0)
        {
            h = JoyStick.h;
            v = JoyStick.v;
        }

        if (Mathf.Abs(h) >= 0.1f || Mathf.Abs(v) >= 0.1f)
        {
            animator.SetBool("Walk", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRun"))
            {
                Vector3 targetDir = new Vector3(h, 0, v);
                transform.LookAt(targetDir + transform.position);
                cc.SimpleMove(transform.forward * speed);
            }    
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
