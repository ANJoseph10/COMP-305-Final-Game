using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Vector3 offset;

	void Start(){
		offset = new Vector3(0, 0, 0);
	}

	void Update () {
		this.transform.position = GameObject.Find("Player").transform.position + offset;
	}
}
