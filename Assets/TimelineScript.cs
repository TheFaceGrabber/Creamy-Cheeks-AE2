using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineScript : MonoBehaviour {

    PlayableDirector director;

    public bool startedOnCollision;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider col)   // If the cinematic is played by
    {                                           // colliding with something, e.g. 
        if (startedOnCollision)                 // walking into a room, do this
        {
            if (col.tag == "Player")
            {
                director.Play();
            }
        }
    }

    public void Play()  // When the cinematic needs to be manually called upon some kind of event
    {
        director.Play();
    }
}
