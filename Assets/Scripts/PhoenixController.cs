﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixController : MonoBehaviour {

	public DialogueHolder DHold;
	public GameObject SpiritVanishFX;
	GameController GameContr;

	// Use this for initialization
	void Start()
	{
		GameContr = FindObjectOfType<GameController>();
		if (GameContr.HasSmallPhoenix)
		{
			DHold.dialogueLines = new string[] { "Thank you for bringing back my baby, Red.", "I wish you luck in your travels. Farewell!" };
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(DHold.DialogueOver && GameContr.HasSmallPhoenix)
		{
			Instantiate(SpiritVanishFX, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
