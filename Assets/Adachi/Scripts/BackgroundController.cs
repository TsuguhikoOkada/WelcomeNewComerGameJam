using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景をスクロールさせるスクリプト
/// </summary>
public class BackgroundController : MonoBehaviour
{
    /// <summary>背景が流れるスピード</summary>
    [SerializeField]
    [Header("背景が流れるスピード")]
    float _speed = 0.005f;

    /// <summary>ワープする場所（Y）</summary>
    [SerializeField]
    [Header("ワープする場所（Y")]
    float _posY = 10f;

    void Update()
    {
        //背景を下にスクロール
        transform.position -= new Vector3(0, _speed, 0);

        //下（画面外）までスクロールしたら
        if(-_posY >= gameObject.transform.position.y)
        {
            transform.position = new Vector3(0, _posY, 0);//上にワープ
        }
    }
}
