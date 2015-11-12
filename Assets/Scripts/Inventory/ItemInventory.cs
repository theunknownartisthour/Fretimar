using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 

public class ItemInventory : MonoBehaviour {

	public List<Item> items;
	public List<Item> equipped;
	
	private string findType = "";
	private string findName = "";

	/*So we can drop items back out of the inventory*/
	public Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use(Item itemObject){
		int index = items.IndexOf (itemObject);
		if (index >= 0) {
			itemObject.Use();
			items.RemoveAt(index);
		}
	}
	
	/*Take an object (presumably in the inventory's list of items) and add it to the equipped list*/
	public void Equip(Item itemObject){
		int index = items.IndexOf(itemObject);
		if (index >= 0) {
			if(itemObject.isEquippable){
				items.RemoveAt(index);
				equipped.Add(itemObject);
			} else {
				/*Complain with GUI error noise and message that it isn't equippable*/
			}
		} else {
			/*Complain with GUI error noise and message that it isn't in the inventory*/
		}
	}
	
	/*Take an object (presuably in the inventory's list of equipped items) and add it back to the list of items*/
	public void Unequip(Item itemObject){
		int index = equipped.IndexOf (itemObject);
		if (index >= 0) {
			if(itemObject.isDequippable){
				equipped.RemoveAt(index);
				items.Add(itemObject);
			} else {
				/*Complain with GUI error noise and message that it isn't dequippable*/
			}
		}
		else {
			/*Complain with GUI error noise and message that it isn't equipped*/
		}
	}

	/*Looks for an exact match with a similar object*/
	public bool HasInInventory(Item itemObject){
		if (IndexInInventory (itemObject) >= 0) {
			return true;
		} else {
			return false;
		}
	}

	/*Looks for an exact match with a similar object*/
	public int IndexInInventory(Item itemObject){
		return items.IndexOf (itemObject);
	}

	/*Looks for an exact match by checking the Item.identification*/
	public bool HasInInventory(string itemType, string name){
		findType = itemType;
		findName = name;
		if (items.FindIndex(IsItem) >= 0) {
			return true;
		} else {
			return false;
		}
	}

	/*Looks for a partial match by checking only the Item.identification.itemType*/
	public bool HasTypeInInventory(string itemType){
		findType = itemType;
		if (items.FindIndex(IsType) >= 0) {
			return true;
		} else {
			return false;
		}
	}

	/*Looks for a partial match by checking only the Item.identification.name*/
	public bool HasNameInInventory(string name){
		findName = name;
		if (items.FindIndex(IsName) >= 0) {
			return true;
		} else {
			return false;
		}
	}

	bool IsType(Item itemObject){
		return itemObject.identification.itemType == findType;
	}

	bool IsName(Item itemObject){
		return itemObject.identification.name == findName;
	}

	bool IsItem(Item itemObject){
		return itemObject.identification.name == findName && itemObject.identification.itemType == findType;
	}

	public void AddItem(Item itemObject){
		items.Add(itemObject);
	}

	/*Attempts to remove an item from the list if it exists, returns the index removed, -2 if the item wasn't found or -1 if there was nothing in that slot*/
	public int RemoveItem(Item itemObject){
		int index = items.IndexOf (itemObject);
		if (index >= 0) {
			return RemoveItem (index);
		} else {
			return -2;
		}
	}

	/*Removes an item if possible, returns eaither the index of the item removed or -1 if it failed*/
	public int RemoveItem(int index){
		if (index < items.Count) {
			items.RemoveAt (index);
			return index;
		} else {
			/*Compain there's nothing in this slot to remove!*/
			return -1;
		}       
	}

	public int DropItem(Item itemObject){
		if (RemoveItem (itemObject) >= 0) {
			Vector3 spawnPoint = rb.transform.position.forward;
			spawnPoint.Set(spawnPoint.x,spawnPoint.y+1,spawnPoint.z);
			itemObject.transform.position = spawnPoint;

			Instantiate(itemObject);
		}
	}

}
