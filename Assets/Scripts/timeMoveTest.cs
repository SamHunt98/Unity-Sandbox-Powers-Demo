using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeMoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidBody;
    public globalTimeScript time;
    public float currentSpeed;
    public Vector3 velocityStorage;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onFreezeTime()
    {
        velocityStorage = rigidBody.velocity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
    }
    public void onStartTime()
    {
        
        rigidBody.velocity = velocityStorage;
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
    }
}
