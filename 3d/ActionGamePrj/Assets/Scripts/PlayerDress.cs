using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDress : MonoBehaviour {

    public SkinnedMeshRenderer headRenderer;
    public SkinnedMeshRenderer handRenderer;
    public SkinnedMeshRenderer[] bodyRendererArray;

    // Use this for initialization
    void Start () {
        InitDress();
    }
	
    void InitDress()
    {
        int headMeshIndex = PlayerPrefs.GetInt("HeadMeshIndex");
        int handMeshIndex = PlayerPrefs.GetInt("HandMeshIndex");
        int colorIndex = PlayerPrefs.GetInt("ColorIndex");

        headRenderer.sharedMesh = MenuController._instance.headMeshArray[headMeshIndex];
        handRenderer.sharedMesh = MenuController._instance.handMeshArray[handMeshIndex];
        for (int i = 0; i < bodyRendererArray.Length; i++)
        {
            bodyRendererArray[i].material.color = MenuController._instance.colorArray[colorIndex];
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
