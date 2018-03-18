using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoulCollect : MonoBehaviour
{

    public float soulAmount;
    public AudioSource audioSoul;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}