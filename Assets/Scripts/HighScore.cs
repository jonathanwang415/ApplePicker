using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	static public int score = 1000;
	private Text highScore; 

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		// Track the high score
		int currentScore = ApplePicker.scoreCounter;
		if (currentScore > HighScore.score) {
			HighScore.score = currentScore;
		}
		highScore.text = "High Score: " + score;
		// Update ApplePickerHighScore in PlayerPrefs if necessary
	}

	void Awake() {
		// If the ApplePickerHighScore already exists, read it
		if (PlayerPrefs.HasKey("ApplePickerHighScore")) {
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}

		// Assign the high score to ApplePickerHighScore
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
		highScore = this.GetComponent<Text>();
		highScore.text = "High Score: " + score;
	}
}
