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
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			print (inventory.Count);
			if (inventoryIndex >= inventoryui.items.Count - 1) {
				inventoryIndex = inventoryui.items.Count - 1;
				print (inventoryui.items.Count);
			} else {
				inventoryIndex++;
			}
			inventoryui.UpdateHighlight ();
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (inventoryIndex >= 1) {
				inventoryIndex--;
			}
			inventoryui.UpdateHighlight ();
		}
		if (inventoryui.items.Count > 0) {
			inventoryString = inventoryui.items [inventoryIndex];
		}
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
			}
		}
		inventoryui.UpdateUI ();
	}
	public void HideInventory(){
		if (!hidden) {
			inventoryui.HideInventory ();
		} else {
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
}
