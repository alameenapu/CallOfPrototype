using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float doDamage;
	public float damageRate;
	public float pushBackForce;

	float nextDamage;
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && nextDamage<Time.time) {
			PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth> ();
			ph.AddDamage (doDamage);
			nextDamage = Time.time + damageRate;

			PushBack (other.transform);
		}
	}

	void PushBack(Transform pushBackObj)
	{
		Vector2 pushDirection = new Vector2 (0, (pushBackObj.position.y - transform.position.y)).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D myrb = pushBackObj.gameObject.GetComponent<Rigidbody2D> ();
		myrb.velocity = Vector2.zero;
		myrb.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
