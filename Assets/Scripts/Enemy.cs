using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    private bool isPaused = false;
    private PlayerMoveSystem playerScript;
    private ScoreSystem scoreSystem;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;//initial pos
        //get PauseManager
        pauseManager pauseManager = FindAnyObjectByType<pauseManager>();
        if (pauseManager != null )
        {
            pauseManager.OnPauseStart.AddListener(onPauseStart);
            pauseManager.OnPauseEnd.AddListener(OnPauseEnd);
        }

        //get player pos
        playerScript = FindObjectOfType<PlayerMoveSystem>();
        if (playerScript != null)
        {
            player = playerScript.transform;
        }
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null || !levelManager.gameStarted) return;
        if (Time.timeScale == 0f) return; //check conditions to proceed
        if (!isPaused && player != null)
        {
            //move towards player
            Vector3 direction = player.position - transform.position; // the direction enemy will head
            direction.x += Random.Range(-0.1f, 0.1f);//random paths slightly to make enemies less dull
            direction.y += Random.Range(-0.1f, 0.1f);
            direction = direction.normalized;//add normalized to prevent them from following the same route
            transform.position += direction * moveSpeed * Time.deltaTime;

            //math to identify if touches player
            float dx = transform.position.x - player.position.x;
            float dy = transform.position.y - player.position.y;
            float dist = Mathf.Sqrt(dx * dx + dy * dy);//pyth for distance math

            if (dist < 1.0f)
            {
                if (playerScript != null && playerScript.powerUpActive)
                {
                    // gets killed
                    Debug.Log("Enemy touched player during powerup. Destroying enemy.");
                    if (scoreSystem != null)
                    {
                        scoreSystem.AddPoint();//check if game is playing, add point
                    }

                    gameObject.SetActive(false);//set to false instead of destroy
                    FindObjectOfType<LevelManager>().OnEnemyKilled();
                }
                else
                {
                    // Player dies
                    Debug.Log("Enemy touched player. Game Over.");
                    FindObjectOfType<LevelManager>().GameOver();
                }
            }
        }


    }
    public void ResetEnemy()
    {
        gameObject.SetActive(true);//revive enemy
        transform.position = originalPosition;//back to OG pos
    }
    public void onPauseStart()
    {
        isPaused = true;
    }

    public void OnPauseEnd()
    {
        isPaused = false;
    }
    public void OnPowerupStart()
    {
        Debug.Log("Powerup started! Enemy can be killed by touch.");
    }

    public void OnPowerupEnd()
    {
        Debug.Log("Powerup ended! Enemy is back to normal.");
    }
}
