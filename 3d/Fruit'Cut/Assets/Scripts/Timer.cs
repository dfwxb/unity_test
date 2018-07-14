using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    bool run = false;
    bool showTimeLeft = true;
    bool timeEnd = false;
    bool pause = false;
    float startTime = 0.0f;
    float curTime = 0.0f;
    public float timeAvailable = 30.0f;
    float showTime = 0;
    string curStrTime;

    public Text guiTimer;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (pause)
        {
            startTime += Time.deltaTime;
            return;
        }

	    if (run)
        {
            curTime = Time.time - startTime;

            // 如果在倒计时状态
            if (showTimeLeft)
            {
                showTime = timeAvailable - curTime;
                if (showTime <= 0)
                {
                    timeEnd = true;
                    showTime = 0;
                }
            }
        }

        int minutes = (int)(showTime / 60);
        int seconds = (int)(showTime % 60);
        int fraction = (int)((showTime * 100) % 100);

        curStrTime = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);

        guiTimer.text = "TIME: " + curStrTime;
    }

    public void RunTimer()
    {
        run = true;
        startTime = Time.time;
    }

    public void PauseTimer(bool b)
    {
        pause = b;
    }
}
