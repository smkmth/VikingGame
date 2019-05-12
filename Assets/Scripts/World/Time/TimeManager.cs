using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public const float    secondsInFullDay = 86400;
    public const float    secondsInAHour = 3600;

    public float    currentTimeOfDay;
    public int      currentHour;
    public int      currentDay;
    public float    timeMultiplier;
    public float    sunInitialIntensity;
    public float    sunangle;
    public Light    sun;
    public Color    risingSun;
    public Color    settingSun;
    public Color    daySun;
    public Color    nightSun;
    private int prvHour =200;
    public UnityEvent OnDayEnd;
    public UnityEvent OnHourEnd;

    //86400  seconds in a day
    //3600 seconds in a hour


    // Update is called once per frame
    void Update()
    {
        

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
        currentHour = Mathf.RoundToInt((currentTimeOfDay * secondsInFullDay) / secondsInAHour);
        if (prvHour != currentHour)
        {
            prvHour = currentHour;
            OnHourEnd.Invoke();

        }
        if (currentHour == 11)
        {
            OnDayEnd.Invoke();
        }

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
            currentDay++; 
            
        }
      
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        //evening
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
            sun.color = nightSun;
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            sun.color = Color.Lerp( daySun, sun.color, Time.deltaTime);

            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            sun.color= Color.Lerp(sun.color, settingSun, Time.deltaTime);
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }
        
        sun.intensity = sunInitialIntensity * intensityMultiplier;





    }
}
