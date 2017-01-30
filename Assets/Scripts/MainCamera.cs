using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public float smoothTimeX;
	public float smoothTimeY;
	public bool bounds;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	private Player player;
	private Vector2 velocity;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void FixedUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
		transform.position = new Vector3 (posX, posY, transform.position.z);
		if (bounds) {
			transform.position = new Vector3 (
				Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z)
			);
		}
	}
}
