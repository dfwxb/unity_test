using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    float time, startTime;
    Text timer;

    bool isEnd = false;

    public GameObject gameOverUI;

    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Canvas/Timer").GetComponent<Text>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (isEnd)
        {
            return;
        }

        time = Time.time - startTime;
        int seconds = (int) (time % 60);
        int minutes = (int)(time / 60);

        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        timer.text = timeText;
    }

    public void showGameOver()
    {
        isEnd = true;
        gameOverUI.SetActive(true);
    }
}
