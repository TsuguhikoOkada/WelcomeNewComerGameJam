using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ボス敵の基底クラス
/// </summary>
public class BossEnemyBase : MonoBehaviour
{
    public Rigidbody2D Rb2D { get; set; }

    /// <summary>ボスの体力のプロパティ</summary>
    public int Hp { get; set; }

    /// <summary>ボスの移動速度のプロパティ</summary>
    public int Speed { get; set; }

    public float Timer { get; set; }


    Rigidbody2D _rb2D;

    /// <summary>ボスの体力</summary>
    [SerializeField, Header("体力")] int _hp;

    /// <summary>ボスの移動速度</summary>
    [SerializeField, Header("移動速度")] float _speed;

    
    float _timer;


    protected virtual void Start()
    {
        Debug.Log("Start");
        _rb2D = GetComponent<Rigidbody2D>();
        RandomAction();
    }

    void Update()
    {
        _timer += Time.deltaTime;
    }

    protected virtual void RandomAction()
    {
        switch (Random.Range(0, 0))
        {
            case 0:
                ActionPatten0();
                break;
            case 1:
                ActionPatten1();
                break;
            case 2:
                ActionPatten2();
                break;
            case 3:
                ActionPatten3();
                break;
        }
    }

    protected virtual void ActionPatten0()
    {

    }

    protected virtual void ActionPatten1()
    {

    }

    protected virtual void ActionPatten2()
    {

    }

    protected virtual void ActionPatten3()
    {

    }
}
