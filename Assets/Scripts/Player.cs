using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 50.0F;
	public float jumpForce = 150.0F;
	public float maxSpeed = 3.0F;
	public bool grounded; 

	public int curHealth;
	public int maxHealth = 5;

	[SerializeField]
	private Rigidbody2D rb2d;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private AudioSource jumpSound;

	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		jumpSound = GetComponent<AudioSource> ();
	}

	void Start () {
		curHealth = maxHealth;
	}

	void Update () {
		animator.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		animator.SetBool ("Grounded", grounded);
		if (Input.GetAxis ("Horizontal") < -0.1F) {
			transform.localScale = new Vector3 (3, 3, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1F) {
			transform.localScale = new Vector3 (-3, 3, 1);
		}
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		if (curHealth <= 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}
	}

	void FixedUpdate () {
		// Передвижение влево и вправо
		rb2d.AddForce (Vector2.right * speed * Input.GetAxis ("Horizontal"));
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
		// Прыжок
		if (Input.GetButtonDown ("Jump") && grounded) {
			rb2d.AddForce (Vector2.up * jumpForce);
			jumpSound.Play ();
		} 
	}

	public void Die () {
		curHealth = 0;
	}

	public void Damage (int damage) {
		curHealth -= damage;
	}
}
