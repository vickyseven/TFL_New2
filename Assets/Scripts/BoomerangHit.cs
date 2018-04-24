using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangHit : MonoBehaviour {

    public float WeaponDamage;

    BoomerangController myBC;

    public GameObject explosionEffect;

	// Use this for initialization
	void Awake () {
        myBC = GetComponentInParent<BoomerangController>();
		
	}

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
            {
//				myBC.RemoveForce();
			    Instantiate(explosionEffect, transform.position, transform.rotation);
				if(other.tag == "Enemy")
					{
						EnemyHealth enemyDamage = other.gameObject.GetComponent<EnemyHealth>();
						enemyDamage.addDamage(WeaponDamage);
						EnemyMovementController EnemyControl = other.gameObject.GetComponentInParent<EnemyMovementController>();
						EnemyControl.Stun();
					}
			}


	}
	//    private void OnTriggerStay2D(Collider2D other)
	//    {
	//        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
	//        {
	//myBC.RemoveForce();
	//		Instantiate(explosionEffect, transform.position, transform.rotation);
	//        if (other.tag == "Enemy")
	//        {
	//EnemyHealth enemyDamage = other.gameObject.GetComponent<EnemyHealth>();
	//enemyDamage.addDamage(WeaponDamage);
	//}
	//}
	//}


}
