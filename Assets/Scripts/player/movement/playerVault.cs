using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//currently snaps a bit too much when moving to the X point. Maybe vault needs to be 2 parts - up part and then a forward part
public class playerVault : MonoBehaviour
{
    Rigidbody rigidBody;
    CapsuleCollider playerCollider;
    Camera playerCam;
    public cameraControl controlCamera;
    public bool isVaulting = false;
    public bool canVault;
    Vector3 vaultStart;
    Vector3 vaultTo;
    public float vaultStartTime;
    public float vaultDuration;
    Vector3 hitNormal;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerCam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canVault)
        {
            startVaulting();
        }
    }


    private void FixedUpdate()
    {
        if(isVaulting)
        {
            float elapsedTime = Time.time - vaultStartTime;
            float percentageElapsed = elapsedTime / vaultDuration;
            transform.position = Vector3.Lerp(vaultStart, vaultTo, percentageElapsed);

            if(percentageElapsed >= 1)
            {
                isVaulting = false;
                playerCollider.isTrigger = false;
                controlCamera.endVaulting();
            }
        }
    }
    private void startVaulting()
    {
        canVault = false;
        isVaulting = true;
        transform.rotation = Quaternion.LookRotation(-hitNormal);
        controlCamera.startVaulting();
        vaultStartTime = Time.time;
        vaultStart = transform.position;
        playerCollider.isTrigger = true;
    }

    public void frontRayCast(GameObject wallObject, Vector3 newPos)
    {
        //checks in front of player when called by the vaultraycast script
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 10);
        if (hit.collider == wallObject.GetComponent<Collider>())
        {
            //Debug.Log("Press E to Vault");
            Vector3 newLocation = newPos;
            vaultTo = new Vector3(newPos.x, newPos.y + 1, newPos.z);
            hitNormal = hit.normal;
            Debug.Log(-hitNormal);
            canVault = true;
        }
    }

    ///previous iterations of the vaulting code where a trigger was used

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "VaultObject")
    //    {
    //        //Debug.Log("Press E to Vault");
    //        if (other.GetComponent<storeVaultObject>() != null) //to avoid crashing if an object has accidentally not been given this script
    //        {
                
    //            RaycastHit hit;
    //            Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 10);
                
    //            if(hit.collider == other)
    //            {
    //                Debug.Log("Press E to Vault");
    //                Transform newLocation = other.GetComponent<storeVaultObject>().vaultLandPoint;
    //                hitNormal = hit.normal;
    //                vaultTo = new Vector3(newLocation.position.x, newLocation.position.y, transform.position.z);
    //                canVault = true;
    //            }
                
               
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "VaultObject")
    //    {
    //        canVault = false;
    //    }
    //}

}
