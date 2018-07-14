using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : MonoBehaviour {

    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float attack = 100;

	// Use this for initialization
	void Start () {
		
	}
	
    public void Shot()
    {
        GameObject go = GameObject.Instantiate(bulletPrefab, bulletPos.position, transform.root.rotation);
        go.GetComponent<Bullet>().attack = attack;
    }
}
