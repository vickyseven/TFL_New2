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
	bool SequencedListening;
	float Entertime;
	PlayerKidController PlayerContr;
	int k = 0;
	// Use this for initialization
	void Start () {
		SequencedListening = false;
		SequenceLength = TargetSequence.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (SequencedListening && FirstListening)
		{
			PlayerContr.CanMove = false;
			Sounds[TargetSequence[0]].Play();
			Entertime = Time.time +0.5f;
			FirstListening = false;
			k=1;
				
			//				if (k < SequenceLength) k++;
			//				else if (k == SequenceLength)
			//{
			//SequencedListening = false;
			//k = 0;
			//PlayerContr.CanMove = true;
			//return;
			//}
		}
		else if (SequencedListening && Time.time > Entertime + 0.5f)
		{
			Sounds[TargetSequence[k]].Play();
			Entertime = Time.time;
			if (k < SequenceLength) k++;
			else if (k == SequenceLength)
			{
				SequencedListening = false;
				k = 0;
				PlayerContr.CanMove = true;
				return;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PlayerContr = other.gameObject.GetComponent<PlayerKidController>();
			Entertime = Time.time; SequencedListening = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			SequencedListening = false;
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
		else i = 0; return;
		}
		IsComplete = true;
		PlayerContr.CanMove = true;
		Destroy(gameObject, 1.5f);
	}
}
