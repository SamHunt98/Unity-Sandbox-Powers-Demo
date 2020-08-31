using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutCameraControl : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        #region GET_INPUTS

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        #endregion
        #region APPLY_MOVEMENT
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 60f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        #endregion
    }
}
