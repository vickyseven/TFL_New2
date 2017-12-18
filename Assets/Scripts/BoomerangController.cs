using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour {

    public float boomerangSpeed;

    public bool facingRight;

    bool isFacingRight;

    public GameObject boomerangSprite;

    Rigidbody2D myRB;

	// Use this for initialization
	void Start() {
        myRB = GetComponent<Rigidbody2D>();
        isFacingRight = facingRight;
        //        if(transform.rotation.z>0)
        SetDirection();
    }

    void SetDirection()
    {
        if (facingRight == true)
            myRB.AddForce(new Vector2(1, 0) * boomerangSpeed, ForceMode2D.Impulse);
        else myRB.AddForce(new Vector2(-1, 0) * boomerangSpeed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update () {

        if (facingRight == true)
        {
            boomerangSprite.transform.localScale = new Vector3(-1, -1, z: -1);
        }

    }
    public void RemoveForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }
}
