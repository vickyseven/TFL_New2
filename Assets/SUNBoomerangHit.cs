using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUNBoomerangHit : MonoBehaviour {

    public float WeaponDamage;

    SUNboomerang myBC;

    public GameObject explosionEffect;

    // Use this for initialization
    void Awake(){
        myBC = GetComponentInParent<SUNboomerang>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myBC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealth enemyDamage = other.gameObject.GetComponent<EnemyHealth>();
                enemyDamage.addDamage(WeaponDamage);
            }
        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myBC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealth enemyDamage = other.gameObject.GetComponent<EnemyHealth>();
                enemyDamage.addDamage(WeaponDamage);
            }
        }
    }


}

