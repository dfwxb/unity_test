using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {

    public float interval = 0.5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FlashLabel", 0, interval);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FlashLabel()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
