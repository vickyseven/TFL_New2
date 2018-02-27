using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttacks : MonoBehaviour {
	GameObject Target = null;
	public GameObject fireFX;
	public Quaternion FXrotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "DestructibleByFire") Target = other.gameObject;
	}

	public void FireAttack()
	{
		if (Target)
		{
			Instantiate(fireFX, transform.position - new Vector3 (1.5f,0,0), FXrotation);
			DestroyObject(Target);
		}
	}
}
