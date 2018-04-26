using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {
	public Camera NewCamera;
	Camera OldCamera;

	// Use this for initialization
	void Start () {
		OldCamera = FindObjectOfType<PlayerKidController>().GetComponentInChildren<Camera>();
		NewCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OldCamera.enabled = false;
		NewCamera.enabled = true;
	}
}
