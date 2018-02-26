using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttacks : MonoBehaviour {
	GameObject Target = null;
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
		if (Target) DestroyObject(Target);
	}
}
