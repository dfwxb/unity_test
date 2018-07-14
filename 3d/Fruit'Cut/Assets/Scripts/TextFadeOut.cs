using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFadeOut : MonoBehaviour {

    public float speed = 0.5f;
    Color color;

	// Use this for initialization
	void Start () {
        color = GetComponent<Text>().color;
    }
	
	// Update is called once per frame
	void Update () {
	    if (gameObject.activeSelf)
        {
            color.a -= speed * Time.deltaTime;
            GetComponent<Text>().color = color;
        }
	}
}
