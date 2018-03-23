using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoulCollect : MonoBehaviour
{

	public float soulAmount;
	public AudioSource audioSoul;
	bool IsAppearing;
	Color SpriteColor;

	// Use this for initialization
	void Start()
	{
		SpriteColor = GetComponent<SpriteRenderer>().color;
		IsAppearing = true;
		SpriteColor = new Color(SpriteColor.r, SpriteColor.g, SpriteColor.b, 0f);
		GetComponent<SpriteRenderer>().color = SpriteColor;
	}

	// Update is called once per frame
	void Update()
	{
		if (IsAppearing && SpriteColor.a < 1)
		{
			SpriteColor = new Color(SpriteColor.r, SpriteColor.g, SpriteColor.b, SpriteColor.a + 0.05f);
			GetComponent<SpriteRenderer>().color = SpriteColor;
		}
		else if (SpriteColor.a >= 1) IsAppearing = false;
		Float();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerKidController>().SoulsCollected++;
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		AudioSource.PlayClipAtPoint(audioSoul.clip,gameObject.transform.position);
	}

	void Float()
	{
		gameObject.transform.position = gameObject.transform.position + new Vector3(0f, (Mathf.Sin(Time.time) / 100), 0f);
	}
}