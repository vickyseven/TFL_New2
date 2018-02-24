using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_TriggerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //When entering the trigger zone of the flower in fox form
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<FoxKidHealth>().makeDead();
    }

    //When staying in the trigger zone of the flower in fox form
    void OnTriggerStay2D(Collider2D other)
    {

    }

    //When exiting the trigger zone of the flower in fox form
    void OnTriggerExit2D(Collider2D other)
    {

    }
}
