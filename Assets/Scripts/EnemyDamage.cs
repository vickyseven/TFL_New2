﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

	// Use this for initialization
	void Start () {
        nextDamage = 0f;
    
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            KidHealth theKidHealth = other.gameObject.GetComponent<KidHealth>();
            theKidHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }

       
            if (other.tag == "Player" && nextDamage < Time.time) { 
            FoxKidHealth theFoxKidHealth = other.gameObject.GetComponent<FoxKidHealth>();
            theFoxKidHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.x - transform.position.x)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
