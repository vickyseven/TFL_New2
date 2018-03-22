using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager DMan;
	bool DialogueActive = false;
	bool OnDialogueZone = false;
	public bool DialogueOver = false;
	public bool AutoStart;
	bool ManualStart;

	public string[] dialogueLines;

	// Use this for initialization
	void Start ()
	{
		if (GetComponent<MeshRenderer>()) GetComponent<MeshRenderer>().sortingLayerName = "UI";
	}

	// Update is called once per frame
	void Update ()
	{
		if (!DialogueOver && DialogueActive && !DMan.dialogueActive)
		{
			DialogueOver = true;
			DialogueActive = false;
			ManualStart = false;
		}
		if (!DialogueOver && OnDialogueZone && !AutoStart && !ManualStart && Input.GetKeyDown(KeyCode.E))
		{
			ManualStart = true;
			ShowDialogue();
		}
		else if (DialogueOver && OnDialogueZone && !AutoStart && !ManualStart && Input.GetKeyDown(KeyCode.E))
		{
			DialogueOver = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			DMan = FindObjectOfType<DialogueManager>();
			OnDialogueZone = true;
			GetComponent<AudioSource>().Play();
			if (GetComponent<MeshRenderer>()) GetComponent<MeshRenderer>().enabled = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			DMan = null;
			OnDialogueZone = false;
			DialogueActive = false;
			ManualStart = false;
			if (GetComponent<MeshRenderer>()) GetComponent<MeshRenderer>().enabled = false;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(!DialogueOver && other.gameObject.tag == "Player" && AutoStart)
		{
			{
				ShowDialogue();
			}
		}
	}

	void ShowDialogue()
	{
		DialogueActive = true;
		DMan.dialogueLines = dialogueLines;
		DMan.ShowBox(dialogue);
	}

}
