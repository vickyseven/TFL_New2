using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	public Vector3 StashedCharLoc;
	GameObject Player;
	public bool IsInCave;
	bool HasBeenInCave = false;
	bool OutTheCave = false;
	float currenttime;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		StashedCharLoc = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!HasBeenInCave && IsInCave) HasBeenInCave = true;
		else if (!OutTheCave && HasBeenInCave && !IsInCave) { OutTheCave = true; currenttime = Time.time; }
		else if (OutTheCave) OutOfCave();
	}

	public void UpdatePlayer(GameObject NewPlayer)
	{
		Player = NewPlayer;
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
	}

}
