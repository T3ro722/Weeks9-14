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
        gameStarted = false;
        //Reset player
        PlayerMoveSystem player = FindObjectOfType<PlayerMoveSystem>();
        if (player != null)
        {
            player.ResetPlayer();
            player.powerUpActive = false;
        }

        //reset enemies
        Enemy[] enemies = FindObjectsOfType<Enemy>(true);
        foreach (Enemy enemy in enemies)
        {
            enemy.ResetEnemy();
        }

        //Reset powerup
        Powerup[]powerups = FindObjectsOfType<Powerup>(true);
        foreach (Powerup powerup in powerups)
        { powerup.ResetPowerup(); }

        //reset game state
        isGameOver = false;
        gameStarted = false;
        Debug.Log("Resetting TitleScreenManager.gameStarted = false");
        enemyAliveCount = FindObjectsOfType<Enemy>().Length;

        //reset score
        ScoreSystem scoreSystem = FindObjectOfType<ScoreSystem>();
        if (scoreSystem != null)
        {
            scoreSystem.ResetScore();
        }

        //reset Titlescreen manager
        TitleScreenManager titleManager = FindObjectOfType<TitleScreenManager>();
        if (titleManager != null)
        {
            titleManager.gameStarted = false;
        }


        winPanel.SetActive(false);
        losePanel.SetActive(false);
        titlePanel.SetActive(true);

        Time.timeScale = 0f;//stops time
    }
}

