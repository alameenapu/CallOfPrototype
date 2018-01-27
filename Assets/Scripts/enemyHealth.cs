using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

	public float enemyMaxHealth;
	float currentHealth;
	public GameObject enemyFX;
	public Slider enemyHealthSliderBar;

	void Start () {
		currentHealth = enemyMaxHealth;
		enemyHealthSliderBar.maxValue = enemyMaxHealth;
		enemyHealthSliderBar.value = enemyMaxHealth;
	}
	

	void Update () {
		
	}

	public void AddDamage(float damage)
	{
		enemyHealthSliderBar.gameObject.SetActive (true);
		currentHealth -= damage;
		enemyHealthSliderBar.value = currentHealth;

		if (currentHealth <= 0)
			MakeDestroy ();
	}

	void MakeDestroy(){
		Destroy (gameObject);
		Instantiate (enemyFX, transform.position, transform.rotation);
	}
}
