using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour {

	public static float bottomY = -20f;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );
			// Get a reference to the ApplePicker component of Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			// Call the public AppleDestroyed() method of apScript
			apScript.AppleDestroyed();
		}
	}

	void OnCollisionEnter( Collision coll ) {
		// Find out what hit this basket
		//GameObject collidedWith = coll.gameObject;
		//if ( collidedWith.tag == "Basket" ) {
			Destroy( this.gameObject );
		//}

		// Parse the text of the scoreGT into an int
		int score = ApplePicker.scoreCounter;
		// Add points for catching the apple
		score += 100;
		// Convert the score back to a string and display it
		ApplePicker.scoreCounter = score;
	}
}