using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {

	public GameObject toSpawn;

	private int currentTime = 0;
	public int interval = 100;
	public int maxEnemies = 12;

	private Transform folder;

	void Start () {
		folder = GameObject.Find("DynamicEnemies").transform;
	}
	
	void Update () {
		if (currentTime >= interval){
			SpawnEnemy();
			currentTime = Random.Range(0,30);
		} else {
			currentTime++;
		}
	}

	void SpawnEnemy(){
		if (toSpawn != null && !(folder.transform.childCount > maxEnemies) ){
			float ySpawn = 12;
			float xSpawn = Random.Range(-10, -4);

			Vector2 pos = new Vector2(xSpawn, ySpawn);
			GameObject myEnemy = Instantiate(toSpawn, pos, Quaternion.identity);
			
			myEnemy.transform.position = new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y, -5 );
			myEnemy.transform.SetParent( folder );
		}
	}
}
