using UnityEngine;
using System.Collections;

public class RigdBodyMove : MonoBehaviour {

	Rigidbody m_RigidBody;
	Transform m_Transform;
	// Use this for initialization
	void Start () {
		m_RigidBody = gameObject.GetComponent<Rigidbody> ();
		m_Transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			m_RigidBody.MovePosition (m_Transform.position + Vector3.forward * 0.1f);
			Debug.Log ("W");
		}

		if (Input.GetKey(KeyCode.A)) {
			m_RigidBody.MovePosition (m_Transform.position + Vector3.left * 0.1f);

		}

		if (Input.GetKey(KeyCode.S)) {
			m_RigidBody.MovePosition (m_Transform.position + Vector3.back * 0.1f);
		}

		if (Input.GetKey(KeyCode.D)) {
			m_RigidBody.MovePosition (m_Transform.position + Vector3.right * 0.1f);
		}
	}

	void OnCollisionEnter(Collision coll) {
		Debug.Log("Enter:" + coll.gameObject.name);
	
	}

	void OnCollisionExit(Collision coll) {
		Debug.Log("Exit:" + coll.gameObject.name);

	}

	void OnCollisionStay(Collision coll) {
		Debug.Log("Stay:" + coll.gameObject.name);

	}

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Trigger Enter:" + collider.gameObject.name);
	}

	void OnTriggerExit(Collider collider) {
		Debug.Log("Trigger Exit:" + collider.gameObject.name);
	}

	void OnTriggerStay(Collider collider) {
		Debug.Log("Trigger Stay:" + collider.gameObject.name);
	}
}
