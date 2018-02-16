using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Trigger : MonoBehaviour {

    public Death_Trigger deathtrigger;

	// Use this for initialization
	void Start () {
        deathtrigger.GetComponent<KidHealth>().makeDead();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
