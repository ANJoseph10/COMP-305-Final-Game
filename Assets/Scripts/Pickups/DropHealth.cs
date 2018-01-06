using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHealth : DropClass {

	void Start(){
		dropName = "EnergyPack";
	}

	public override void PickUp(){
		PlayerController p = GameObject.Find("Player").GetComponent<PlayerController>();
		p.health = p.healthMax;
		Destroy(this.gameObject, 0);
	}
}
