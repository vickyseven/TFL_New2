using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlatform : MonoBehaviour {

	bool HasPlayed;
	AudioSource Note;
	public int NoteNumber;
	int check = -1;
	public SoundPuzzleController PuzzleController;

	// Use this for initialization
	void Start () {
		HasPlayed = false;
		Note = GetComponent<AudioSource>();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && HasPlayed == false) 
		{
			Note.Play();
			HasPlayed = true;
			check = NoteNumber;
			PuzzleController.NotePlayed(check);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") HasPlayed = false;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
