using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropClass : MonoBehaviour {

	[HideInInspector] public string dropName = "Unnamed Item";
	public bool stackable = false;
	
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.name == "Player"){
			PickUp();
		}
	}

	public virtual void PickUp(){
		Destroy(this.gameObject, 0);
	}

}
