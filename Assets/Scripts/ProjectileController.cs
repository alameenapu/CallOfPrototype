using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	public float rocketSpeed;
	Rigidbody2D rb;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();

		if(transform.localRotation.z > 0)
		    rb.AddForce (new Vector2 (-1, 0) * rocketSpeed, ForceMode2D.Impulse);
		else 
			rb.AddForce (new Vector2 (1, 0) * rocketSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
