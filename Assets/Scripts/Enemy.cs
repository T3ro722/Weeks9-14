using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //get PauseManager
        pauseManager pauseManager = FindAnyObjectByType<pauseManager>();
        if (pauseManager != null )
        {
            pauseManager.OnPauseStart.AddListener(onPauseStart);
            pauseManager.OnPauseEnd.AddListener(OnPauseEnd);
        }

        //get player pos
        PlayerMoveSystem playerScript = FindObjectOfType<PlayerMoveSystem>();
        if (playerScript != null)
        {
            player = playerScript.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && player != null)
        {
            //move towards player
            Vector3 direction = player.position - transform.position;
            transform.position += direction * moveSpeed * Time.deltaTime;

            //math to identify if touches player
            float dx = transform.position.x - player.position.x;
            float dy = transform.position.y - player.position.y;
            float dist = Mathf.Sqrt(dx * dx + dy * dy);
        }
    }

    public void onPauseStart()
    {
        isPaused = true;
    }

    public void OnPauseEnd()
    {
        isPaused = false;
    }
}
