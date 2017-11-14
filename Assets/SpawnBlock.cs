using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {
	public RayCastMouse raycastmouse;
	public ItemDatabase itemdatabase;
	public GameObject cube;
	private Inventory inventory;
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller{ get{return SteamVR_Controller.Input((int)trackedObj.index);}}
	void Start () {
		itemdatabase = GameObject.Find("[CameraRig]").GetComponent<ItemDatabase> ();
		inventory = GameObject.Find("Controller (left)").GetComponent<Inventory> ();
		raycastmouse = GetComponent<RayCastMouse> ();
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	void Update () {
		if (Controller.GetPressDown (4) && raycastmouse.currentGameObject != null && inventory.inventory.ContainsKey (inventory.inventoryString) && !inventory.hidden) {
			SpawnCube (raycastmouse.currentGameObject.name, raycastmouse.parentObject.transform);
		}
		if (Controller.GetHairTriggerDown () && raycastmouse.currentGameObject != null) {
			inventory.AddItem (raycastmouse.parentObject.name);
			Destroy (raycastmouse.parentObject);
			Destroy (raycastmouse.currentGameObject);
		}
	}
	void SpawnCube(string direction, Transform parentObject){
		switch (direction) {
		case "Up":
			Spawn (new Vector3 (0, raycastmouse.parentObject.transform.localScale.y, 0),parentObject);
			break;
		case "Down":
			Spawn (new Vector3 (0, -raycastmouse.parentObject.transform.localScale.y, 0),parentObject);
			break;
		case "Left":
			Spawn (new Vector3 (-raycastmouse.parentObject.transform.localScale.x, 0, 0),parentObject);
			break;
		case "Right":
			Spawn (new Vector3 (raycastmouse.parentObject.transform.localScale.x, 0, 0),parentObject);
			break;
		case "Front":
			Spawn (new Vector3 (0, 0, raycastmouse.parentObject.transform.localScale.z),parentObject);
			break;
		case "Back":
			Spawn (new Vector3 (0, 0, -raycastmouse.parentObject.transform.localScale.z),parentObject);
			break;
		default:
			break;
		}
	}
	void Spawn(Vector3 pos, Transform parentObject){
		GameObject obj = Instantiate (itemdatabase.GetItemObject(inventory.inventoryString), parentObject.position + pos, Quaternion.identity);
		obj.name = inventory.inventoryString;
		inventory.RemoveItem ();
	}
}
