using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCheck : MonoBehaviour {
	PlayerKidController PlayerController;
	// Use this for initialization
	void Start () {
		PlayerController = FindObjectOfType<PlayerKidController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.groundCheck.transform.position.y > gameObject.GetComponent<BoxCollider2D>().transform.position.y)
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
		else gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
}
