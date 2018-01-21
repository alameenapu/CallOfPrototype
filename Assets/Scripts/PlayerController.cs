using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;

	// for jumping
	bool grounded=false;
	float groundCheckRedius=0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	Rigidbody2D rd;
	Animator anim;
	bool faceRight;

	//for shot

	public Transform gunTip;
	public GameObject rocketFire;
	public float fireRate; 
	private float nextFire;



	void Start () 
	{
		rd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		faceRight = true;
	}

	void Update()
	{
		if (grounded && Input.GetAxis ("Jump")>0) 
		{
			grounded = false;
			anim.SetBool ("isGround", grounded);
			rd.AddForce (new Vector2 (0, jumpHeight));
		}

		//for shooting
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (faceRight) {
				Instantiate (rocketFire, gunTip.position, Quaternion.Euler (new Vector3(0,0,0)));
			} else if (!faceRight) {
				Instantiate (rocketFire, gunTip.position, Quaternion.Euler (new Vector3(0,0,180f)));
			}
		}

	}

	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRedius, groundLayer);
		anim.SetBool ("isGround", grounded);

		anim.SetFloat ("verticalspeed", rd.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed", Mathf.Abs(move));

		rd.velocity = new Vector2 (move * maxSpeed, rd.velocity.y);

		if (move > 0 && !faceRight) {
			flip ();
		} 
		else if (move < 0 && faceRight) 
		{
			flip ();
		}
	}

	void flip()
	{
		faceRight = !faceRight;
		Vector3 scaleLocation = transform.localScale;
		scaleLocation.x *= -1;
		transform.localScale = scaleLocation;
	}



}
