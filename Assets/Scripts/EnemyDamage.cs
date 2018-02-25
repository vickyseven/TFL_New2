using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;
	public bool IsAttacking;

    float nextDamage;

	// Use this for initialization
	void Start ()
	{
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") IsAttacking = true;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage < Time.time)
		{
			IsAttacking = true;
			KidHealth theKidHealth = other.gameObject.GetComponent<KidHealth>();
			theKidHealth.addDamage(damage);
			nextDamage = Time.time + damageRate;
			pushBack(other.transform);
		}

	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			IsAttacking = false;
		}
	}

	void pushBack(Transform pushedObject)
	{
		Vector2 pushDirection = new Vector2((pushedObject.position.x - transform.position.x), 0).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
	}
}
