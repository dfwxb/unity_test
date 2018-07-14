using UnityEngine;
using System.Collections;

public class tankController : MonoBehaviour {
	GameObject go;
	public float speed = 1;
	float y = 0;
	Quaternion rotateTo;
	// Use this for initialization
	void Start () {
		go = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")) {
			go.transform.Translate(Vector3.forward*Time.deltaTime*speed);
		}

		if (Input.GetKey("s")) {
			go.transform.Translate(Vector3.back*Time.deltaTime * speed);
		}

		if (Input.GetKey("a")) {
			y = -Time.deltaTime * speed;
		}

		if (Input.GetKey("d")) {
			y = Time.deltaTime * speed;
		}
		y = 0;
		go.transform.Rotate (new Vector3(0, y, 0));
		go.transform.rotation = Quaternion.Slerp (go.transform, rotateTo, Time.deltaTime);
	}
}
