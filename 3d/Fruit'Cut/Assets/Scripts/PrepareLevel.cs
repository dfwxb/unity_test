using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrepareLevel : MonoBehaviour {

    public GameObject getReady;
    public GameObject go;

    public Text levelName;

    void Awake()
    {
        GetComponent<Timer>().timeAvailable = SharedSettings.ConfigTime;
    }

    // Use this for initialization
    void Start () {
        Text levelName = GameObject.Find("GUI/LevelName/LevelName").GetComponent<Text>();
        levelName.text = SharedSettings.levelNames[SharedSettings.LoadLevel];

        StartCoroutine(PrepareRoutine());
	}
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator PrepareRoutine()
    {
        // 等待1秒
        yield return new WaitForSeconds(1.0f);

        // 显示GetReady
        getReady.SetActive(true);

        //  等待2秒
        yield return new WaitForSeconds(2.0f);

        // 关闭GetReady 显示Go
        getReady.SetActive(false);
        go.SetActive(true);

        //  等待1秒
        yield return new WaitForSeconds(1.0f);

        // 关闭Go
        go.SetActive(false);

        // 开始计时
    }
}
