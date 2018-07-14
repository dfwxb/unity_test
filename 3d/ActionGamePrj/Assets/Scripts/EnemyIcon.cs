using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIcon : MonoBehaviour {

    private Transform icon;
    private Transform player;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag(Tags.player).transform;

        if (this.tag == Tags.soulBoss)
        {
            icon = MiniMap._instance.GetBossIcon().transform;
        }
        else if (this.tag == Tags.soulMonster)
        {
            icon = MiniMap._instance.GetMonsterIcon().transform;
        }
    }

    private void Update()
    {
        Vector3 offset = transform.position - player.position;
        offset *= 10;
        icon.localPosition = new Vector3(offset.x, offset.z, 0);
    }

    private void OnDestroy()
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
