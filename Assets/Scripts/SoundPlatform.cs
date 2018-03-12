using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlatform : MonoBehaviour {

	bool HasPlayed;
	AudioSource Note;
	public int NoteNumber;
	int check = 0;

	// Use this for initialization
	void Start () {
		HasPlayed = false;
		Note = GetComponent<AudioSource>();
	}

	public int OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			Note.Play();
			HasPlayed = true;
			check = NoteNumber;
		}
		return check;
	}


	// Update is called once per frame
	void Update () {
		
	}
}
