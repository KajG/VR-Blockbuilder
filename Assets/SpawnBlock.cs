using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {
	RayCastMouse raycastmouse;
	public GameObject cube;
	void Start () {
		raycastmouse = GetComponent<RayCastMouse> ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0) && raycastmouse.currentGameObject != null) {
			SpawnCube (raycastmouse.currentGameObject.name, raycastmouse.parentObject.transform);
		}
		if (Input.GetMouseButtonDown (1) && raycastmouse.currentGameObject != null) {
			Destroy (raycastmouse.parentObject);
			Destroy (raycastmouse.currentGameObject);
		}
	}
	void SpawnCube(string direction, Transform parentObject){
		switch (direction) {
		case "Up":
			Instantiate (cube, parentObject.position + new Vector3 (0, raycastmouse.parentObject.transform.localScale.y, 0), Quaternion.identity);
			break;
		case "Down":
			Instantiate (cube, parentObject.position + new Vector3 (0, -raycastmouse.parentObject.transform.localScale.y, 0), Quaternion.identity);
			break;
		case "Left":
			Instantiate (cube, parentObject.position + new Vector3 (-raycastmouse.parentObject.transform.localScale.x, 0, 0), Quaternion.identity);
			break;
		case "Right":
			Instantiate (cube, parentObject.position + new Vector3 (raycastmouse.parentObject.transform.localScale.x, 0, 0), Quaternion.identity);
			break;
		case "Front":
			Instantiate (cube, parentObject.position + new Vector3 (0, 0, raycastmouse.parentObject.transform.localScale.z), Quaternion.identity);
			break;
		case "Back":
			Instantiate (cube, parentObject.position + new Vector3 (0, 0, -raycastmouse.parentObject.transform.localScale.z), Quaternion.identity);
			break;
		default:
			break;
		}
	}
}
