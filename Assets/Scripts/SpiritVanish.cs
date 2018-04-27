using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritVanish : MonoBehaviour {

	public DialogueHolder DHold;
	public GameObject SpiritVanishFX;
	bool IsOver = false;

	// Use this for initialization
	void Start()
	{
		//DHold = FindObjectOfType<DialogueHolder>();
	}

// Update is called once per frame
	void Update()
	{
	if(DHold.DialogueOver == true && IsOver == false)
		{
			Vanish();
		}
	}

	void Vanish()
	{
		IsOver = true;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
		Instantiate(SpiritVanishFX, transform.position, transform.rotation);
		Destroy(gameObject, 0.5f);
	}
}
