using UnityEngine;
using System.Collections;

public class ItemIdentifier : MonoBehaviour {

	public string name;
	public int itemID;
	public string itemType;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*Check if the id has the same type*/
	bool IsType(ItemIdentifier item){
		return item.itemType == itemType;
	}

	/*Check if the id has the same name*/
	bool IsName(ItemIdentifier item){
		return item.name == name;
	}

	/*Check if the id has the same name and type*/
	bool IsItem(ItemIdentifier item){
		return item.name == name&& item.itemType == itemType;
	}
	
	/*Technically speaking...depending on the game engine we develop...this may never happen*/
	bool IsExact(ItemIdentifier item){
		return item.name == name && item.itemType == itemType && item.itemID == itemID;
	}
}
