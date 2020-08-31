using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerSummonDecoy : basePower
{
 
    public Camera mainCam;
    public float range;
    public LayerMask groundLayer;
    public GameObject decoy;


    public override void Execute()
    {
        if(canUse)
        {
            RaycastHit hit;
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            if(Physics.Raycast(ray,out hit,range,groundLayer))
            {
                Debug.Log(hit.point);
                Vector3 tempPos = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);
                Instantiate(decoy, tempPos, Quaternion.identity);
            }
        }
    }
}
