using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int highScore = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    
    public void AddScore(int points)
    {
        currentScore += points;

        scoreText.text = "Score: " + currentScore;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = "Highscore: " + highScore;
        }
    }

    public void GameReset()
    {
        currentScore = 0;
        scoreText.text = "Score: " + currentScore;
    }
}
