using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	public Vector3 StashedCharLoc;
	GameObject Player;
	public bool IsInCave;
	bool HasBeenInCave = false;
	bool OutTheCave = false;

//	float currenttime;
	float currenttime;
	public float StashedHealth;
	public int StashedSoulCount;
	public bool HasSmallPhoenix;
	public bool CanChange;
	public bool CanFire;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		StashedCharLoc = new Vector3(0, 0, 0);
		StashedHealth = 70f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!HasBeenInCave && IsInCave) HasBeenInCave = true;
		else if (!OutTheCave && HasBeenInCave && !IsInCave) { OutTheCave = true;}
		else if (OutTheCave) OutOfCave();
	}

	public void UpdatePlayer(GameObject NewPlayer)
	{
		Player = NewPlayer;
		Player.GetComponent<KidHealth>().currentHealth = StashedHealth;
		Player.GetComponent<PlayerKidController>().SoulsCollected = StashedSoulCount;
		Player.GetComponent<PlayerKidController>().CanChange = CanChange;
		Player.GetComponent<PlayerKidController>().CanElementalAttack = CanFire;
	}

	public void SetPlayerPosition(Vector3 PlayerLoc)
	{
		Player.transform.position = PlayerLoc;
	}

	public void OutOfCave()
	{

		SetPlayerPosition(StashedCharLoc);
		HasBeenInCave = false;
		OutTheCave = false;
		CanChange = true;
		CanFire = true;
	}

}
