using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarHealth : MonoBehaviour {

    public float boarMaxHealth;

    float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = boarMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead() //visual and sound effect when enemy dies
    {
        Destroy(gameObject);
    }
}
