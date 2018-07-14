using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour {

    private bool isPresse = false;
    private Transform button;

    public static float h = 0;
    public static float v = 0;

    void Awake()
    {
        button = transform.Find("Button");
    }

    void OnPress(bool press)
    {
        this.isPresse = press;
        if (!isPresse)
        {
            button.localPosition = Vector3.zero;
            h = 0;
            v = 0;
        }
    }


    void Update()
    {
        if (isPresse)
        {
            print(UICamera.lastTouchPosition);
            Vector2 touchPos = UICamera.lastTouchPosition;
            touchPos -= new Vector2(91, 91);

            float distance = Vector2.Distance(Vector2.zero, touchPos);
            if (distance > 73.0f)
            {
                touchPos = touchPos.normalized * 73;
                button.localPosition = touchPos;
            }
            else
            {
                button.localPosition = touchPos;
            }

            h = touchPos.x / 73;
            v = touchPos.y / 73;
        }
    }
}
