using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    public void AddPoint()
    {
        score++;
        UpdateScoreDisplay();
    }

    public void AddPointWithLandmine(int killCount)
    {
        if (killCount >= 2)
        {
            score += killCount * 2;
        }
        else
        {
            score += killCount;
        }

        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
