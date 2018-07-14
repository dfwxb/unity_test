using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10;
    public float attack = 100;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.soulBoss || other.tag == Tags.soulMonster)
        {
            other.GetComponent<AtkAndDamage>().TakeDamage(attack);
        }
    }
}
