using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public static MiniMap _instance;

    private Transform playerIcon;

    public GameObject enemyIconPrefab;

    void Awake()
    {
        _instance = this;
        playerIcon = transform.Find("PlayerIco");
    }

    // Use this for initialization
    void Start () {
        
	}
	
	public Transform GetPlayerIcon()
    {
        return playerIcon;
    }

    public GameObject GetBossIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "BossIcon";
        return go;
    }

    public GameObject GetMonsterIcon()
    {
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
}
