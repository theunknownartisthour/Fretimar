using UnityEngine;
using System.Collections;

public class ItemEffect : MonoBehaviour {

	/*Small list of potential variables to use on child objects...
	* Feel free to make this larger*
	*/
	public float health;
	public float poison;
	public float attack;
	public float defense;
	public float hunger;
	public float thirst;
	public float air;
	public float warmth;
	public float durability;
	
	/*-1 uses means infinite usage*/
	public int uses;
	
	[Range(0, 100)]
	public int successRate = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*Targetless Usage...needs no object, does something globally, may affect world...give feedback with an int*/
	public virtual int Use () {
		/*Do something to the world*/
		return 0;
	}
	
	/*Inventory always calls Use with a target...give feedback with an int*/
	public virtual int Use (GameObject targetGameObject) {
		/*Call Use without a target in case a global thing should happen too*/
		int feedback = Use();
		/*Do something to this poor targetGameObject*/
		/*Change feedback perhaps?*/
		
		/*We're done*/
		return feedback;
	}
}
