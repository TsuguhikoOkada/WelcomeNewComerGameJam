using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Enemyの挙動に関するスクリプト</summary>

public class EnemyMovement : MonoBehaviour
{
    /// <summary>追いかけ対象名のメンバ変数</summary>
    [SerializeField,Header("ターゲット名")] string _targetName;

    /// <summary>対象名を追いかけるスピードのメンバ変数</summary>
    [SerializeField,Header("追随スピード")] float _chaseSpeed;

    /// <summary>ターゲットオブジェクトのメンバ変数</summary>
    GameObject _targetObject;

    /// <summary>ジェネレーターオブジェクトのメンバ変数</summary>
    GameObject _returnSpotObject;

    /// <summary>追いかけ対象名のメンバ変数</summary>
    [SerializeField, Header("帰還スポット名")] string _returnSpotName;

    /// <summary>EnemyのRigidbody2Dのメンバ変数</summary>
    Rigidbody2D _rb2DE;

    Transform _chaseStopArea;

    void Start()
    {
        _targetObject = GameObject.Find(_targetName);

        _rb2DE = GetComponent<Rigidbody2D>();

        _rb2DE.constraints = RigidbodyConstraints2D.FreezeRotation;

        _chaseStopArea = GetComponent<Transform>();
    }

    
    void FixedUpdate()
    {
        Vector3 dir = (_targetObject.transform.position - this.transform.position).normalized;

        float vx = dir.x * _chaseSpeed;
        float vy = dir.y * _chaseSpeed;

        if (_chaseStopArea.position.y < -1.8)
        {
            (_targetObject) = GameObject.Find(_targetName);
            _targetName = _returnSpotName;
            _returnSpotObject = GameObject.Find(_returnSpotName);
            dir = (_returnSpotObject.transform.position + this.transform.position).normalized;
            vx = dir.x * _chaseSpeed;
            vy = dir.y * _chaseSpeed;
            _rb2DE.velocity = new Vector2(vx, vy);
        }
        else
        {
            _rb2DE.velocity = new Vector2(vx, vy);
        }
 
    }

    private void OnTriggerEnter2D(Collider2D returnSpotCol)
    {
        if(returnSpotCol.gameObject == _returnSpotObject) Destroy(this.gameObject);
    }
}
