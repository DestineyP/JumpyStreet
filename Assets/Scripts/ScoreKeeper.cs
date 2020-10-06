using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public static ScoreKeeper ScoreScript;
    public int score;
    public int highScore;
   

    // Start is called before the first frame update
    void Start()
    {
        ScoreScript = this;
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        highScoreText.text = "HighScore: " + highScore;
    }


    void CaptureHighScore()
    {

        if (score > highScore)
        {

            highScore = score;
            scoreText.text = "Score: " + score;
            PlayerPrefs.SetInt("highscore", highScore);
            
        }

    }


   public void AddScore()
   {

        score++;
        scoreText.text = "Score " + score;
        CaptureHighScore();
        highScoreText.text = "HighScore: " + highScore;

   }



void PassScoreToSingleton()
    {

        PassScore.passScript.Score = score;
        PassScore.passScript.highScore = highScore;
    }




}
