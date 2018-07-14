using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;


public class Snake : MonoBehaviour {

    public GameObject tailPrefab;
    public float speed = 0.3f;
    Vector2 dir = Vector2.right;

    List<Transform> tail = new List<Transform>();

    public Action onLose;

    bool ate = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Move", speed, speed);
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
    }

    void Move()
    {
        transform.Translate(dir);

        Vector2 v = transform.position;

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);

            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("food"))
        {
            ate = true;
            Destroy(coll.gameObject);
        }
        else
        {
            if (onLose != null)
            {
                onLose();
            }
        }
        
    }
}
