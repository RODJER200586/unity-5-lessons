using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	[SerializeField]
	private bool paused = false;

	void Awake () {
		pauseMenu.SetActive (false);
	}

	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			paused = !paused;
		}
		if (paused) {
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else {
			pauseMenu.SetActive (false);
			Time.timeScale = 1;
		}
	}

	// Запустить новую игру
	public void New () {
		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

	// Продолжить игру
	public void Continue () {
		paused = true;
		Debug.Log(paused);
	}

	// Выйти из игры
	public void Exit () {
		Application.Quit ();
	}
}
