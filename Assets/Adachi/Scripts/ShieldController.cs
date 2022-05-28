using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField, Header("Playerの弾のTag")] string _playerBulletTag = "Bullet";

    Rigidbody2D _rb2D;

    [SerializeField]
    GameObject target;

    private float _speed = 5;
    private float _radius = 5;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        _rb2D.velocity = new Vector2(_radius * Mathf.Sin(Time.time * _speed), _radius * Mathf.Cos(Time.time * _speed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _playerBulletTag )
        {
            Debug.Log(collision);
            Vector3 localAngle = collision.gameObject.transform.localEulerAngles;// ローカル座標を基準に取得
            localAngle.z = 180;// 角度を設定
            collision.gameObject.transform.localEulerAngles = localAngle;//回転する
        }
    }
}
