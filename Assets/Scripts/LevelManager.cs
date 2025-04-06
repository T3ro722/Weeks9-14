using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int enemyAliveCount;
    public bool isGameOver = false;
    public bool gameStarted = false;
    public GameObject titlePanel;
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        enemyAliveCount = FindObjectsOfType<Enemy>().Length;
        Debug.Log("Enemy count at start: " + enemyAliveCount);
    }

    public void OnEnemyKilled()
    {
        enemyAliveCount--;
        Debug.Log("Enemy Count = " + enemyAliveCount);
        if (enemyAliveCount <= 0 )
        {
            WinGame();
            Debug.Log("You win!");
        }
    }

    public void StartGame()
    {
        titlePanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1f;

        enemyAliveCount = FindObjectsOfType<Enemy>().Length;
        Debug.Log("Total enemies:" + enemyAliveCount);
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
        isGameOver = true;
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        isGameOver = true;
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }

    public void ResetGame()
    {
        isGameOver = false;
        gameStarted = false;
        enemyAliveCount = FindObjectsOfType<Enemy>().Length;

        ScoreSystem scoreSystem = FindObjectOfType<ScoreSystem>();
        if (scoreSystem != null)
        {
            scoreSystem.ResetScore();
        }
        PlayerMoveSystem player = FindObjectOfType<PlayerMoveSystem>();
        if (player != null)
        {
            player.powerUpActive = false;
        }
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        titlePanel.SetActive(true);

        Time.timeScale = 0f;//stops time
    }
}

