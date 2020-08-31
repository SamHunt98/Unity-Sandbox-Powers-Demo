using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerGentleWind : basePower
{
    public GameObject windBall;
    public Camera mainCam;
    public powerGentleWind()
    {
        powerName = "Gentle Breeze";
        manaCost = 10;
    }

    public override void Execute()
    {
        if(canUse)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Vector3 temp = mainCam.transform.forward * 3f + mainCam.transform.position;
            Debug.Log(temp);
            //Quaternion epic = Quaternion.LookRotation(temp);
            GameObject.Instantiate(windBall, temp, Quaternion.LookRotation(mainCam.transform.forward));
          
            canUse = false;
            StartCoroutine(coolDown());
        }
  

    }
    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(3);
        canUse = true;
    }
}
