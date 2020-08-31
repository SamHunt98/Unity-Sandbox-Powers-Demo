using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setCurrentPowerText : MonoBehaviour
{
    public powerManager manager;
    Text powerText;

    void Start()
    {
        powerText = GetComponent<Text>();
    }


    void Update()
    {
        powerText.text = manager.activePower.powerName;
    }
}
