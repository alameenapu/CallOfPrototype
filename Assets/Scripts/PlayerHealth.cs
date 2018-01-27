using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
    float currentHealth;
	public GameObject deathFX;

	//HUD Variable
	public Slider playerHealthSlider;
	public Image damagedScrean;
	bool damageCheck = false;
	Color damageColor = new Color (0f, 0f, 0f, 1f);
	float smoothColor = 5f;


	PlayerController pController;

	void Start () {
		currentHealth = fullHealth;
		pController = GetComponent<PlayerController> ();
		playerHealthSlider.maxValue = fullHealth;
		playerHealthSlider.value = fullHealth;
		damageCheck = false;
	}
	

	void Update () {
		if (damageCheck) {
			damagedScrean.color = damageColor;
		} else {
			damagedScrean.color = Color.Lerp (damagedScrean.color, Color.clear, smoothColor * Time.deltaTime);
		}
		damageCheck = false;
	}

	public void AddDamage(float damage)
	{
		if (damage <= 0)
			return;
		
		currentHealth -= damage;
		playerHealthSlider.value = currentHealth;
		damageCheck = true;

		if (currentHealth <= 0)
		{
			MakeDeath ();
		}
	}

	public void MakeDeath()
	{
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);

	}
}
