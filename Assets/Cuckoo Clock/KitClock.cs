using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourhand;
    public Transform minutehand;
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;
    public Coroutine clockisRunning;
    public IEnumerator doOneHour;

  

    void Start()
    {
        clockisRunning = StartCoroutine(MoveTheClock());
    }

    private IEnumerator MoveTheClock()
    {
        while (true)
        {
            doOneHour = MoveTheClockHandsonehour();
            yield return StartCoroutine(doOneHour);
        }
 
    }
    IEnumerator MoveTheClockHandsonehour()
    {
        t = 0;
        while (t<timeAnHourTakes)
        {
            t += Time.deltaTime;
            minutehand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourhand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if(hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }
    public void StopTheClock()
    {
        if(clockisRunning != null)
        {
            StopCoroutine(clockisRunning);
        }
        if(doOneHour != null)
        {
            StopCoroutine(doOneHour);
        }
     
    }
}
