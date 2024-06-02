using System.Collections;
using System.Collections.Generic;
using UltEvents;
using UnityEditor.PackageManager;
using UnityEngine;

//for debugging purposes, connect these events up to other scripts to unit test them over time
public class SequencedEvents : MonoBehaviour
{
    public List<UltEvent> events = new List<UltEvent>();

    [SerializeField] float delay = 1;
    float timer = 1;
    int eventIndex = 0;

    void TickTimer(float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0 )
        {
            InvokeNextEvent();
            timer = delay; //reset timer
        }
    }

    void Start ()
    {
        timer = delay;
    }

    private void Update()
    {
        TickTimer(Time.deltaTime);
    }

    void InvokeNextEvent()
    {
        if (eventIndex >= events.Count) { return; }

        UltEvent nextEvent = events[eventIndex];
        if (nextEvent != null) { 
            nextEvent.Invoke();
            eventIndex++;
        }
    }
}
