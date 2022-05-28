using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    /// <summary>Playerの弾のTag</summary>
    [SerializeField, Header("Playerの弾のTag")] string _playerBulletTag = "Bullet";

    /// <summary>BossEnemyのTag</summary>
    [SerializeField, Header("BossEnemyのTag")] string _bossEnemyTag = "Player";

    /// <summary>ShieldのSpeed</summary>
    [SerializeField, Header("ShieldのSpeed")] float _speed = 5;

    /// <summary>半径</summary>
    [SerializeField, Header("半径")] float _radius = 10;

    /// <summary>シールドが出る時間＆消える時間</summary>
    [SerializeField, Header("シールドが出る時間＆消える時間")] float _timerInterval = 5;

    Rigidbody2D _rb2D;

    SpriteRenderer _sp;

    GameObject _target;

    float _timer;

    /// <summary>当たり判定</summary>
    bool _swich;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
        _target = GameObject.FindWithTag(_bossEnemyTag);
        _swich = true;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if(_target)
        {
            //Bossの周りを回る
            _rb2D.velocity = new Vector3(_radius * Mathf.Sin(Time.time * _speed), _radius * Mathf.Cos(Time.time * _speed),0f) + (_target.transform.position - transform.position).normalized * _speed;
        }
        else
        {
            Destroy(gameObject);
        }

        if(_timer >= _timerInterval)
        {            
            if(_sp.color.a == 255f)
            {
                _sp.color = new Color(_sp.color.r, _sp.color.g, _sp.color.b,0f);
                _swich = false;
            }
            else
            {
                _sp.color = new Color(_sp.color.r, _sp.color.g, _sp.color.b, 255f);
                _swich = true;
            }
            _timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == _playerBulletTag && _swich)
        {
            Debug.Log(collision);
            Vector3 localAngle = collision.gameObject.transform.localEulerAngles;// ローカル座標を基準に取得
            localAngle.z = 180;// 角度を設定
            collision.gameObject.transform.localEulerAngles = localAngle;//回転する
        }
    }
}
