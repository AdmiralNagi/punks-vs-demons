using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void LoadScene(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			SceneManager.LoadScene (1);
		} else
			SceneManager.LoadScene (0);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
