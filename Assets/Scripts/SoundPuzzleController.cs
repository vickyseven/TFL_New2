using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPuzzleController : MonoBehaviour {
	int[] PlayedSequence = new int [5];
	public int[] TargetSequence = new int[5];
	bool FirstListening = true;
	int SequenceLength;
	int i = 0;
	public AudioSource[] Sounds = new AudioSource [5];
	public bool IsComplete = false;
	bool SequenceListening;
	float Entertime;
	PlayerKidController PlayerContr;
	int k = 0;
	// Use this for initialization
	void Start () {
		SequenceListening = false;
		SequenceLength = TargetSequence.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (SequenceListening && FirstListening)
		{
			PlayerContr.CanMove = false;
			Sounds[TargetSequence[0]].Play();
			Entertime = Time.time;
			FirstListening = false;
			k=1;
		}
		else if (SequenceListening && Time.time > Entertime + 0.5f)
		{
			Sounds[TargetSequence[k]].Play();
			Entertime = Time.time;
			if (k < SequenceLength) k++;
			else if (k == SequenceLength)
			{
				k = 0;
				PlayerContr.CanMove = true;
				SequenceListening = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerContr = other.gameObject.GetComponent<PlayerKidController>();
			Entertime = Time.time;
			if (FirstListening) SequenceListening = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			SequenceListening = false;
			FirstListening = true;
		}
	}

		public void NotePlayed (int Note)
	{
		if (i < SequenceLength)
		{
			PlayedSequence[i] = Note;
			i++;
		}
		else if (i== SequenceLength)
		{
			PlayedSequence[SequenceLength] = Note;
			CheckSequence();
		}
	}

	public void CheckSequence()
	{
		for (int k = 0; k < SequenceLength; k++)
		{
			if (PlayedSequence[k] == TargetSequence[k])
			{
				continue;
			}
		else i = 0; k = 0; return;
		}
		IsComplete = true;
		PlayerContr.CanMove = true;
		Destroy(gameObject, 0.5f);
	}
}
