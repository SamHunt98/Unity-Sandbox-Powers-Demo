using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerInLightRadius : MonoBehaviour
{
    // Start is called before the first frame update
    public SphereCollider collider;
    public GameObject player;
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject == player)
        {
            player.GetComponent<isInLight>().lights.Add(this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject == player)
        {
            player.GetComponent<isInLight>().lights.Remove(this.gameObject);
        }
    }
}
