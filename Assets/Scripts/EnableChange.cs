using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChange : MonoBehaviour {
	PlayerKidController PlayerController;
	DialogueHolder Holder;
	// Use this for initialization
	void Start () {
		PlayerController = FindObjectOfType<PlayerKidController>();
		Holder = gameObject.GetComponentInChildren<DialogueHolder>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Holder.DialogueOver == true)
		{
			UnlockShapeshift();
		}
	}

	void UnlockShapeshift()
	{
		PlayerController.CanChange = true;
	}
}
