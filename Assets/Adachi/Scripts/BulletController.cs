using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField, Header("弾のスピード")] float _speed;

    Rigidbody2D _rb2D;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb2D.velocity = gameObject.transform.rotation * new Vector3(0, _speed, 0);
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
