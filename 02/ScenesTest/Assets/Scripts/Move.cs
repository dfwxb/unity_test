using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Transform m_Transform;

	// Use this for initialization
	void Start () {
		m_Transform = gameObject.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			m_Transform.Translate (Vector3.forward*0.1f, Space.World);

		}

		if (Input.GetKey(KeyCode.A)) {
			m_Transform.Translate (Vector3.left*0.1f, Space.World);

		}

		if (Input.GetKey(KeyCode.S)) {
			m_Transform.Translate (Vector3.back*0.1f, Space.World);

		}

		if (Input.GetKey(KeyCode.D)) {
			m_Transform.Translate (Vector3.right*0.1f, Space.World);

		}

	}
}
