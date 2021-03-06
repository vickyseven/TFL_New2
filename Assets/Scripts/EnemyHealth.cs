﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float enemyMaxHealth;

    public GameObject enemyDeathFX;

    public Slider Enemyhealthslider;

    float currentHealth;

    public bool drops;

    public GameObject theDrop;


	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        Enemyhealthslider.maxValue = enemyMaxHealth;
        Enemyhealthslider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        currentHealth -= damage;
        Enemyhealthslider.value = currentHealth;

        if (currentHealth <= 0) makeDead();
        
    }

    void makeDead() //visual and sound effect when enemy dies
    {
        Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) Instantiate(theDrop, (transform.position + new Vector3 (0,6,0)), transform.rotation);
    }
}
