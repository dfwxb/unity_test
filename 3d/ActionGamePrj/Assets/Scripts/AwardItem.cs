using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AwardType
{
    Gun,
    DualSword
};

public class AwardItem : MonoBehaviour {

    public AwardType awardType;
    public float speed = 8;
    private Rigidbody rigidbody;
    private Transform player;
    // 标记：当碰到主角是就开始向主角移动
    private bool startMove = false;

    public AudioClip pickupClip;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }

    void Update()
    {
        if (startMove)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + Vector3.up, speed*Time.deltaTime);
            if (Vector3.Distance(transform.position, player.position + Vector3.up) <= 0.3f)
            {
                // 主角拾取物品
                player.GetComponent<PlayerAward>().GetAward(awardType);
                // 销毁物品
                Destroy(this.gameObject);

                AudioSource.PlayClipAtPoint(pickupClip, transform.position, 1);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tags.ground)
        {
            rigidbody.useGravity = false; // 去掉重力
            rigidbody.isKinematic = true; // 保持静止状态
            SphereCollider coll = this.GetComponent<SphereCollider>();
            coll.isTrigger = true; // 添加触发器效果
            coll.radius = 2; // 半径变大，碰撞范围增加
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 接触主角
        if (other.tag == Tags.player)
        {
            player = other.transform;
            startMove = true;      
        }
    }
}
