using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	/*This is so we can eaisly drag and drop scripts to prototype new prefabs*/
	public ItemIdentifier identification;
	public ItemEffect effect;
	
	/*This is used in the inventory*/
	public bool isEquippable = true;
	public bool isDequippable = true;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*Using an item checks the ItemEffect connected to it, without one nothing will happen*/
	/*Returns 1 if the item used had an effect, 0 if the item failed, and -1 if the item is out of uses*/
	/*Returns -2 if there's no effect...*/
	public int Use () {
		/*Does this item have an effect? Continue on...*/
		if(effect != null){
			/*Check if we have a usage cap on the item*/
			if(effect.uses > 0 || effect.uses == -1){
				
				int roll = Random.Range(0, 99);
			
				if(roll < effect.successRate){
					effect.Use();
					return 1;
				} else {
					return 0;
				}
				
				if(effect.uses > 0){
					effect.uses--;
				}
				
			} else {
				return -1;
			}
		} else{
			/*Someone done goofed, this item should have an effect attached!...or maybe not...*/
			return -2;
		}
	}
}
