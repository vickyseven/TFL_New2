using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGirlController : MonoBehaviour {

    //character select
    GameObject RedGirl, FoxGirl;
    int characterselect;

    //movement variables
    public float GirlmaxSpeed;
    public float FoxGirlmaxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckCircle = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float GirljumpHeight;
    public float FoxGirljumpHeight;


    Rigidbody2D myRB;
    Animator myGirlAnim;
    bool facingRight;

    //FOX
    Animator myFoxGirlAnim;



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
        RedGirl = GameObject.Find("RedGirl");
        FoxGirl = GameObject.Find("FoxGirl");




        myRB = GetComponent<Rigidbody2D>();
        myGirlAnim = RedGirl.GetComponent<Animator>();
        //FOX
        myFoxGirlAnim = FoxGirl.GetComponent<Animator>();

        facingRight = true;

    }


    // Update is called once per frame
    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myGirlAnim.SetBool("isGrounded", grounded);
            myFoxGirlAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, GirljumpHeight));

        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0) FireBoomerang();
        else if (Input.GetAxisRaw("Fire1") == 0)
        {
            shooting = false;
            myGirlAnim.SetBool("isShooting", shooting);
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
            RedGirl.SetActive(true);
            FoxGirl.SetActive(false);
        }
        else if (characterselect == 2)
        {
            RedGirl.SetActive(false);
            FoxGirl.SetActive(true);
        }

        //check if we are grounded - if not, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
        myGirlAnim.SetBool("isGrounded", grounded);
        myFoxGirlAnim.SetBool("isGrounded", grounded);


        myGirlAnim.SetFloat("verticalSpeed", myRB.velocity.y);
        myFoxGirlAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        if (shooting == false)
        {
            float move = Input.GetAxis("Horizontal");
            myGirlAnim.SetFloat("speed", Mathf.Abs(move));
            myFoxGirlAnim.SetFloat("speed", Mathf.Abs(move));

            myRB.velocity = new Vector2(move * GirlmaxSpeed, myRB.velocity.y);

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
                myGirlAnim.SetBool("isShooting", shooting);

            }
        }
    }



}
