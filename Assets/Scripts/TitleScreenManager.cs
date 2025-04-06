using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject title;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            title.SetActive(false); // Hide title panel
            Time.timeScale = 1f; // time to normal
            gameStarted = true;
        }
    }
}
