using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {
	RayCastMouse raycastmouse;
	ItemDatabase itemdatabase;
	public GameObject cube;
	private Inventory inventory;
	void Start () {
		itemdatabase = GetComponent<ItemDatabase> ();
		inventory = GetComponent<Inventory> ();
		raycastmouse = GetComponent<RayCastMouse> ();
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0) && raycastmouse.currentGameObject != null && inventory.inventory.ContainsKey(inventory.inventoryIndex)) {
			SpawnCube (raycastmouse.currentGameObject.name, raycastmouse.parentObject.transform);
		}
		if (Input.GetMouseButtonDown (1) && raycastmouse.currentGameObject != null) {
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
		GameObject obj = Instantiate (itemdatabase.GetItemObject(inventory.inventoryIndex), parentObject.position + pos, Quaternion.identity);
		obj.name = parentObject.name;
	}
}
