using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barSwinging : MonoBehaviour
{
   
    public GameObject playerChar;
    public Camera playerCamera;
    public bool canSwing = false;
    public bool isCooldown = false;
    public float forceToAdd = 100;
    public LayerMask triggerMask;
    cameraControl controlCamera;
    Vector3 hitNormal;
    Rigidbody rigidbody;
    void Start()
    {
        //triggerMask = 1 << 15;
        rigidbody = playerChar.GetComponent<Rigidbody>();
        controlCamera = playerCamera.gameObject.GetComponent<cameraControl>();

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) & canSwing & !isCooldown)
        {
            swingPlayer();
        }
    }

    void swingPlayer()
    {
        if(wallRaycast())
        {
            Debug.Log("Will swing now");
            playerChar.transform.rotation = Quaternion.LookRotation(-hitNormal);
            controlCamera.startVaulting();
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(playerChar.transform.forward * forceToAdd);
            isCooldown = true;
            StartCoroutine(swingCooldown());
        }

    }
    bool wallRaycast()
    {
        //gets a raycast to the invisible wall object inside the swing - allows a normal to be found so that the character can turn to face the bar when they swing
        RaycastHit hit;
        
        if(Physics.Raycast(playerChar.transform.position, playerChar.transform.forward,out hit,10f,triggerMask))
        {
            hitNormal = hit.normal;
            Debug.Log("can swing");
            return true;
           
        }
        else
        {
            Debug.Log("cant swing");
            return false;
        }
        
       
    }
    IEnumerator swingCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        controlCamera.endVaulting();

        rigidbody.useGravity = true;
        yield return new WaitForSeconds(0.5f);
        isCooldown = false;
        Debug.Log("Can swing again");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerChar)
        {
            canSwing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerChar)
        {
            canSwing = false;
        }
    }
}
