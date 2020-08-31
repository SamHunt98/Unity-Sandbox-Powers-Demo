using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerScoutingEye : basePower
{
    public Camera playerCam;
    public cameraControl playerCamControl;
    public GameObject eyeObject;
    //Camera eyeCam;
    //cameraControl eyeCamControl;
    public float range;
    GameObject eye;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Execute()
    {
        if (canUse)
        {
            RaycastHit hit;
            Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
            if (Physics.Raycast(ray, out hit, range))
            {
                Debug.Log(hit.point);
                spawnCam(hit.point);

            }
            else
            {
                Vector3 spawnPos = ray.origin + ray.direction * range;
                spawnCam(spawnPos);
            }
        }
        else
        {
            despawnCam();
        }
    }

    void spawnCam(Vector3 position)
    {
        playerCam.enabled = false;
        playerCamControl.enabled = false;
        eye = Instantiate(eyeObject, position, Quaternion.identity);
        manaCost = 0;
        canUse = false;
    }
    void despawnCam()
    {
        playerCam.enabled = true;
        playerCamControl.enabled = true;
        GameObject.Destroy(eye);
        eye = null;
        manaCost = 20;
        canUse = true;
    }
}
