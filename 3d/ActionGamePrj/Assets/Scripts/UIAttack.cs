using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttack : MonoBehaviour {

    public static UIAttack _instance;

    public GameObject noramlAttack;
    public GameObject redAttack;
    public GameObject rangeAttack;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        noramlAttack = transform.Find("NormalAttack").gameObject;
        redAttack = transform.Find("RedAttack").gameObject;
        rangeAttack = transform.Find("RangeAttack").gameObject;
    }

    public void TurnToOneAttack()
    {
        noramlAttack.SetActive(false);
        rangeAttack.SetActive(false);
        redAttack.SetActive(true);
    }

    public void TurnToTwoAttack()
    {
        noramlAttack.SetActive(true);
        rangeAttack.SetActive(true);
        redAttack.SetActive(false);
    }
}
