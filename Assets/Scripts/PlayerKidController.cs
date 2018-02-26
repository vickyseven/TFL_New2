using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKidController : MonoBehaviour {

	//character select
	GameObject RedKid, FoxKid;
	int characterselect;

	//movement variables
	public float KidmaxSpeed;
	public float FoxmaxSpeed;
	public bool CanMove;
	bool facingRight;

	//jumping variables
	bool grounded = false;
	float groundCheckCircle = 0.5f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public GameObject ForwardCheck;
	public float KidjumpHeight;
	public float FoxjumpHeight;

	//Colliders
	Rigidbody2D myRB;
	BoxCollider2D PlayerCollider;
	//Animators
	Animator ActiveAnim;
	Animator myKidAnim;
	Animator myFoxAnim;

	//for shooting boomerang
	public Transform handTip;
	public GameObject boomerang;
	float fireRate = 0.44f;
	float nextFire = 0f;
	bool shooting = false;

	//collection and point systems
	UI_SoulCounter HUDSoulCounter;
	public int SoulsCollected = 0;

	// Use this for initialization
	void Start()
	{
		HUDSoulCounter = FindObjectOfType<UI_SoulCounter>();

		//character select
		RedKid = GameObject.Find("RedKid");
		FoxKid = GameObject.Find("FoxKid");


		myRB = GetComponent<Rigidbody2D>();
		myKidAnim = RedKid.GetComponent<Animator>();
		//FOX
		myFoxAnim = FoxKid.GetComponent<Animator>();
		facingRight = true;
		characterselect = 1;

		PlayerCollider = GetComponent<BoxCollider2D>();

		RedKid.SetActive(true);
		FoxKid.SetActive(false);
		ActiveAnim = myKidAnim;
		CanMove = true;
	}


	// Update is called once per frame
	private void Update()
	{
		if (!CanMove)
		{
			myRB.velocity = new Vector2 (0,0);
			return;
		}
		if (shooting == false && grounded && Input.GetAxis("Jump") > 0)
		{
			grounded = false;
			ActiveAnim.SetBool("isGrounded", grounded);

			if (characterselect == 1)
				myRB.AddForce(new Vector2(0, KidjumpHeight));
			if (characterselect == 2)
				myRB.AddForce(new Vector2(0, FoxjumpHeight));

		}

		//player shooting
		if (characterselect == 1)
		{
			if (Input.GetAxisRaw("Fire1") > 0) FireBoomerang();
			else if (Time.time > (nextFire+fireRate) && Input.GetAxisRaw("Fire1") == 0)
			{
				shooting = false;
				ActiveAnim.SetBool("isShooting", shooting);
			}
		}


	}

	void FixedUpdate()
	{


		//character select
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
			ActiveAnim = myKidAnim;
			myRB.mass = 1;
			PlayerCollider.size = (new Vector2(1.2f,3.6f));
			PlayerCollider.offset = (new Vector2(0.7f, -4.6f));
		}
		else if (characterselect == 2)
		{
			RedKid.SetActive(false);
			FoxKid.SetActive(true);
			ActiveAnim = myFoxAnim;
			myRB.mass = 0.5f;
			PlayerCollider.size = (new Vector2(2.8f, 1.6f));
			PlayerCollider.offset = (new Vector2(0.85f, -5.5f));
		}

		//check if we are grounded - if not, we are falling
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
		ActiveAnim.SetBool("isGrounded", grounded);
		ActiveAnim.SetFloat("verticalSpeed", myRB.velocity.y);

		//movement
		if (shooting == false)
		{
			if (!CanMove)
			{
				myRB.velocity = Vector2.zero;
				ActiveAnim.SetFloat("speed", 0f);
				return;
			}

			float move = Input.GetAxis("Horizontal");
			ActiveAnim.SetFloat("speed", Mathf.Abs(move));

			if (characterselect == 1)
				myRB.velocity = new Vector2(move * KidmaxSpeed, myRB.velocity.y);

			else if (characterselect == 2)
				myRB.velocity = new Vector2(move * FoxmaxSpeed, myRB.velocity.y);

			if (move > 0 && !facingRight)
			{
				flip();
			}
			else if (move < 0 && facingRight)
			{
				flip();
			}
		}

		//fire attack
		if (Input.GetButtonDown("FireAttack"))
		{
			ForwardCheck.GetComponent<ElementalAttacks>().FireAttack();
		}
	}
	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void FireBoomerang()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			if (facingRight)
			{
				GameObject RightBoomerang = Instantiate(boomerang, handTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
				RightBoomerang.GetComponent<BoomerangController>().facingRight = true;
			}
			else if (!facingRight)
			{
				GameObject LeftBoomerang = Instantiate(boomerang, handTip.position, Quaternion.Euler(new Vector3(0, 0, -180f)));
				LeftBoomerang.GetComponent<BoomerangController>().facingRight = false;
			}

			{
				shooting = true;
				ActiveAnim.SetBool("isShooting", shooting);
			}
		}
	}
}