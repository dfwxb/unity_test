using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager _instance = null;

    public EnemySpawn[] monsterSpawnArray;
    public EnemySpawn[] bossSpawnArray;

    public List<GameObject> enemyList = new List<GameObject>();

    public AudioClip victoryClip;
    private AudioSource audioSource;

    void Awake()
    {
        _instance = this;
        audioSource = this.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
	}
	
	IEnumerator Spawn()
    {
        // 第一波敌人
        foreach(EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        // 第二波敌人
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }

        // 第3波敌人
        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);

        foreach (EnemySpawn s in monsterSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        yield return new WaitForSeconds(0.5f);

        // Boss产生
        foreach (EnemySpawn s in bossSpawnArray)
        {
            enemyList.Add(s.Spawn());
        }

        while (enemyList.Count > 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        // 游戏胜利
        audioSource.PlayOneShot(victoryClip, 1);
    }
}
