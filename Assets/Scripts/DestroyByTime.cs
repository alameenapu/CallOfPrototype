using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float destroyTime;

	void Awake () {
		Destroy (gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
