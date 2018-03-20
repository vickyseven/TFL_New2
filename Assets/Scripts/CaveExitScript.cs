using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveExitScript : MonoBehaviour
{
	public bool IsOn;
//	Scene LVL1;
//	GameObject Player;
	GameController GameContr;
	// Use this for initialization
	void Start()
	{
		GameContr = FindObjectOfType<GameController>();
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			IsOn = true;
			SceneManager.LoadScene("TFL_LVL1");
//			LVL1 = SceneManager.GetSceneByName("TFL_LVL1");
//			Player = other.gameObject;
			GameContr.IsInCave = false;
			//			SceneManager.MoveGameObjectToScene(Player, Cave);
			//			SceneManager.SetActiveScene(Cave);
		}
	}


}
