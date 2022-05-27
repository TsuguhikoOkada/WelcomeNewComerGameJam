using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Playerの移動に関するスクリプト</summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>移動スピードのメンバ変数</summary>
    [SerializeField, Header("移動速度")] float _speed;

    /// <summary>Playerの横操作の移動量のメンバ変数</summary>
    [SerializeField, Header("横操作の移動量")] float _inputSpeed;

    /// <summary>PlayerのRigidbody2Dのメンバ変数</summary>
    Rigidbody2D _rb2DP;


    float x;


    void Start()
    {
        _rb2DP = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (x == 0) // 何も操作してないとき
        {
            _speed = 0; // Playerのスピードを0にする
        }
        else if (x > 0) //右移動操作のとき
        {
            _speed = _inputSpeed; // Playerのスピードを入力した方向に加える

        }
        else if (x < 0) //左移動操作のとき
        {
            _speed = _inputSpeed * -1; // Playerのスピードを入力した方向とは逆の方に加える

        }

        _rb2DP.velocity = new Vector2(_speed, _rb2DP.velocity.y); // Playerを移動 Vextor2(x軸スピード、y軸スピード(元のまま))
    }
}
