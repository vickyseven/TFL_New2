using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
        Essentially what its doing now is when player hits the 
        smaller box collider on the plant while being in the 
        trigable box collider it disables the players collider 
        and players falls out world.
         */
    void OnTriggerEnter2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Entered collider");
            other.GetComponent<Collider2D>().enabled = !other.GetComponent<Collider2D>().enabled;
        }
    }
    

    void OnTriggerStay2D(Collider2D other)
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {

    }
}
