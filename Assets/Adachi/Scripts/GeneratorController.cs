using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    /// <summary>生成対象名</summary>
    [SerializeField, Header("生成スポット名")] string _generatorSpotName = "GeneratorSpotObject";

    /// <summary>EnemyのPrefab</summary>
    [SerializeField, Header("EnemyのPrefab")] List<GameObject> _enemy = new List<GameObject>();

    /// <summary>Enemyが生成される場所の左限</summary>
    [SerializeField, Header("Enemyが生成される場所の左限")] float _leftLimitPos = -1f;

    /// <summary>Enemyが生成される場所の右限</summary>
    [SerializeField, Header("Enemyが生成される場所の右限")] float _rightLimitPos = 1f;

    /// <summary>最短の制限時間</summary>
    [SerializeField, Header("最短の制限時間")] float _miniLimit = 3f;

    /// <summary>最長の制限時間</summary>
    [SerializeField, Header("最長の制限時間")] float _maxLimit = 10f;

    /// <summary>生成スポット</summary>
    GameObject _generatorSpotObject;

    /// <summary>タイマー</summary>
    float _timer;

    /// <summary>制限時間（になったらEnemyが生成される）</summary>
    float _timeLimit;

    void Start()
    {
        _generatorSpotObject = GameObject.Find(_generatorSpotName);
    }

    void Update()
    {
        _timer += Time.deltaTime;
        Generator(0);        
    }

    /// <summary>ランダムな秒数でランダムな位置に敵を生成</summary>
    /// <param name="number">出したいEnemyのナンバー</param>
    void Generator(int number)
    {
        //ランダムな秒数で生成
        if(_timer >= _timeLimit)
        {
            //ランダムな位置に生成
            Instantiate(_enemy[number], _generatorSpotObject.transform.position - new Vector3(Random.Range(_leftLimitPos,_rightLimitPos), 0f, 0f), Quaternion.identity, _generatorSpotObject.transform);
            _timer = 0;
            _timeLimit = Random.Range(_miniLimit, _maxLimit);
        }
    }
}
