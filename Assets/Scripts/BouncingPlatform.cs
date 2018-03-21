using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour {
	Animator Anim;
	PlayerKidController Player;
	public float JumpHeight = 75f;
	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Player = collision.GetComponent<PlayerKidController>();
			Anim.SetBool("IsBouncing", true);
			Player.myRB.velocity = new Vector2 (Player.myRB.velocity.x, JumpHeight);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Player = collision.GetComponent<PlayerKidController>();
			Anim.SetBool("IsBouncing", false);
		}
	}
}
