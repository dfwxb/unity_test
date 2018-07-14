using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTrial : MonoBehaviour {

    public WeaponTrail myTrial;

    private float t = 0.033f;
    private float tempT = 0;
    private float animationIncrement = 0.003f;

    private void LateUpdate()
    {
        t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);
        if (t > 0)
        {
            while (tempT < t)
            {
                tempT += animationIncrement;
                if (myTrial.time > 0)
                {
                    myTrial.Itterate(Time.time-t+tempT);
                }
                else
                {
                    myTrial.ClearTrail();
                }
            }

            tempT -= t;

            if (myTrial.time > 0)
            {
                myTrial.UpdateTrail(Time.time, t);
            }
        }
    }
}
