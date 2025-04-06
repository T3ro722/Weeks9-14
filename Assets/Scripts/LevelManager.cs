using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int enemyAliveCount;
    public bool isGameOver = false;

    public void OnEnemyKilled()
    {
        enemyAliveCount--;
        if (enemyAliveCount <= 0 )
        {
            Debug.Log("You win!");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        isGameOver = true;
    }

    public void ResetGame()
    {
        isGameOver = false;
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
        Time.timeScale = 0f;//stops time
    }
}

