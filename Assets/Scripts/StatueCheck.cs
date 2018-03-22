using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueCheck : MonoBehaviour {
	PlayerKidController PlayerContr;
	public int RequiredSouls;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetButtonDown("Interact") && PlayerContr.SoulsCollected >= RequiredSouls)
			{
				GetComponent<Animator>().SetBool ("CollectionCompleted", true);
			}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			PlayerContr = collision.GetComponent<PlayerKidController>();
		}
	}
}
