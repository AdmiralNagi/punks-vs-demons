using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	public int stage = 1;

	public void LoadScene(){
		Time.timeScale = 1f;

		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			SceneManager.LoadScene (stage);
		} else
			SceneManager.LoadScene (0);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
