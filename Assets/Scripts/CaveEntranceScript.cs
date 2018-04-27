using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveEntranceScript : MonoBehaviour {
	Vector3 SpawnPosition;
	public Transform SpawnTransform;
	public bool IsOn;
//	Scene Cave;
	GameObject Player;
	GameController GameContr;
	// Use this for initialization
	void Start () {
		GameContr = FindObjectOfType<GameController>();
		SpawnPosition = SpawnTransform.position;
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
//			Cave = SceneManager.GetSceneByName("TFL_CAVE1");
			Player = other.gameObject;
			GameContr.StashedCharLoc = SpawnPosition;
			GameContr.IsInCave = true;
			GameContr.StashedHealth = Player.GetComponent<KidHealth>().currentHealth;
			GameContr.StashedSoulCount = Player.GetComponent<PlayerKidController>().SoulsCollected;
			GameContr.CanFire = Player.GetComponent<PlayerKidController>().CanElementalAttack;
			GameContr.CanChange = Player.GetComponent<PlayerKidController>().CanChange;
//			SceneManager.MoveGameObjectToScene(Player, Cave);
//			SceneManager.SetActiveScene(Cave);
		}
	}

	
}
