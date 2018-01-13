using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public int score;
	public int combo = 1;

	public GameObject scoreText;
	public GameObject comboText;
	

	public void ResetCombo(){
		combo = 0;
	}


	public void AddScore(int add){
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "level1")
        {
            score += add;
            
            //If level is still 1 then run this
            if (score >= 30000 && sceneName == "level1")
            {
                SceneManager.LoadScene(4);
            }
         }
         if (sceneName == "level2")
         {
             score = 30000;
             score += add;
         }
        //if level is 2 then run this
        if (score >= 33000 && sceneName == "level2")
        {
            SceneManager.LoadScene(5);
        }
        //if score reaches this then boss will appear
        if (sceneName == "boss")
        {
            score = 33000;
            score += add;
        }
        
    }

    public void UpdateUI(){
        scoreText.GetComponent<Text>().text = score.ToString();
        comboText.GetComponent<Text>().text = combo.ToString();
	}
}
