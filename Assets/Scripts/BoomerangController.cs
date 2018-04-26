using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour {

    public float boomerangSpeed;

    public bool facingRight;

    bool isFacingRight;

	int facing;

    public GameObject boomerangSprite;

    Rigidbody2D myRB;

	Rigidbody2D PlayerRB;

	// Use this for initialization
	void Start() {
		myRB = GetComponent<Rigidbody2D>();
		PlayerRB = FindObjectOfType<PlayerKidController>().GetComponent<Rigidbody2D>();
		//isFacingRight = facingRight;
       
        SetDirection();
    }

    void SetDirection()
    {
		if (facingRight == true) facing = 1;
		else facing = -1;

		myRB.velocity = (new Vector2(facing, 0) * boomerangSpeed + PlayerRB.velocity/2);
    }

    // Update is called once per frame
    void Update () {
		if (boomerangSprite)
		{
			if (facingRight == true)
			{
				boomerangSprite.transform.localScale = new Vector3(-1, -1, z: -1);
			}
		}
		SetSpeed();
		if (myRB.position.x < PlayerRB.position.x) facing = -1;
		else facing = 1;
    }

	void SetSpeed()
	{
		myRB.velocity = new Vector2 (myRB.velocity.x - 0.3f*facing, (myRB.velocity.y + PlayerRB.velocity.y)/2);
	}

	public void RemoveForce()
    {
        myRB.velocity = new Vector2(0, 0);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (((facingRight && myRB.velocity.x < 0) || (!facingRight && myRB.velocity.x > 0)) && collision.gameObject.tag == "Player")
		{
			collision.GetComponent<PlayerKidController>().CanShoot = true;
			collision.GetComponent<KidHealth>().SurvivingBoomerang = null;
			Destroy(gameObject);
		}
	}

	public void ResetCanShoot()
	{ PlayerRB.gameObject.GetComponent<PlayerKidController>().CanShoot = true; }

}
