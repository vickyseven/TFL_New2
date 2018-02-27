using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_SoulCounter : MonoBehaviour {
	PlayerKidController Player;
	public Text Text;
	public int MaximumSouls = 10;
	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<PlayerKidController>();
		Text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		string CurrentSouls;
		CurrentSouls = Player.SoulsCollected.ToString();
		if (Player.SoulsCollected <= MaximumSouls) Text.text=  CurrentSouls + " / " + MaximumSouls.ToString();
	}
}
