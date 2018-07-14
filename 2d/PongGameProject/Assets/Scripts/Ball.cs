using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D> ();

		GoBall ();
	}
		
	// Update is called once per frame
	void Update () {
		Vector2 vel = rigidbody2D.velocity;
		if (Mathf.Abs(vel.x) < 9 && vel.x != 0) {
			if (vel.x < 0) {
				vel.x = -10;
			} else {
				vel.x = 10;
			}
			rigidbody2D.velocity = vel;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log (rigidbody2D.velocity);
		if (coll.collider.tag == "Player") {
			Vector2 vel = rigidbody2D.velocity;
			vel.y = vel.y/2.0f + coll.rigidbody.velocity.y/2.0f;
			rigidbody2D.velocity = vel;
		}

		if (coll.gameObject.name == "rightWall" || coll.gameObject.name == "leftWall") {
			GameManager.Instance.ChangeScore (coll.gameObject.name);
		}
	}

	void GoBall() {
		rigidbody2D.velocity = new Vector2 (0, 0);
		int number = Random.Range (0, 2);
		if (number == 1) {
			rigidbody2D.AddForce (new Vector2 (100, 0));
		} else {
			rigidbody2D.AddForce (new Vector2 (-100, 0));
		}
	}

	public void Reset() {
		transform.position = Vector3.zero;
		GoBall ();
	}

}
