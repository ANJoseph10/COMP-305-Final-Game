using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConstraint : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "bullet_destroy"){
			Destroy(this.gameObject, 0.1f);
		}
	}

}
