
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class powerManager : MonoBehaviour
{
  
    
    public List<basePower> powerList = new List<basePower>();
    public basePower activePower;
    int activePowerNumber; // tracks the number relating to the index of powerList that is active
    public playerStats stats;
    void Start()
    {
        activePower = powerList[1];
        activePowerNumber = 1;
    }

  
    void Update()
    {
        if(activePower != null)
        {
            if (Input.GetKeyDown(KeyCode.X) && stats.currentMana >= activePower.manaCost)
            {
                activePower.Execute();
                stats.currentMana -= activePower.manaCost;
            }
            if(Input.GetKeyDown(KeyCode.O))
            {
                switchPowerLeft();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                switchPowerRight();
            }
        }
        
    }
    void switchPowerRight()
    {
        if (activePowerNumber != powerList.Count - 1)
        {
            activePower = powerList[activePowerNumber + 1];
            activePowerNumber += 1;
            Debug.Log("current power: " + activePower.powerName);
        }
        else
        {
            activePower = powerList[0];
            activePowerNumber =0;
            Debug.Log("current power: " + activePower.powerName);
        }
    }
    void switchPowerLeft()
    {
        if (activePowerNumber != 0)
        {
            activePower = powerList[activePowerNumber - 1];
            activePowerNumber -= 1;
            Debug.Log("current power: " + activePower.powerName);
        }
        else
        {
            activePower = powerList.Last();
            activePowerNumber = powerList.Count - 1;
            Debug.Log("current power: " + activePower.powerName);
        }

    }
}
