using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{
    public float explosionRadius = 3f;
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
        if (!isActive) return;
        {
            //detect enemy
            int killCount = 0;
            Enemy[] enemies = FindObjectsOfType<Enemy>();


            foreach (Enemy enemy in enemies)
            {
                float dx = transform.position.x - enemy.transform.position.x;
                float dy = transform.position.y - enemy.transform.position.y;
                float dist = Mathf.Sqrt(dx * dx + dy * dy);
            

                if (dist < explosionRadius)
                {
                    // notify level manager
                    LevelManager levelManager = FindObjectOfType<LevelManager>();
                    if (levelManager != null)
                    {
                        levelManager.OnEnemyKilled();
                    }
              
                    killCount++;
                    enemy.gameObject.SetActive(false);
                }
            }

            if (killCount > 0)
            {
                ScoreSystem scoreSystem = FindObjectOfType<ScoreSystem>();
                if (scoreSystem != null)
                {
                    scoreSystem.AddPointWithLandmine(killCount);
                }
                Debug.Log("Got" + killCount + "enemies!");
                Destroy(gameObject);
            }
        }
    }
}
