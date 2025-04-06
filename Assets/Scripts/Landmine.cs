using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public float explosionRadius = 1f;
    private bool isActive = false;

    void OnEnable()
    {
        pauseManager pause = FindObjectOfType<pauseManager>();
        if (pause != null )
        {
            pause.OnPauseEnd.AddListener(Activate);
        }

    void OnDisable()
        {
            pauseManager pause = FindObjectOfType<pauseManager>();
            if( pause != null)
            {
                pause.OnPauseEnd.RemoveListener(Activate);
            }
        }

    void Activate()
        {
            isActive = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            //detect enemy
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            int killCount = 0;

            for (int i = 0; i < enemies.Length; i++)
            {
                float dx = transform.position.x - enemies[i].transform.position.x;
                float dy = transform.position.y - enemies[i].transform.position.y;
                float dist = Mathf.Sqrt(dx * dx + dy * dy);

                if (dist < explosionRadius)
                {
                    // notify level manager
                    LevelManager levelManager = FindObjectOfType<LevelManager>();
                    if (levelManager != null)
                    {
                        levelManager.OnEnemyKilled();
                    }
                    Destroy(enemies[i].gameObject);
                    killCount++;
                }
            }

            if (killCount > 0)
            {
                ScoreSystem scoreSystem = FindObjectOfType<ScoreSystem>();
                if (scoreSystem != null)
                {
                    scoreSystem.AddPointWithLandmine(killCount);
                }
                Destroy(gameObject);
            }
        }
    }
}
