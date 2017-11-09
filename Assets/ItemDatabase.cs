using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour{
	public List<GameObject> objects = new List<GameObject> ();
	public GameObject GetItemObject(string name){
		for (int i = 0; i < objects.Count; i++) {
			if (name == objects [i].name) {
				return objects [i];
			} 
		}
		return null;
	}
	public bool CheckItem(string name){
		for (int i = 0; i < objects.Count; i++) {
			if (name == objects [i].name) {
				return true;
			} 
		}
		return false;
	}
}