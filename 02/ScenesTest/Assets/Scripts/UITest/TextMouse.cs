using UnityEngine;
using System.Collections;

public class TextMouse : MonoBehaviour {

	GUIText text;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent<GUIText> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		text.color = Color.red;
	}

	void OnMouseExit() {
		text.color = Color.green;
	}

	void OnMouseDown() {
		text.color = Color.blue;
	}
}
