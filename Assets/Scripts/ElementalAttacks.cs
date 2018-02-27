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
		Vector3 Offset = new Vector3(0,0,0);
		if (FXrotation == new Quaternion(0, 0, 0, 0)) Offset = new Vector3(-1.75f, 0, 0);
		else if (FXrotation == new Quaternion(0, 180, 0, 0)) Offset = new Vector3(1.75f, 0, 0);

		Instantiate(fireFX, transform.position + Offset, FXrotation);

		if (Target)
		{
			DestroyObject(Target);
		}
	}
}
