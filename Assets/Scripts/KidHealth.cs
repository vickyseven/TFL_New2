using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidHealth : MonoBehaviour {

	public float maxHealth;
	public GameObject deathFX;
	//	float DeathTime = 0f;
	//	bool IsDead;
	public float currentHealth = 70f;
//	PlayerKidController controlMovement;
	public Vector3 Checkpoint;

	//HUD Variables
	public Slider healthSlider;

	// Use this for initialization
	void Start() {
//		currentHealth = currentHealth;
//		controlMovement = GetComponent<PlayerKidController>();

		//HUD Initialization
		healthSlider.maxValue = maxHealth;
		healthSlider.value = currentHealth;

	}

	// Update is called once per frame
	void Update() {
		//if (IsDead)
		//{
		//	if (Time.time == DeathTime + 5)
		//{
		//Respawn();
		//IsDead = false;
		//DeathTime = 0f;
		//return;
		//}
		//}
		//else return;
	}

	public void addDamage(float damage)
	{
		if (damage <= 0) return;
		currentHealth = currentHealth - damage;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0)
		{
			makeDead();
		}
	}

	public void addHealth(float healthAmount)
	{
		currentHealth += healthAmount;
		if (currentHealth > maxHealth) currentHealth = maxHealth;
		healthSlider.value = currentHealth;
	}

	public void makeDead() {
		Instantiate(deathFX, transform.position, new Quaternion (0,160,0,0));
		//		IsDead = true;
		//		DeathTime = Time.time;
		Respawn();
	}

	public void Respawn() {
		gameObject.transform.SetPositionAndRotation(Checkpoint,new Quaternion (0,0,0,0));
		currentHealth = maxHealth;
		healthSlider.value = currentHealth;
	}
}
