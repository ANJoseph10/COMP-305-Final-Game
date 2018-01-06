using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public int score;
	public int combo = 1;

	public GameObject scoreText;
	public GameObject comboText;
	

	public void ResetCombo(){
		combo = 0;
	}

	public void AddScore(int add){
		score += add;
	}

	public void UpdateUI(){
		scoreText.GetComponent<Text>().text = score.ToString();
		comboText.GetComponent<Text>().text = combo.ToString();
	}
}
