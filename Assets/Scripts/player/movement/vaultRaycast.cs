using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaultRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    public float raycastLength;
    RaycastHit hit;
    public LayerMask groundLayer;
    public playerVault vaultScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, transform.up * -1, out hit, raycastLength, groundLayer);
        Debug.DrawRay(transform.position, transform.up * (raycastLength * -1),Color.red);
        if(hit.collider != null && !vaultScript.isVaulting)
        {
            if(hit.transform.parent != null)
            {
                GameObject parent = hit.transform.parent.gameObject;
                //Debug.Log(hit.collider.name + " is a child of " + parent.name + " and hit at " + hit.point);
                vaultScript.frontRayCast(parent, hit.point);
            }
            else
            {
                //GameObject parent = hit.transform.parent.gameObject;
                //Debug.Log(hit.collider.name + " is a child of " + parent.name + " and hit at " + hit.point);
                vaultScript.frontRayCast(hit.transform.gameObject, hit.point);
            }
        ;
        }
        else
        {
            vaultScript.canVault = false;
        }
    }
}
