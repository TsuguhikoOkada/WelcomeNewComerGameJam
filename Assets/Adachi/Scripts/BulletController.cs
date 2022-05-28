using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    /// <summary>弾のスピード</summary>
    [SerializeField, Header("弾のスピード")] float _speed;

    Rigidbody2D _rb2D;

    /// <summary>EnemyのTag</summary>
    [SerializeField, Header("EnemyのTag")] string _enemyTag = "Enemy";

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb2D.velocity = gameObject.transform.rotation * new Vector3(0, _speed, 0);
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _enemyTag) Destroy(collision.gameObject);
    }
}
