using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public Dictionary<string, int> inventory = new Dictionary<string, int>();
	private RayCastMouse raycastmouse;
	public ItemDatabase itemdatabase;
	public InventoryUI inventoryui;
	public string inventoryString;
	public int inventoryIndex;
	public bool hidden;
	void Update(){
		if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
			UpdateIndex (0);
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
			UpdateIndex (1);
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			HideInventory ();
		}
		if (inventoryui.items.Count > 0) {
			inventoryString = inventoryui.items [inventoryIndex];
		} else {
			inventoryui.highlighter.transform.position = new Vector3 (111, 111, 111);
		}
		print (inventory.Count);
	}
	void Start () {
		raycastmouse = GetComponent<RayCastMouse> ();
		itemdatabase = GetComponent<ItemDatabase> ();
		inventoryui = GetComponent<InventoryUI> ();
	}
	public void AddItem(string name){
		if (inventory.ContainsKey (name)) {
			inventory [name]++;
		} else {
			inventory.Add (name, 1);
			inventoryui.AddItem (name);
		}
		inventoryui.UpdateUI ();
	}
	public void RemoveItem(){
		if (CheckItem ()) {
			inventory [inventoryString]--;
			if (inventory [inventoryString] <= 0) {
				inventory.Remove (inventoryString);
				inventoryui.RemoveItem (inventoryString);
				UpdateIndex (2);
			}
			inventoryui.UpdateUI ();
		}
	}
	public void HideInventory(){
		if (!hidden) {
			inventoryui.HideInventory ();
		} else if(inventory.Count != 0){
			hidden = false;
			inventoryui.UpdateUI ();
		}
	}
	public bool CheckItem(){
		if (inventory.ContainsKey (inventoryString)) {
			return true;
		} else {
			return false;
		}
	}
	void UpdateIndex(int i){
		if (i == 0) {
			if (inventoryIndex >= inventoryui.items.Count - 1 && inventory.Count != 0) {
				inventoryIndex = inventoryui.items.Count - 1;
			} else if(inventory.Count != 0){
				inventoryIndex++;
				inventoryui.UpdateHighlight ();
			}
		}
		if (i == 1) {
			if (inventoryIndex >= 1 && inventory.Count != 0) {
				inventoryIndex--;
				inventoryui.UpdateHighlight ();
			} else if (inventory.Count != 0) {
				inventoryui.UpdateHighlight ();
			}
		}
		if (i == 2) {
			if (inventoryIndex >= inventory.Count && inventory.Count != 0) {
				inventoryIndex = inventory.Count - 1;
				inventoryui.UpdateHighlight ();
			}
		}
	}
}
