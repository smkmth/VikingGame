using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scheduler : MonoBehaviour
{
    private TimeManager timeManager;
    private PathMover pathMover;
    public List<Timeslot> timeSlots;
    private int hoursInDay = 24;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("SceneManager").GetComponent<TimeManager>();
        pathMover = GetComponent<PathMover>();

    }

    public void UpdateNextHour()
    {
       if (timeSlots[timeManager.currentHour].usingThisTimeslot)
        {
            pathMover.target = timeSlots[timeManager.currentHour].placeToGo.position;

        }
        
    }
    
}
