using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalTimeScript : MonoBehaviour
{

    //will be used to store values dictating how the effect of time on everything other than the player is handled

    public bool isTimeStopped = false;
    public bool hasDoneTimeStopCalculation = false; //just for testing so i can call function once from editor
    void Start()
    {
        
    }

   
    void Update()
    {
        //if(isTimeStopped && !hasDoneTimeStopCalculation)
       // {
          //  callAllTimeStops();
       // }
        //if (!isTimeStopped && hasDoneTimeStopCalculation)
        //{
         //   callAllTimeStarts();
            
        //}
    }

    public void callAllTimeStops()
    {

        timeMoveTest[] listToStop = GameObject.FindObjectsOfType<timeMoveTest>(); //would usually populate this list at the start of the level in order to save loading it every time
        foreach(timeMoveTest a in listToStop)
        {
            a.onFreezeTime();
        }
        hasDoneTimeStopCalculation = true;
    }
    public void callAllTimeStarts()
    {
        timeMoveTest[] listToStart = GameObject.FindObjectsOfType<timeMoveTest>();
        foreach(timeMoveTest a in listToStart)
        {
            a.onStartTime();
        }
        hasDoneTimeStopCalculation = false;
    }
}
