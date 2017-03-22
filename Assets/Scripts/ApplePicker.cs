using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;

	private Text scoreCounterText;
	static public int scoreCounter;

	void Start () {
		basketList = new List<GameObject>();
		scoreCounterText = GameObject.Find("ScoreCounter").GetComponent<Text>();

		// Set the starting number of points to 0
		scoreCounter = 0;
		scoreCounterText.text = "" + scoreCounter;

		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO );
		}
	}

	public void AppleDestroyed() {                                         
		// Destroy all of the falling Apples
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
		foreach ( GameObject tGO in tAppleArray ) {
			Destroy( tGO );
		}

		//// Destroy one of the Baskets
		// Get the index of the last Basket in basketList
		int basketIndex = basketList.Count-1;
		// Get a reference to that Basket GameObject
		GameObject tBasketGO = basketList[basketIndex];
		// Remove the Basket from the List and destroy the GameObject
		basketList.RemoveAt( basketIndex );
		Destroy( tBasketGO );

		// Restart the game, which doesn't affect HighScore.Score
		if ( basketList.Count == 0 ) {
			SceneManager.LoadScene ("_Scene_0");
			if (HighScore.score > PlayerPrefs.GetInt("ApplePickerHighScore")) {
				PlayerPrefs.SetInt("ApplePickerHighScore", HighScore.score);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		scoreCounterText.text = "" + scoreCounter;
	}
}