using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerFreezeTime : basePower
{

    public float duration = 3f;
    globalTimeScript timeScript;
    public powerFreezeTime()
    {
        powerName = "Freeze Time";
        manaCost = 60;
    }
    public void Awake()
    {
        timeScript = GameObject.FindGameObjectWithTag("timeController").GetComponent<globalTimeScript>();
    }
    public override void Execute()
    {
        if(canUse)
        {
            timeScript.callAllTimeStops();
            canUse = false;
            StartCoroutine(waitDuration());
        }
     
    }

    IEnumerator waitDuration()
    {
        yield return new WaitForSeconds(duration);
        timeScript.callAllTimeStarts();
        canUse = true;
        Debug.Log("Time has restarted");
    }
}
