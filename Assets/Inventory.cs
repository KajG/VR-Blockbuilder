using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public Dictionary<string, int> inventory = new Dictionary<string, int>();
	private RayCastMouse raycastmouse;
	public string word;
	public ItemDatabase itemdatabase;
	public InventoryUI inventoryui;
	public string inventoryIndex;
	public bool hidden;
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
			return;
		}
		inventoryui.UpdateUI ();
	}
	public void RemoveItem(){
		print (inventory.Count);
		if (CheckItem ()) {
			inventory [inventoryIndex]--;
			if (inventory [inventoryIndex] <= 0) {
				inventory.Remove (inventoryIndex);
				inventoryui.RemoveItem (inventoryIndex);
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
		if (inventory.ContainsKey (inventoryIndex)) {
			return true;
		} else {
			return false;
		}
	}
}
