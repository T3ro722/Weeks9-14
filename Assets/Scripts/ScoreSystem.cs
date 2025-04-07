using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bonusText;
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
            bonusText.gameObject.SetActive(true);
            StartCoroutine(HideBonusText());
        }
        else
        {
            score += killCount;
        }

        UpdateScoreDisplay();
    }

    IEnumerator HideBonusText()
    {
        yield return new WaitForSeconds(1f);
        bonusText.gameObject.SetActive(false);
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
    }
}
