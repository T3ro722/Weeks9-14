using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused && player != null)
        {
            Vector3 direction = player.position - transform.position;
            transform.position += direction * moveSpeed * Time.deltaTime;
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
