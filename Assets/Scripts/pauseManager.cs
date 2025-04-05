using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pauseManager : MonoBehaviour
{
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

        yield return new WaitForSeconds(pauseDuration);

        // End pause
        isPaused = false;
        OnPauseEnd.Invoke();

        // Wait for cooldown before allowing next pause
        yield return new WaitForSeconds(pauseCooldown);
        canPause = true;
    }

}
