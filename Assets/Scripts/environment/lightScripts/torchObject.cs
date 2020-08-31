using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchObject : MonoBehaviour, windPowerInterface
{
    // Start is called before the first frame update
    public GameObject light; //the light detection doesn't appreciate the it if the light is a child object, so each torch will need a reference to the light on it
    void Start()
    {
       
    }
    public void gentleWind()
    {
        Debug.Log("haha hi");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<isInLight>().lights.Remove(light);
        GameObject.Destroy(light.gameObject);
    }

    public void strongWind()
    {
        GameObject.Destroy(light);
    }
}
