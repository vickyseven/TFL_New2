using System.Collections;
using UnityEngine;

public class FoxKidController : MonoBehaviour
{

    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckCircle = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myFoxRB;
    Animator myFoxAnim;
    bool facingRight;



    float fireRate = 0.44f;
    float nextFire = 0f;
    bool shooting = false;


    // Use this for initialization
    void Start()
    {
     
        myFoxRB = GetComponent<Rigidbody2D>();
        myFoxAnim = GetComponent<Animator>();

        facingRight = true;

    }


    // Update is called once per frame
    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myFoxAnim.SetBool("isGrounded", grounded);
            myFoxRB.AddForce(new Vector2(0, jumpHeight));
        }

        }

        void FixedUpdate()
        {


            //check if we are grounded - if not, we are falling
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
            myFoxAnim.SetBool("isGrounded", grounded);

            myFoxAnim.SetFloat("verticalSpeed", myFoxRB.velocity.y);


            if (shooting == false)
            {
                float move = Input.GetAxis("Horizontal");
                myFoxAnim.SetFloat("speed", Mathf.Abs(move));

                myFoxRB.velocity = new Vector2(move * maxSpeed, myFoxRB.velocity.y);

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



    }

