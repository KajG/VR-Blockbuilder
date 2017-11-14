using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour {
	private Inventory inventory;
	public List<string> items = new List<string>();
	private List<TextMesh> itemNames = new List<TextMesh>();
	private List<TextMesh> itemCount = new List<TextMesh> ();
	public TextMesh nameText;
	public TextMesh countText;
	public GameObject invSpace;
	public Transform parentObject;
	private List<GameObject> spaces = new List<GameObject>();
	public GameObject highlighter;
	void Start () {
		inventory = GetComponent<Inventory> ();
	}
	void Update(){
		if(!inventory.hidden){
			UpdateHighlight ();
		}
	}
	public void AddItem(string name){
		items.Add (name);
	}
	public void RemoveItem(string name){
		items.Remove (name);
	}
	public void UpdateUI(){
		if (!inventory.hidden) {
			for (int i = 0; i < itemNames.Count; i++) {
				Destroy (itemNames [i]);
				Destroy (itemCount [i]);
				Destroy (spaces [i]);
			}
			highlighter.SetActive (true);
			spaces.Clear ();
			itemNames.Clear ();
			itemCount.Clear ();
			CreateSpace ();
			CreateInventory ();
			UpdateHighlight ();
		} 
	}
	public void UpdateHighlight(){
		if (!inventory.hidden && items.Count != 0) {
			highlighter.transform.position = spaces [inventory.inventoryIndex].transform.position;
			highlighter.transform.rotation = spaces [inventory.inventoryIndex].transform.rotation;

		}
	}
	public void HideInventory(){
		if (items.Count != 0) {
			for (int i = 0; i < itemNames.Count; i++) {
				Destroy (itemNames [i]);
				Destroy (itemCount [i]);
				Destroy (spaces [i]);
			}
		}
		highlighter.SetActive(false);
		inventory.hidden = true;
	}
	void CreateSpace(){
		int y = 0;
		int x = 0;
		for (int i = 0; i < items.Count; i++) {
			x += 2;
			if(i % 2 == 0){
				y += 2;
				x = 0;
			}
			GameObject obj = Instantiate (invSpace, new Vector3 (parentObject.transform.position.x,parentObject.transform.position.y + y * 0.1f, parentObject.transform.position.z + x * 0.1f), parentObject.transform.rotation);
			spaces.Add (obj);
		}
	}
	void CreateInventory(){
		for (int i = 0; i < items.Count; i++) {
			TextMesh newText = Instantiate (countText, new Vector3 (spaces [i].transform.position.x, spaces [i].transform.position.y + 0.05f, spaces [i].transform.position.z + 0.05f), Quaternion.identity);
			newText.text = "" + inventory.inventory [items [i]];
			newText.fontSize = 30;
			newText.transform.eulerAngles = new Vector3 (0, 90, 0);
			itemCount.Add (newText);
			TextMesh newText2 = Instantiate (nameText, spaces [i].transform.position, Quaternion.identity);
			newText2.text = items [i];
			newText2.fontSize = 30;
			newText2.transform.eulerAngles = new Vector3 (0, 90, 0);
			itemNames.Add (newText2);
			itemNames [i].transform.SetParent (parentObject);
			itemCount [i].transform.SetParent (parentObject);
			spaces [i].transform.SetParent (parentObject);
		}
	}
}
