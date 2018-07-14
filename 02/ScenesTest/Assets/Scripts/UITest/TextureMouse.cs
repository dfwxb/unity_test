using UnityEngine;
using System.Collections;

public class TextureMouse : MonoBehaviour {

	GUITexture texture;

	// Use this for initialization
	void Start () {
		texture = gameObject.GetComponent<GUITexture> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		texture.color = Color.red;
	}

	void OnMouseExit() {
		texture.color = Color.green;
	}

	void OnMouseDown() {
		texture.color = Color.blue;
	}
}
