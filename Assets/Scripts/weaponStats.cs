using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public float armourPen;
    public bool canDamage = true; //set to false after hitting a target or being on the backswing to stop attacks dealing damage multiple times or dealing damage during animation winddown
    public BoxCollider weaponCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        damageInterface iDamage = other.GetComponent<damageInterface>();
        if(iDamage != null && canDamage)
        {
            iDamage.takeDamage(damage);
        }
    }
}
