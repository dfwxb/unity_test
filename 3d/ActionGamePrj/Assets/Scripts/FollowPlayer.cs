using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


    private Transform player;

    public float speed = 2;

    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
	void Update () {
        // 位置跟随
        Vector3 targetPos = player.position + new Vector3(0, 2.0f, -3.0f);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);

        // 角度跟随
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }
}
