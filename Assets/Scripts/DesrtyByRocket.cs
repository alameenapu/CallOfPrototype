using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesrtyByRocket : MonoBehaviour {

	public float weaponDamage;
	ProjectileController pc;
	public GameObject explosion;

	void Awake () {

		pc = GetComponentInParent<ProjectileController> ();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			pc.RemoveForce ();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

			if (other.tag == "Enemy") {
				enemyHealth eh = other.gameObject.GetComponent<enemyHealth> ();
				eh.AddDamage (weaponDamage);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			pc.RemoveForce ();
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

			if (other.tag == "Enemy") {
				enemyHealth eh = other.gameObject.GetComponent<enemyHealth> ();
				eh.AddDamage (weaponDamage);
			}
		}
	}
}
