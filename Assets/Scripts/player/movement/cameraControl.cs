using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {



    public float mouseSensitivity = 100f;
    public bool canControl;
    public Transform playerCharacter;

    float xRotation = 0f;
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	

	void Update ()
    {
        #region GET_INPUTS

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        #endregion
        #region APPLY_MOVEMENT
        if(canControl)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -70f, 60f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerCharacter.Rotate(Vector3.up * mouseX);
        }
   
        #endregion

    }

    public void startVaulting()
    {
        canControl = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        xRotation = 0;
    }
    public void endVaulting()
    {
        canControl = true;
    }
}
