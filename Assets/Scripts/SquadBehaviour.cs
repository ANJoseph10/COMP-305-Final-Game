using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadBehaviour : MonoBehaviour {

	public List<GameObject> myEnemies;
	private int sizeHorizontal;
	private int sizeVertical;
	public int maxEnemies;

	public GameObject toSpawnEnemy;

	void Start(){
		sizeHorizontal = 3;
		sizeVertical = 1;
		UpdateSize();
		GenerateEnemies();
	}

	bool CheckAlive(){
		if (myEnemies.Count > 0){
			return true;
		} else {
			return false;
		}
	}

	void GenerateEnemies(){
		while (myEnemies.Count <= maxEnemies){
			GameObject e = Instantiate(toSpawnEnemy, this.transform.position, Quaternion.identity);
			myEnemies.Add(e);
			//TODO: access newly created element from list.
			// e.squad trying to access GameObject Class instead of instance.
		}
	}

	void MoveAll(){
		foreach (GameObject e in myEnemies){
			e.GetComponent<BasicAIComponent>().Move();
		}
	}

	void UpdateSize(){
		if (sizeHorizontal > 0 && sizeVertical > 0){
			maxEnemies = sizeHorizontal * sizeVertical;	
		} else {
			print("sizeHorizontal: "+sizeHorizontal+" or sizeVertical: "+sizeVertical+" less than 0");
		}
	}
}
