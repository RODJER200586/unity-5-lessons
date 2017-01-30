using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private Player player;

	void Awake () {
		player = gameObject.GetComponentInParent<Player> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.CompareTag ("Ground")) {
			player.grounded = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.CompareTag ("Ground")) {
			player.grounded = false;
		}
	}
}
