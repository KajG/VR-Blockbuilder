﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCollider : MonoBehaviour {
	private RayCastMouse raycastmouse;
	public GameObject preview;
	private GameObject previewObj;
	private bool previewSpawned;
	void Start () {
		raycastmouse = GetComponent<RayCastMouse> ();
	}
	
	public void CreatePreview () {
		DestroyPreview ();
		previewObj = Instantiate (preview, raycastmouse.currentGameObject.transform.position, Quaternion.identity);
		previewObj.transform.localScale = raycastmouse.currentGameObject.GetComponent<BoxCollider> ().size;
	}
	public void DestroyPreview(){
		if (previewObj != null) {
			Destroy (previewObj);
		}
	}
}