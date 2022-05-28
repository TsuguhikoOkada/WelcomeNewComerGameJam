using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Enemyの挙動に関するスクリプト</summary>

[Serializable]
enum EnemyActionPattern
{
    Pattern1,
    Pattern2,
    Pattern3,
    Pattern4,
    
}
public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] EnemyActionPattern _actionPattern;
    

    ///<summary>敵のスピードのメンバ変数</summary>
    [SerializeField,Header("スピード")] float _enemySpeed;

    

    ///// <summary>チェックポイントオブジェクトのメンバ変数</summary>
    [SerializeField]GameObject[] _checkPointObjects;

    ///// <summary>到達ポイントオブジェクトのメンバ変数</summary>
    [SerializeField] GameObject[] _achivementPointObjects;

    

    /// <summary>EnemyのRigidbody2Dのメンバ変数</summary>
    Rigidbody2D _rb2DE;

    

    Vector3 _dir;

    float _vx;

    float _vy;

    

    void Start()
    {
        //_targetObject = GameObject.Find(_targetName);

        _rb2DE = GetComponent<Rigidbody2D>();

        _rb2DE.constraints = RigidbodyConstraints2D.FreezeRotation;

        //_chaseStopArea = GetComponent<Transform>();
    }

    
    void FixedUpdate()
    {
        
        //_count = UnityEngine.Random.Range(0, 3);
        switch (_actionPattern)
        {
            case EnemyActionPattern.Pattern1:
                _dir = (_checkPointObjects[0].transform.position - transform.position).normalized;
                _vx = _dir.x * _enemySpeed;
                _vy = _dir.y * _enemySpeed;
                _rb2DE.velocity = new Vector3(_vx, _vy,0);
                break;
            case EnemyActionPattern.Pattern2:
                _dir = (_checkPointObjects[0].transform.position - transform.position).normalized;
                _vx = _dir.x * _enemySpeed;
                _vy = _dir.y * _enemySpeed;
                _rb2DE.velocity = new Vector3(_vx, _vy, 0);
                break;
            case EnemyActionPattern.Pattern3:
                _dir = (_checkPointObjects[1].transform.position - transform.position).normalized;
                _vx = _dir.x * _enemySpeed;
                _vy = _dir.y * _enemySpeed;
                _rb2DE.velocity = new Vector3(_vx, _vy, 0);
                break;
            case EnemyActionPattern.Pattern4:
                _dir = (_checkPointObjects[1].transform.position - transform.position).normalized;
                _vx = _dir.x * _enemySpeed;
                _vy = _dir.y * _enemySpeed;
                _rb2DE.velocity = new Vector3(_vx, _vy, 0);
                break;
            
        }
        

        
        

        //if (_chaseStopArea.position.y < - 0.672)
        //{
        //    (_targetObject) = GameObject.Find(_targetName);
        //    _targetName = _returnSpotName;
        //    _returnSpotObject = GameObject.Find(_returnSpotName);
        //    dir = (_returnSpotObject.transform.position + this.transform.position).normalized;
        //    vx = dir.x * _chaseSpeed;
        //    vy = dir.y * _chaseSpeed;
        //    _rb2DE.velocity = new Vector2(vx, vy);



        //}
        //else
        //{
           
        //}
 
    }

    //private void OnTriggerEnter2D(Collider2D returnSpotCol)
    //{
    //    if (returnSpotCol.gameObject == _returnSpotObject) Destroy(this.gameObject);
    //}

}