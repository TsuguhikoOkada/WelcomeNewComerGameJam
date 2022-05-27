using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ボス敵の基底クラス
/// </summary>
public class BossEnemyBase : MonoBehaviour
{
    /// <summary>Rigidbody2Dのプロパティ</summary>
    public Rigidbody2D Rb { get; set; }

    /// <summary>ボスの体力のプロパティ</summary>
    public int Hp { get; set; }

    /// <summary>ボスの移動速度のプロパティ</summary>
    public int Speed { get; set; }

    Rigidbody2D _rb2D;

    /// <summary>ボスの体力</summary>
    [SerializeField, Header("体力")] int _hp;

    /// <summary>ボスの移動速度</summary>
    [SerializeField, Header("移動速度")] float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
