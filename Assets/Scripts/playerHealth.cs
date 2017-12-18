﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float maxHealth;
    public GameObject deathFX;

    public float currentHealth;

    playerController controlMovement;

    //HUD Variables
    public Slider healthSlider;

    // Use this for initialization
    void Start() {
        currentHealth = maxHealth;
        controlMovement = GetComponent<playerController>();


        //HUD Initialization
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

    }

    // Update is called once per frame
    void Update() {

    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth = currentHealth - damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();

        }
    }
    public void makeDead() {
    Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
