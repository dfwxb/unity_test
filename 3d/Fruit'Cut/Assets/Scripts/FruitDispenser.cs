using UnityEngine;
using System.Collections;

public class FruitDispenser : MonoBehaviour {

    public GameObject[] fruits;
    public GameObject bomb;

    public float z;

    public float powerScale;

    public float forceScale;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 根据Z轴值获取摄像机的视口大小
    Vector2 GetCameraSizeWithZOrder(float z)
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 camerPos = camera.transform.position;
        float distance = Mathf.Abs(camerPos.z - z);
        // 获取高
        float frustumHeight = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        // 获取宽
        float frustumWidth = frustumHeight * camera.aspect;


        Vector2 size = new Vector2();

        size.x = frustumWidth;
        size.y = frustumHeight;

        return size;
    }

    void Spawn()
    {
        bool isBomb = false;
        Vector2 camerSize = GetCameraSizeWithZOrder(z);
        float left = -camerSize.x / 2.0f;
        float right = camerSize.x / 2.0f;
        float x = Random.Range(left, right);
        
        z = Random.Range(4.0f, 8.0f);

        // 动态创建物体
        GameObject ins;

        if (!isBomb)
        {
            ins = Instantiate(fruits[Random.Range(0, fruits.Length)],
                transform.position + new Vector3(x, 0, z),
                Random.rotation) as GameObject;
        }
        else
        {
            ins = Instantiate(bomb,
                transform.position + new Vector3(x, 0, z),
                Random.rotation) as GameObject;
        }

        // 给一个速度
        float power = Random.Range(1.5f, 1.8f) * (-Physics.gravity.y * 1.5f) * powerScale;
        Vector3 direction = new Vector3(-x * 0.05f * Random.Range(0.3f, 0.8f), 1, 0);
        direction.z = 0;
        ins.GetComponent<Rigidbody>().velocity = direction * power; // 平移

        // 随机给一个扭矩
        ins.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * 0.1f, ForceMode.Impulse); // 平移
    }
}
