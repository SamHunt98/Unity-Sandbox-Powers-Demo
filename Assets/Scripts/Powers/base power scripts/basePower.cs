using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class basePower : MonoBehaviour
{
    public string powerName;
    public float manaCost;
    //public float usesLeft;
    public float rechargeTime;
    public bool canUse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Execute();
  
}
