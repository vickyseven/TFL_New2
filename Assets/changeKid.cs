using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeKid : MonoBehaviour {


    GameObject RedKid, FoxKid;
    int characterselect;

    // Use this for initialization
    void Start () {
        characterselect = 1;
        RedKid = GameObject.Find("RedKid");
        FoxKid = GameObject.Find("FoxKid");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Change"))
        {
            if (characterselect == 1)
            {
                characterselect = 2;
            }
            else if (characterselect == 2)
            {
                characterselect = 1;
            }
        }
        if (characterselect == 1)
        {
            RedKid.SetActive(true);
            FoxKid.SetActive(false);
        }
        else if (characterselect == 2)
        {
            RedKid.SetActive(false);
            FoxKid.SetActive(true);
        }

    }
}
