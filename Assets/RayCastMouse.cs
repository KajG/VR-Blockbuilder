using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMouse : MonoBehaviour {
	public GameObject currentGameObject;
	public GameObject parentObject;
	public ShowCollider showcollider;
	public RaycastHit hit;
	private Transform oldPos;
	private Transform currentPos;
	void Start(){
		showcollider = GetComponent<ShowCollider> ();
	}
	void Update () {
		Vector3 viewPoint = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast (transform.position, viewPoint, out hit, 20)) {
			oldPos = currentPos;
			currentPos = hit.collider.transform;
			currentGameObject = hit.collider.gameObject;
			parentObject = currentGameObject.transform.parent.gameObject;
			if (oldPos != currentPos) {
				showcollider.CreatePreview ();
			}
		} else {
			parentObject = null;
			currentGameObject = null;
			showcollider.DestroyPreview ();
		}

	}
}
