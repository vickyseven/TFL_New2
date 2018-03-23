using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingWallScript : MonoBehaviour {
	public GameObject ObjDependancy;
	Animation Anim;
	public bool TDestructOrFAnimate;
	bool Animating;

	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!ObjDependancy) Remove();
		if (Animating) gameObject.transform.position = Vector3.Max(gameObject.transform.position - new Vector3 (0f,0.1f,0f), new Vector3 (gameObject.transform.position.x, -23f, gameObject.transform.position.z));
	}

	void Remove()
	{
		if (TDestructOrFAnimate) Destroy(gameObject);
		else Animating = true;
	}
}
