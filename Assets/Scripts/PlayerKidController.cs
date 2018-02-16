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

    //jumping variables
    bool grounded = false;
    float groundCheckCircle = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float KidjumpHeight;
    public float FoxjumpHeight;


    Rigidbody2D myRB;
    Animator myKidAnim;
    bool facingRight;

    //FOX
    Animator myFoxAnim;



    //for shooting boomerang
    public Transform handTip;
    public GameObject boomerang;
    float fireRate = 0.44f;
    float nextFire = 0f;
    bool shooting = false;


    // Use this for initialization
    void Start()
    {

        //character select
        characterselect = 1;
        RedKid = GameObject.Find("RedKid");
        FoxKid = GameObject.Find("FoxKid");




        myRB = GetComponent<Rigidbody2D>();
        myKidAnim = RedKid.GetComponent<Animator>();
        //FOX
        myFoxAnim = FoxKid.GetComponent<Animator>();

        facingRight = true;

    }


    // Update is called once per frame
    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
           myKidAnim.SetBool("isGrounded", grounded);
           myFoxAnim.SetBool("isGrounded", grounded);

            if (characterselect == 1)
                myRB.AddForce(new Vector2(0, KidjumpHeight));
            if (characterselect == 2)
                myRB.AddForce(new Vector2(0, FoxjumpHeight));

        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0) FireBoomerang();
        else if (Input.GetAxisRaw("Fire1") == 0)
        {
            shooting = false;
           myKidAnim.SetBool("isShooting", shooting);
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
            //Change the capsule collision roatation and translation of RedKid
            myRB.mass = 1;
        }
        else if (characterselect == 2)
        {
            RedKid.SetActive(false);
            FoxKid.SetActive(true);
            //Change the capsule collision roatation and translation of RedFox
            myRB.mass = 0.5f;
        }

        //check if we are grounded - if not, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
        myKidAnim.SetBool("isGrounded", grounded);
        myFoxAnim.SetBool("isGrounded", grounded);


        myKidAnim.SetFloat("verticalSpeed", myRB.velocity.y);
        myFoxAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        if (shooting == false)
        {
            float move = Input.GetAxis("Horizontal");
           myKidAnim.SetFloat("speed", Mathf.Abs(move));
           myFoxAnim.SetFloat("speed", Mathf.Abs(move));

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
                myKidAnim.SetBool("isShooting", shooting);

            }
        }
    }



}
