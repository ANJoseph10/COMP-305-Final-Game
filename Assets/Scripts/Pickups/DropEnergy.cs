using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEnergy : DropClass {

	void Start(){
		dropName = "EnergyPack";
	}

	public override void PickUp(){
		PlayerController p = GameObject.Find("Player").GetComponent<PlayerController>();
		p.energy = p.energyMax;
		Destroy(this.gameObject, 0);
	}
}
