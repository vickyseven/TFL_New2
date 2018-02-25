using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSetup : MonoBehaviour
{
	public Transform RespawnLocation;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			KidHealth theKidHealth = other.gameObject.GetComponent<KidHealth>();
			theKidHealth.Checkpoint = RespawnLocation.position;

		}
	}

}
