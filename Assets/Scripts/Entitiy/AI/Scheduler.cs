﻿using System.Collections;
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
    
    //gets called by the event in time mangager player jumped forward in time 
    public void JumpForwardInTime(int hourToJumpTo)
    {
        if (timeSlots[hourToJumpTo].usingThisTimeslot)
        {
            Vector3 pos = timeSlots[hourToJumpTo].placeToGo.position;
            pos.y = 0;
            transform.position = pos;
            return;
        }
        else
        {
            for(int i = hourToJumpTo; i >= 0; i--)
            {
                if (timeSlots[i].usingThisTimeslot == true)
                {

                    Vector3 pos = timeSlots[i].placeToGo.position;
                    pos.y = 0;
                    transform.position = pos;
                    return;
                }
                
            }
        }
        Debug.Log("Fix that lazy for loop!");
    }
}


[System.Serializable]
public class Timeslot
{
    public float TimeToTrigger;
    public Transform placeToGo;
    public bool usingThisTimeslot;
}

