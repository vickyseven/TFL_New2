using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public float enemySpeed;
	float CurrentSpeed = 0;
	public bool MovesVertically;
	Vector2 Direction;

    Animator enemyAnimator;


    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;


    //attack
    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;
	public int ActivatedTriggers = 0;


	// Use this for initialization
	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
		if (MovesVertically == true) Direction = new Vector2(0, 1);
		else Direction = new Vector2(1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFlipChance) {
            if (UnityEngine.Random.Range(0, 10) >=5) FlipFacing();
            nextFlipChance = Time.time + flipTime;
        }
		if (enemyGraphic && enemyGraphic.GetComponent<EnemyDamage>().IsHitting == true) CurrentSpeed = 0;
		else if (charging == true && CurrentSpeed < enemySpeed) CurrentSpeed = CurrentSpeed + 0.2f;
		if (enemyGraphic == null)
		{
			Destroy(gameObject);
		}
    }

   
 

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
			ActivatedTriggers++;
            if (facingRight && other.transform.position.x < transform.position.x) {
                FlipFacing();
            }

            else if (!facingRight && other.transform.position.x > transform.position.x) {
            FlipFacing();
            }
        canFlip = false;
        charging = true;
        startChargeTime = Time.time + chargeTime;
        }
       
    }
    void OnTriggerStay2D(Collider2D other)
    {
		if (other.tag == "Player")
		{
			if (startChargeTime < Time.time)
			{
				if (!facingRight) enemyRB.velocity = (-Direction * CurrentSpeed);
				else enemyRB.velocity = (Direction * CurrentSpeed);
				if (enemyAnimator)
				{
					enemyAnimator.SetBool("isCharging", charging);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
            if (other.tag == "Player"){
			ActivatedTriggers--;
                canFlip = true;
			if (ActivatedTriggers == 0) charging = false;
			enemyRB.velocity = new Vector2(0f, 0f);
			CurrentSpeed = 0f;
			if (enemyAnimator)
			{
				enemyAnimator.SetBool("isCharging", charging);
			}
            }
        }

        void FlipFacing() {
		if (enemyGraphic)
		{
			if (canFlip == false) return;
			float facingX = enemyGraphic.transform.localScale.x;
			facingX *= -1f;
			enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
			facingRight = !facingRight;
		}
	}
}
