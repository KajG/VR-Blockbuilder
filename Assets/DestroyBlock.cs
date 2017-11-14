using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour {
	RayCastMouse raycastmouse;
	private Inventory inventory;
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller{ get{return SteamVR_Controller.Input((int)trackedObj.index);}}
	void Start () {
		inventory = GameObject.Find("[CameraRig]").GetComponent<Inventory> ();
		raycastmouse = GetComponent<RayCastMouse> ();
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	void Update () {
		if (Controller.GetHairTriggerDown () && raycastmouse.currentGameObject != null) {
			inventory.AddItem (raycastmouse.parentObject.name);
			Destroy (raycastmouse.parentObject);
			Destroy (raycastmouse.currentGameObject);
		}
	}
}
