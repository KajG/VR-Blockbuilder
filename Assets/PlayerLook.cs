using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

	private float mouseX;
	private float mouseY;
	private float mouseZ;
	private Quaternion lookRot;
	public float lookYMax;
	public float lookYMin;

	void Update () {
		mouseX = Input.mousePosition.x;
		mouseY = Input.mousePosition.y - 200;
		mouseZ = Input.mousePosition.z;
		if (mouseY >= lookYMax) {
			mouseY = lookYMax;
		}
		if (mouseY <= lookYMin) {
			mouseY = lookYMin;
		}
		transform.localEulerAngles = new Vector3 (-mouseY, mouseX, mouseZ);
	}
}
