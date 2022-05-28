using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    [SerializeField] string _sceneName;

    Rigidbody2D _rb2D;
    /// <summary>水平、横方向</summary>
    float _horizontal = 0f;
    /// <summary>垂直、縦方向</summary>
    float _veritical = 0f;
    /// <summary>方向</summary>
    Vector2 _dir;
    [SerializeField, Header("Playerの弾のTag")] string _playerBulletTag = "Bullet";
    /// <summary>体力</summary>
    [SerializeField, Header("体力")] int _hp = 10;
    /// <summary>移動スピード</summary>
    [SerializeField, Header("移動スピード")] float _speed = 2f;
    /// <summary>停止時間</summary>
    [SerializeField, Header("停止時間")] float _stopTime = 2f;
    /// <summary>移動時間</summary>
    [SerializeField, Header("移動時間")] float _moveTime = 0.5f;
    /// <summary>右限</summary>
    [SerializeField, Header("右限")] float _rightLimit = 4f;
    /// <summary>左限</summary>
    [SerializeField, Header("左限")] float _leftLimit = -4f;
    /// <summary>上限</summary>
    [SerializeField, Header("上限")] float _upperLimit = 2.5f;
    /// <summary>下限</summary>
    [SerializeField, Header("下限")] float _lowerLimit = 1.5f;
    /// <summary>左方向</summary>
    const float LEFT_DIR = -1f;
    /// <summary>右方向</summary>
    const float RIGHT_DIR = 1f;
    /// <summary>上方向</summary>
    const float UP_DIR = 1f;
    /// <summary>下方向</summary>
    const float DOWN_DIR = -1f;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(RandomMovement());;
    }


    IEnumerator RandomMovement()
    {
        //Debug.Log("OK");
        while (true)
        {
            //一定時間止まる
            _rb2D.velocity = Vector2.zero;
            yield return new WaitForSeconds(_stopTime);

            //場所によって移動できる左右方向を制限する
            if (_rb2D.transform.position.x > _rightLimit)         //右に移動しすぎたら
            {
                _horizontal = Random.Range(LEFT_DIR, 0);//左移動可能
            }
            else if (_rb2D.transform.position.x < _leftLimit)   //左に移動しぎたら
            {
                _horizontal = Random.Range(0, RIGHT_DIR);//右移動可能
            }
            else　　　　　　　　　　　　         //左右どっちにも移動しすぎてないなら
            {
                _horizontal = Random.Range(LEFT_DIR, RIGHT_DIR);//自由に左右移動可能          
            }

            //場所によって移動できる上下方向を制限する
            if (_rb2D.transform.position.y > _upperLimit)      //上に移動しすぎたら
            {
                _veritical = Random.Range(DOWN_DIR, 0);//下移動可能
            }
            else if (_rb2D.transform.position.y < _lowerLimit)//下に移動しすぎたら
            {
                _veritical = Random.Range(0, UP_DIR);//上移動可能
            }
            else　　　　　　　　　　　　　　      //上下どっちにも移動しすぎてないなら
            {
                _veritical = Random.Range(DOWN_DIR, UP_DIR);//自由に上下移動可能
            }

            _dir = new Vector2(_horizontal, _veritical);//ランダムに移動

            //一定時間移動する
            _rb2D.velocity = _dir.normalized * _speed;
            yield return new WaitForSeconds(_moveTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _playerBulletTag)
        {
            collision.gameObject.SetActive(false);
            _hp--;
            if (_hp <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}
