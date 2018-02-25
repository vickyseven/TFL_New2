using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerAndRespawn : MonoBehaviour {
	BoxCollider2D CollisionZone;
	public Transform RespawnLocation;
	// Use this for initialization
	void Start ()
	{
		CollisionZone = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			KidHealth theKidHealth = other.gameObject.GetComponent<KidHealth>();
			theKidHealth.Checkpoint = RespawnLocation.position;
			theKidHealth.makeDead();

		}
	} 
	
}
