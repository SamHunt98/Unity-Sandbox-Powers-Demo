using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;

    public float maxMana;
    public float currentMana;


	void Start ()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
       
	}
	

}
