using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWindProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileDuration;
    float secondsTravelled;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += (this.transform.forward * projectileSpeed * Time.deltaTime);
        secondsTravelled += Time.deltaTime;
        if (secondsTravelled >= projectileDuration)
        {
            Destroy(this.gameObject);
        }
    }
}
