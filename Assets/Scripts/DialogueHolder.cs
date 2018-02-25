using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager DMan;

    public bool DialogueOver;

    public string[] dialogueLines;

	// Use this for initialization
	void Start () {
        DMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!DMan.dialogueActive) { 
            DialogueOver = true;
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "PlayerKid")
        {
            {
                DMan.dialogueLines = dialogueLines;
                DMan.ShowBox(dialogue);

            }

        }
    }

}
