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
			inventoryIndex++;
			inventoryui.UpdateHighlight ();
			if (inventoryIndex >= inventoryui.items.Count) {
				inventoryIndex = inventoryui.items.Count;
				print (inventoryui.items.Count);
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (inventoryIndex >= 0 && inventoryIndex <= inventoryui.items.Count) {
				inventoryIndex--;
				inventoryui.UpdateHighlight ();
			}
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
			inventory [name] ++;
		} else if (itemdatabase.CheckItem(name)) {
			inventory.Add (name, 1);
			inventoryui.AddItem (name);
		} else {
			inventoryui.UpdateUI ();
			return;
		}
		inventoryui.UpdateUI ();
	}
	public void RemoveItem(){
		print (inventory.Count);
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
