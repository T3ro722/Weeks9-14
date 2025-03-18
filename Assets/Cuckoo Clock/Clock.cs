using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour
{
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;
    public Coroutine clockisRunning;
    public IEnumerator doOneHour;

    
    void Start()
    {
        clockisRunning = StartCoroutine(Clocklogic());
    }

    private IEnumerator Clocklogic()
    {
        while (true)
        {
            doOneHour = movebirdoutonehour();
            yield return StartCoroutine(doOneHour);
        }
    }
    IEnumerator movebirdoutonehour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            
            t += Time.deltaTime;
            
            yield return null;
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }
}
