using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public int score;
    public int score2;
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
            if (score == 1000 && sceneName == "level1")
            {
                SceneManager.LoadScene(4);
            }
         }
         if (sceneName == "level2")
         {
             score2 = 1000;
             score2 += add;
         }
         //if level is 2 then run this
         //if (score == 3000 && sceneName == "level2")
         //{
         //if score reaches this then boss will appear
         //if (score == 3000)
         //{
         //    SceneManager.LoadScene(5);
         //}
         //}
    }

    public void UpdateUI(){
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        while (sceneName == "level1")
        {
            scoreText.GetComponent<Text>().text = score.ToString();
        }
        while (sceneName == "level2")
        {
            scoreText.GetComponent<Text>().text = score2.ToString();
        }
        comboText.GetComponent<Text>().text = combo.ToString();
	}
}
