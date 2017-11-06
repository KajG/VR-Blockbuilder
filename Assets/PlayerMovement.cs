using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.position += ((transform.forward * Time.fixedDeltaTime) * speed);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position -= ((transform.forward * Time.fixedDeltaTime) * speed);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= ((transform.right * Time.fixedDeltaTime) * speed);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += ((transform.right * Time.fixedDeltaTime) * speed);
		}
	}
}
