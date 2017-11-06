using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMouse : MonoBehaviour {
	public GameObject currentGameObject;
	public GameObject parentObject;
	public ShowCollider showcollider;
	public Transform oldName;
	public Transform currentName;
	void Start(){
		showcollider = GetComponent<ShowCollider> ();
	}
	void Update () {
		RaycastHit hit;
		Vector3 viewPoint = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast (transform.position, viewPoint, out hit, 20)) {
			oldName = currentName;
			currentName = hit.collider.transform;
			currentGameObject = hit.collider.gameObject;
			parentObject = currentGameObject.transform.parent.gameObject;
			if (oldName != currentName) {
				showcollider.CreateObject ();
			}
		} else {
			parentObject = null;
			currentGameObject = null;
		}

	}
}
