using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneratorScript : MonoBehaviour {

	public GameObject toSpawn;

	private int currentTime = 0;
	public int interval = 100;
	public int maxEnemies = 12;    
    public int maxBoss = 1;

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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "level1" && toSpawn != null && !(folder.transform.childCount > maxEnemies) ){
			float ySpawn = 12;
			float xSpawn = Random.Range(-4.9f, -10f);
        
			Vector2 pos = new Vector2(xSpawn, ySpawn);
			GameObject myEnemy = Instantiate(toSpawn, pos, Quaternion.identity);
			
			myEnemy.transform.position = new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y, -5 );
			myEnemy.transform.SetParent( folder );
		}
        if (sceneName == "level2" && toSpawn != null && !(folder.transform.childCount > maxEnemies + 3))
        {
            float ySpawn = 12;
            float xSpawn = Random.Range(-4.9f, -10f);

            Vector2 pos = new Vector2(xSpawn, ySpawn);
            GameObject myEnemy = Instantiate(toSpawn, pos, Quaternion.identity);

            myEnemy.transform.position = new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y, -5);
            myEnemy.transform.SetParent(folder);
        }
        if (sceneName == "boss" && toSpawn != null && !(folder.transform.childCount > maxBoss))
        {
            float ySpawn = 12;
            float xSpawn = Random.Range(-4.9f, -10f);

            Vector2 pos = new Vector2(xSpawn, ySpawn);
            GameObject myEnemy = Instantiate(toSpawn, pos, Quaternion.identity);

            myEnemy.transform.position = new Vector3(myEnemy.transform.position.x, myEnemy.transform.position.y, -5);
            myEnemy.transform.SetParent(folder);
        }
    }
}
