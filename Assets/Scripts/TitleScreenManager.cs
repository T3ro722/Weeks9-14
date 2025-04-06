using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject title;

    // Start is called before the first frame update
    void Start()
    {
        title.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            title.SetActive(false);
            Time.timeScale = 1f;
            Destroy(title);//detroy itself after in game
        }
    }
}
