using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscript : MonoBehaviour {

	public bool active = true;
	private bool prevState;

	private float defaultAl = 0.3f;
	private float al;

	[HideInInspector] public PlayerController player;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "bulletEnemy"){
			coll.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			Destroy(coll.gameObject);
		}
		player.energy -= 10;
		Hit();
	}

	void Update(){
		if (active){
			this.gameObject.SetActive(true);
		} else {
			this.gameObject.SetActive(false);
		}
		prevState = active;

		this.GetComponent<SpriteRenderer>().color = new Color(1, 0.2f, 0.2f, al);
		if (al > defaultAl){
			al -= 0.05f;
		} else {
			al = defaultAl;
		}
	}

	void Hit(){
		al = 0.7f;
	}

}
