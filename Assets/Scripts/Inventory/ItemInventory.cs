using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 

public class ItemInventory : MonoBehaviour {

	public List<Item> items;
	public List<Item> equipped;
	/*
	public List<ItemIdentifier> items;
	public List<ItemEffect> itemEffects;
	*/
	
	private string findType = "";
	private string findName = "";
	
	// Use this for initialization
	void Start () {
	
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
	public void DeEquip(Item itemObject){
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
		if (items.IndexOf (itemObject) >= 0) {
			return true;
		} else {
			return false;
		}
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
	
}
