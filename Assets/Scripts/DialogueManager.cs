using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

    public GameObject DBox;
    public Text DText;

    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;

    private PlayerKidController thePlayer;



	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerKidController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            //DBox.SetActive(false);
            //dialogueActive = false;
            currentLine++;
        }

        if(currentLine >= dialogueLines.Length)
        {
            DBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
           // thePlayer.canMove = true;
        }
        DText.text = dialogueLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        DBox.SetActive(true);
        //thePlayer.canMove = false;
        DText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        DBox.SetActive(true);
    }


}
