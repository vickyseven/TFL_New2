using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKidController : MonoBehaviour {

	//character select
	GameObject RedKid, FoxKid;
	int characterselect;
	public bool CanChange = false;
	GameController GameContr;

	//movement variables
	public float KidmaxSpeed;
	public float FoxmaxSpeed;
	public bool CanMove;
	bool facingRight;

	//jumping variables
	public bool grounded = false;
	float groundCheckCircle = 0.5f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public GameObject ForwardCheck;
	public float KidjumpHeight;
	public float FoxjumpHeight;

	//Colliders
	public Rigidbody2D myRB;
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
	public bool CanShoot = true;

	//collection and point systems
//	UI_SoulCounter HUDSoulCounter;
	public int SoulsCollected = 0;

	//Elemental Attacks
	public bool CanElementalAttack = false;
	bool IsElementalAttacking = false;

	// Use this for initialization
	void Start()
	{
//		HUDSoulCounter = FindObjectOfType<UI_SoulCounter>();

		//character select
		RedKid = GameObject.Find("RedKid");
		FoxKid = GameObject.Find("FoxKid");
		GameContr = FindObjectOfType<GameController>();
		GameContr.UpdatePlayer(gameObject);

		myRB = GetComponent<Rigidbody2D>();
		myKidAnim = RedKid.GetComponent<Animator>();
		myFoxAnim = FoxKid.GetComponent<Animator>();
		facingRight = true;
		characterselect = 1;

		PlayerCollider = GetComponent<BoxCollider2D>();

		RedKid.SetActive(true);
		FoxKid.SetActive(false);
		ActiveAnim = myKidAnim;
		myKidAnim.Play("PlayerKidIdle");
		CanMove = true;
	}


	// Update is called once per frame
	private void Update()
	{
		//Check if movement is enabled
		if (!CanMove)
		{
			myRB.velocity = new Vector2 (0,0);
			return;
		}

		//Jumping
		if (shooting == false && grounded && Input.GetAxis("Jump") > 0)
		{
			grounded = false;
			ActiveAnim.SetBool("isGrounded", grounded);

			if (characterselect == 1)
				myRB.velocity = (new Vector2(0, KidjumpHeight));
			if (characterselect == 2)
				myRB.velocity = (new Vector2(0, FoxjumpHeight));
		}
		else if (grounded == false) myRB.velocity = Vector2.Min(myRB.velocity - new Vector2 (0, (1f / characterselect)), new Vector2 (0, 100));
//		else if (grounded == false && bouncing == true) myRB.velocity = Vector2.Min(myRB.velocity - new Vector2(0, (1f / characterselect)), new Vector2(0, 75));
		else if (grounded) myRB.velocity = new Vector2 (myRB.velocity.x, 0);

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

		//fire attack
		if (Input.GetButtonDown("FireAttack") && CanElementalAttack) ElementalAttack();
		else if (Time.time > (nextFire + fireRate) && Input.GetAxisRaw("FireAttack") == 0)
		{
			IsElementalAttacking = false;
			ActiveAnim.SetBool("IsCasting", IsElementalAttacking);
			ForwardCheck.GetComponent<ElementalAttacks>().FireAnim.SetBool("CastFire", false);
		}


	}

	void FixedUpdate()
	{
		//character select
		if (Input.GetButtonDown("Change") && CanChange)
		{
			ShapeShift();
		}

		//check if we are grounded - if not, we are falling
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
		ActiveAnim.SetBool("isGrounded", grounded);
		ActiveAnim.SetFloat("verticalSpeed", myRB.velocity.y);
		
		//movement
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

	void ShapeShift()
	{
		if (characterselect == 2)
		{
			characterselect = 1;
			RedKid.SetActive(true);
			FoxKid.SetActive(false);
			ActiveAnim = myKidAnim;
			myRB.mass = 1;
			PlayerCollider.size = (new Vector2(1.2f, 2.7f));
			PlayerCollider.offset = (new Vector2(0f, -1.17f));
		}
		else if (characterselect == 1)
		{
			characterselect = 2;
			RedKid.SetActive(false);
			FoxKid.SetActive(true);
			ActiveAnim = myFoxAnim;
			myRB.mass = 0.5f;
			PlayerCollider.size = (new Vector2(0f, 0f));
			PlayerCollider.offset = (new Vector2(0f, 0f));
		}
	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void ElementalAttack()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate*5;
			if (facingRight)
			{
				ForwardCheck.GetComponent<ElementalAttacks>().FXrotation = new Quaternion(0, 0, 0, 0);
			}
			else if (!facingRight)
			{
				ForwardCheck.GetComponent<ElementalAttacks>().FXrotation = new Quaternion(0, 180, 0, 0);
			}

			IsElementalAttacking = true;
			ForwardCheck.GetComponent<ElementalAttacks>().FireAttack();
			ActiveAnim.SetBool("IsCasting", IsElementalAttacking);
		}
	}

	void FireBoomerang()
	{
		if (CanShoot)
		{
			if (facingRight)
			{
				GameObject RightBoomerang = Instantiate(boomerang, handTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
				RightBoomerang.GetComponent<BoomerangController>().facingRight = true;
				GetComponent<KidHealth>().SurvivingBoomerang = RightBoomerang;
			}
			else if (!facingRight)
			{
				GameObject LeftBoomerang = Instantiate(boomerang, handTip.position, Quaternion.Euler(new Vector3(0, 0, -180f)));
				LeftBoomerang.GetComponent<BoomerangController>().facingRight = false;
				GetComponent<KidHealth>().SurvivingBoomerang = LeftBoomerang;
			}
			shooting = true;
			CanShoot = false;
			ActiveAnim.SetBool("isShooting", shooting);
		}
	}
}