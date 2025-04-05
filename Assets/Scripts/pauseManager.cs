using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class pauseManager : MonoBehaviour
{
    public TextMeshProUGUI pauseText;//declare pause text
    public UnityEvent OnPauseStart;
    public UnityEvent OnPauseEnd;

    public float pauseDuration = 3f;//3 sec pause time
    public float pauseCooldown = 5f;//5 sec cooldown

    private bool isPaused = false;
    private bool canPause = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canPause && !isPaused)
        {
            StartCoroutine(PauseTime());
        }
    }
    IEnumerator PauseTime()
    {
        // Start pause
        isPaused = true;
        canPause = false;
        OnPauseStart.Invoke();  // notify others (like enemy,landmine)

        pauseText.gameObject.SetActive(true);  //Display text
        float remaining = pauseDuration;
        while (remaining > 0)
        {
            pauseText.text = "Paused: " + (int)remaining + "s";
            remaining -= Time.deltaTime;
            yield return null;
        }
        pauseText.gameObject.SetActive(false);

        // End pause
        isPaused = false;
        OnPauseEnd.Invoke();

        // Wait for cooldown before allowing next pause
        yield return new WaitForSeconds(pauseCooldown);
        canPause = true;
    }

}
