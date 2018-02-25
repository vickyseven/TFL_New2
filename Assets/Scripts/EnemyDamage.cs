using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;
	public bool IsHitting;
    float nextDamage;
	KidHealth PlayerHealth;

	// Use this for initialization
	void Start ()
	{
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (IsHitting && nextDamage < Time.time)
		{
			PlayerHealth.addDamage(damage);
			nextDamage = Time.time + damageRate;
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			IsHitting = true;
			PlayerHealth = other.gameObject.GetComponent<KidHealth>();
			pushBack(PlayerHealth.gameObject.transform);
		}
	}

//	void OnTriggerStay2D(Collider2D other) { }

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			IsHitting = false;
			PlayerHealth = null;
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
