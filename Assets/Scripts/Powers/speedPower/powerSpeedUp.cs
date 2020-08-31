using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerSpeedUp : basePower
{
    // Start is called before the first frame update
    playerMovement movement;
    public float duration;
    void Start()
    {
        
    }
    public void Awake()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Execute()
    {
        if(canUse)
        {
            movement.speedModifier = 1.5f;
            canUse = false;
            StartCoroutine(waitDuration());
        }      
    }

    IEnumerator waitDuration()
    {
        yield return new WaitForSeconds(duration);
        movement.speedModifier = 1f;
        canUse = true;
    }
}
