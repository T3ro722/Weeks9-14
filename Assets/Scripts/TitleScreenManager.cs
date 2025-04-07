using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject title;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(true);
        Time.timeScale = 0f;
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update running. gameStarted: " + gameStarted);

        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed a key to start!");
            title.SetActive(false); // Hide title panel
            Time.timeScale = 1f; // time to normal
            gameStarted = true;


            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null)
            {
                levelManager.StartGame();
            }
        }
    }
}
