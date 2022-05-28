using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField, Header("スコアテキスト")] Text _scoreText;

    static int _score;

    public static int Score => _score;


    void Start()
    {
        _score = 0;
        _scoreText.text = "Score: " + _score.ToString("D4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
