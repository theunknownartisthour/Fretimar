using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; 

namespace Completed {

	public class ItemInventory : MonoBehaviour {

		public List<ItemIdentifier> items;
		public List<ItemEffect> itemEffects;
		private string findType = "";
		private string findName = "";
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		public void Use(ItemIdentifier item){
			int index = items.IndexOf (item);
			if (index >= 0) {

				/*
Do Something~
			*/
				items.RemoveAt (index);
				itemEffects.RemoveAt (index);
			}
		}

		public bool HasInInventory(ItemIdentifier item){
			if (items.IndexOf (item) >= 0) {
				return true;
			} else {
				return false;
			}
		}

		public bool HasInInventory(string itemType, string name){
			findType = itemType;
			findName = name;
			if (items.FindIndex(IsItem) >= 0) {
				return true;
			} else {
				return false;
			}
		}

		public bool HasTypeInInventory(string itemType){
			findType = itemType;
			if (items.FindIndex(IsType) >= 0) {
				return true;
			} else {
				return false;
			}
		}

		public bool HasNameInInventory(string name){
			findName = name;
			if (items.FindIndex(IsName) >= 0) {
				return true;
			} else {
				return false;
			}
		}

		bool IsType(ItemIdentifier item){
			return item.itemType == findType;
		}

		bool IsName(ItemIdentifier item){
			return item.name == findName;
		}

		bool IsItem(ItemIdentifier item){
			return item.name == findName && item.itemType == findType;
		}

		public void AddItem(ItemIdentifier item, ItemEffect itemEffect){
			items.Add (item);
			itemEffects.Add (itemEffect);
		}
	}

}
