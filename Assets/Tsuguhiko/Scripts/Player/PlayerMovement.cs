using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

/// <summary>Playerの移動に関するスクリプト</summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>移動スピードのメンバ変数</summary>
    [SerializeField, Header("移動速度")] float _speed;

    /// <summary>Playerの横操作の移動量のメンバ変数</summary>
    [SerializeField, Header("横操作の移動量")] float _inputSpeed;

    /// <summary>PlayerのRigidbody2Dのメンバ変数</summary>
    Rigidbody2D _rb2DP;

    /// <summary>弾の発射間隔</summary>
    [SerializeField, Header("弾の発射間隔")] float _bulletInterval = 0.3f;

    /// <summary>プレイヤーの弾</summary>
    [SerializeField, Header("プレイヤーの弾")] GameObject _playerBullet;

    /// <summary>弾を発射するマズル</summary>
    [SerializeField, Header("弾を発射するマズル")] GameObject _muzzle;

    /// <summary>タイマー</summary>
    float _timer;

    Transform _pool;

    float x;

    Vector2 _playerPos;
    void Start()
    {
        _rb2DP = GetComponent<Rigidbody2D>();

        _rb2DP.constraints = RigidbodyConstraints2D.FreezeRotation;

        //_rb2D = GetComponent<Rigidbody2D>();
        _pool = new GameObject("PlayerBullet").transform;//弾を保持する空のオブジェクトを生成
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");

        _timer += Time.deltaTime;
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

        //Speceキーが押されたら
        if (Input.GetButton("Jump") && _timer >= _bulletInterval)
        {
            ObjectPool(_muzzle.transform.position, Quaternion.identity);//弾を生成
            _timer = 0;//タイマーをリセット
        }

        _playerPos = transform.position;

        _playerPos.x = Clamp(_playerPos.x, -2.77f, 2.77f);

        transform.position = new Vector2(_playerPos.x,_playerPos.y);

    }

    void ObjectPool(Vector3 pos, Quaternion qua)
    {
        foreach (Transform t in _pool)
        {
            //弾が非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(pos, qua);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                return;
            }
        }
        //非アクティブな弾がないなら生成
        Instantiate(_playerBullet, pos, qua, _pool);//生成と同時にPlayerBulletを親に設定
        _playerBullet.SetActive(true);//弾をアクティブにする
    }
}
