using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2DMove : MonoBehaviour {

	public GameObject tt;
	public Transform target;
	public float smothing;
	Vector3 offset;
	float lowY;
	//public bool gg;
	void Start () {
		offset = transform.position - target.position;
		lowY = transform.position.y;

	}
	

	void FixedUpdate () {
		if (tt.gameObject != null) {
			Vector3 targetCamPos = target.position + offset;
			transform.position = Vector3.Lerp (transform.position, targetCamPos, smothing * Time.deltaTime);
			if (transform.position.y < lowY)
				transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}

}
