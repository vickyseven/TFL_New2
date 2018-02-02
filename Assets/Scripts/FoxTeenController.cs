using System.Collections;
using UnityEngine;

public class FoxTeenController : MonoBehaviour
{

    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckCircle = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    //shapeshift
    //GameObject RedKid, FoxKid;
    // int characterselect;

    //for shooting boomerang

    float fireRate = 0.44f;
    float nextFire = 0f;
    bool shooting = false;


    // Use this for initialization
    void Start()
    {
        // characterselect = 1;
        //RedKid = GameObject.Find("RedKid");
        //FoxKid = GameObject.Find("FoxKid");
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;

    }


    // Update is called once per frame
    private void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        // if (Input.GetButtonDown("Change"))
        // {
        // if (characterselect == 1)
        //  {
        // characterselect = 2;
        // }
        // else if (characterselect == 2)
        // {
        // characterselect = 1;
        //}
        //}
        // if (characterselect == 1)
        // {
        // RedKid.SetActive(true);
        // FoxKid.SetActive(false);
        //}
        //  else if (characterselect == 2)
        // {
        // RedKid.SetActive(false);
        // FoxKid.SetActive(true);
        //}
    }

    void FixedUpdate()
    {


        //check if we are grounded - if not, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckCircle, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        if (shooting == false)
        {
            float move = Input.GetAxis("Horizontal");
            myAnim.SetFloat("speed", Mathf.Abs(move));

            myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

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

