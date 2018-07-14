using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAward : MonoBehaviour {

    // 武器
    public GameObject singleSword;
    public GameObject dualSword;
    public GameObject gun;
    // 武器持续时间
    public float exsitTime = 10;
    public float dualSwordTime = 0;
    public float gunTime = 0;

    void Update()
    {
        if (dualSwordTime > 0)
        {
            dualSwordTime -= Time.deltaTime;
            if (dualSwordTime <= 0)
            {
                TurnToSingleSword();
            }
        }

        if (gunTime > 0)
        {
            gunTime -= Time.deltaTime;
            if (gunTime <= 0)
            {
                TurnToSingleSword();
            }
        }
    }

    public void GetAward(AwardType type)
    {
        // 切换武器
        if (type == AwardType.DualSword)
        {
            TurnToDualSword();
        }
        else if (type == AwardType.Gun)
        {
            TurnToGun();
        }
    }

    void TurnToDualSword()
    {
        singleSword.SetActive(false);
        gun.SetActive(false);
        dualSword.SetActive(true);
        dualSwordTime = exsitTime;
        gunTime = 0;
        UIAttack._instance.TurnToTwoAttack();
    }

    void TurnToGun()
    {
        singleSword.SetActive(false);
        dualSword.SetActive(false);
        gun.SetActive(true);
        gunTime = exsitTime;
        dualSwordTime = 0;
        UIAttack._instance.TurnToOneAttack();
    }

    void TurnToSingleSword()
    {
        singleSword.SetActive(true);
        dualSword.SetActive(false);
        gun.SetActive(false);
        dualSwordTime = 0;
        gunTime = 0;
        UIAttack._instance.TurnToTwoAttack();
    }
}
