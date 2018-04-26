using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttacks : MonoBehaviour {
	GameObject Target = null;
	public GameObject fireFX;
	public Quaternion FXrotation;
	public Animator FireAnim;

	// Use this for initialization
	void Start () {
		FireAnim = GetComponent<Animator>();
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
		FireAnim.SetBool("CastFire", true);
		//		Instantiate(fireFX, transform.position + Offset, FXrotation);

		if (Target)
		{
			DestroyObject(Target);
		}
	}
}
