using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windDetection : MonoBehaviour
{
    powerGentleWind windPower;
    // Start is called before the first frame update
    void Start()
    {
        windPower = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<powerGentleWind>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("has collided");
        if(other.gameObject.tag != "LightSource")
        {
            Debug.Log(other.transform.name);
            windPowerInterface iWind = other.GetComponent<windPowerInterface>();
            if (iWind != null)
            {
                iWind.gentleWind();
            }
            GameObject.Destroy(this.gameObject);
            windPower.canUse = true;
        }
     
    }
}
