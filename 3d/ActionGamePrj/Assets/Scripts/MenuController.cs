using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    public static MenuController _instance;

    public Color purple;

    public SkinnedMeshRenderer headRenderer;
    public Mesh[] headMeshArray;
    private int headMeshIndex = 0;

    public SkinnedMeshRenderer handRenderer;
    public Mesh[] handMeshArray;
    private int handMeshIndex = 0;

    public SkinnedMeshRenderer[] bodyRendererArray;

    [HideInInspector]
    public Color[] colorArray;
    private int colorIndex = -1;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        colorArray = new Color[] {
            Color.blue,
            Color.cyan,
            Color.green,
            purple,
            Color.red
        };

        // 这个游戏物体不销毁
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnHeadMeshNext()
    {
        headMeshIndex++;
        headMeshIndex %= headMeshArray.Length;
        headRenderer.sharedMesh = headMeshArray[headMeshIndex];
    }

    public void OnHandMeshNext()
    {
        handMeshIndex++;
        handMeshIndex %= handMeshArray.Length;
        handRenderer.sharedMesh = handMeshArray[handMeshIndex];
    }

    public void OnChangeColorBule()
    {
        colorIndex = 0;
        OnChangeColor(Color.blue);
    }

    public void OnChangeColorCyan()
    {
        colorIndex = 1;
        OnChangeColor(Color.cyan);
    }

    public void OnChangeColorGreen()
    {
        colorIndex = 2;
        OnChangeColor(Color.green);
    }

    public void OnChangeColorPurple()
    {
        colorIndex = 3;
        OnChangeColor(purple);
    }

    public void OnChangeColorRed()
    {
        colorIndex = 4;
        OnChangeColor(Color.red);
    }

    void OnChangeColor(Color c)
    {
        for (int i = 0; i < bodyRendererArray.Length; i++)
        {
            bodyRendererArray[i].material.color = c;
        }
    }

    public void OnPlay()
    {
        Save();
        Application.LoadLevel(1);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("HeadMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("HandMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }
}
