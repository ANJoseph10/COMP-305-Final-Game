using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerComponent : MonoBehaviour {

	public GameObject player;
	public GameObject barEnergy;
	public GameObject barHealth;
	private PlayerController playerScript;

	void Start(){
		playerScript = player.GetComponent<PlayerController>();
	}

	void Update(){
		ResizeEnergy(playerScript.energy);
		ResizeHealth(playerScript.health);

	}
	private void ResizeEnergy(int val){
		val = val/10;
		var bar = barEnergy.transform as RectTransform;
		bar.sizeDelta = new Vector2(val,10.9f);
	}
	private void ResizeHealth(int val){
		var bar = barHealth.transform as RectTransform;
		bar.sizeDelta = new Vector2(val,10.9f);
	}
}
