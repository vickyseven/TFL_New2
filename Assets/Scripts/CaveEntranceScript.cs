using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveEntranceScript : MonoBehaviour {
	public Transform SpawnPosition;
	public bool IsOn;
	Scene Cave;
	GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			IsOn = true;
			SceneManager.LoadScene("TFL_CAVE1");
			Cave = SceneManager.GetSceneByName("TFL_CAVE1");
			Player = other.gameObject;
//			SceneManager.MoveGameObjectToScene(Player, Cave);
//			SceneManager.SetActiveScene(Cave);
		}
	}

	
}
