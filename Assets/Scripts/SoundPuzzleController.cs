using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPuzzleController : MonoBehaviour {
	public int[] PlayedSequence = new int [5];
	public int[] TargetSequence = new int[5];
	public int i = 0;
	public AudioSource[] Sounds = new AudioSource [5];
	public bool SequencedListening;
	public float Entertime;
	int k = 0;
	// Use this for initialization
	void Start () {
		SequencedListening = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (SequencedListening && Time.time > Entertime + 0.5f)
		{
			Sounds[TargetSequence[k]].Play();
			Entertime = Time.time;
			if (k < 4) k++;
			else if (k == 4)
			{
				SequencedListening = false;
				k = 0;
				return;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Entertime = Time.time; SequencedListening = true;
		}
	}

	public void NotePlayed (int Note)
	{
		if (i < 4)
		{
			PlayedSequence[i] = Note;
			i++;
		}
		else if (i==4)
		{
			PlayedSequence[4] = Note;
			CheckSequence();
		}
	}

	public void CheckSequence()
	{
		for (int k = 0; k < 4; k++)
		{
			if (PlayedSequence[k] == TargetSequence[k])
			{
				continue;
			}
		else i = 0; return;
		}
		Destroy(gameObject, 1.5f);
	}
}
