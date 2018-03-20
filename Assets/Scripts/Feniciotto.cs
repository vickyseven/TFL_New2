using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feniciotto : MonoBehaviour {
	bool IsOn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsOn && Input.GetButtonDown("Interact"))
		{
			FindObjectOfType<GameController>().HasSmallPhoenix = true;
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IsOn = true;
	}

	private void OnTriggerExit(Collider other)
	{
		IsOn = false;
	}
}
