using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem : MonoBehaviour
{
    float moveSpeed = 5f;
    private pauseManager pause;
    public GameObject landminePrefab;
    public bool powerUpActive = false;
    private Vector3 originalPosition;


    // Start is called before the first frame update
    void Start()
    {
        pause = FindObjectOfType<pauseManager>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null || !levelManager.gameStarted) return;
        if (Time.timeScale == 0f) return;
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            pos.y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += moveSpeed * Time.deltaTime;
        }

        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.E) && pause.isPaused)
        {
            PlaceLandmine();
        }

        void PlaceLandmine()
        {
            // place a landmine
            Instantiate(landminePrefab, transform.position, Quaternion.identity);
        }
    }
    public void ResetPlayer()
    {
        transform.position = originalPosition;
        powerUpActive = false;
    }
}
