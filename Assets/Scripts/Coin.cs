using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Coin");
		if (collider.CompareTag ("Player")) {
			Destroy (gameObject);
		}
	}
}
