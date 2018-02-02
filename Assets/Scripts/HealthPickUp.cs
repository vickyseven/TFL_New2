using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    public float healthAmount;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            KidHealth theHealth = other.gameObject.GetComponent<KidHealth>();
            theHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            FoxKidHealth theHealth = other.gameObject.GetComponent<FoxKidHealth>();
            theHealth.addHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
