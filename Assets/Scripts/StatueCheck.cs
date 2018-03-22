using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StatueCheck : MonoBehaviour {
	PlayerKidController PlayerContr;
	public int RequiredSouls;
	float EndTime;
	bool IsLevelEnding;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsLevelEnding && Time.time >= EndTime) SceneManager.LoadScene("TFL_MENU");
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetButtonDown("Interact") && PlayerContr.SoulsCollected >= RequiredSouls)
			{
				GetComponent<Animator>().SetBool ("CollectionCompleted", true);
			}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			PlayerContr = collision.GetComponent<PlayerKidController>();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (GetComponent<Animator>().GetBool("CollectionCompleted"))
		{
			IsLevelEnding = true;
			GetComponent<VideoPlayer>().enabled = true;
			EndTime = Time.time + (float)GetComponent<VideoPlayer>().clip.length*3f;
			PlayerContr.CanMove = false;
		}

	}
}
