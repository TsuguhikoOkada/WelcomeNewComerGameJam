using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    int score;
    // Start is called before the first frame update
   public void Addscore()
    {
        score += 10;
    }

    public void DecreaseScore()
    {
        score -= 10;
    }

     void Start()
    {
        score = 0;
        Addscore();
        //scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString("D4");
    }
}
