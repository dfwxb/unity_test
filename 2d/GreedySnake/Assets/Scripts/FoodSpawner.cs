﻿using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderLeft;
    public Transform borderRight;
    public Transform borderBottom;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 3, 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
}
