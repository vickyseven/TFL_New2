using System.Collections;
using UnityEngine;

public class KidController : MonoBehaviour {

    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckCircle = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

  
 //   Rigidbody2D myRB;

    Animator myAnim;
    bool facingRight;

  

    //for shooting boomerang
    public Transform handTip;
    public GameObject boomerang;
    float fireRate = 0.44f;
    float nextFire = 0f;
    bool shooting = false;


    // Use this for initialization
    void Start() {
      
       // myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;

    }
  
  
    // Update is called once per frame
    private void Update()
    {
        if(grounded && Input.GetAxis("Jump")>0)
        { grounded = false;
            myAnim.SetBool("isGrounded", grounded);
           // myRB.AddForce(new Vector2(0, jumpHeight));

          
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0) FireBoomerang();
        else if (Input.GetAxisRaw("Fire1") == 0)
        {
            shooting = false;
            myAnim.SetBool("isShooting", shooting);
        }
     
    }

    void FixedUpdate () {


        //check if we are grounded - if not, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
        myAnim.SetBool("isGrounded", grounded);


        // myAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        if(shooting == false)
        {
            float move = Input.GetAxis("Horizontal");
            myAnim.SetFloat("speed", Mathf.Abs(move));

           // myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

            if (move > 0 && !facingRight)
            {
                flip();
            } else if (move < 0 && facingRight)
            {
                flip();
            }
        }
	}
    void flip()
    {
        facingRight=!facingRight;
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
                myAnim.SetBool("isShooting", shooting);

            }
        }
    }

    
    
}
