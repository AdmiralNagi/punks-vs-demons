using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {
	[SerializeField]private ScoreController scoreController;
	[SerializeField]private GameObject winPanel;
	[SerializeField]private GameObject lossPanel;
	[SerializeField]private Text finalScore;
	[SerializeField]private Text highScore;
	[SerializeField]private GameObject songManager;
	private float lastNote;

	// Use this for initialization
	void Start () {
		winPanel.SetActive (false);
		lossPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (lastNote <= 0) {
			int lastNoteIndex = songManager.GetComponent<SongManager> ().notes.Length - 1;
			lastNote = songManager.GetComponent<SongManager> ().notes [lastNoteIndex];
		}

		if (GetComponentInParent<BoundaryController> ().Demons >= 99) {
			lossPanel.SetActive (true);
			Time.timeScale = 0f;
			if (songManager.GetComponent<SongManager> ().songSet) {
				songManager.GetComponent<SongManager> ().song.Pause ();
			} else {
				songManager.SetActive (false);
			}
		} else if (lastNote < songManager.GetComponent<SongManager> ().trackPosInBeats) {
			winPanel.SetActive (true);
			finalScore.text = scoreController.scoreText.text;
			if (scoreController.PlayerScoreLoaded) {
				scoreController.SubmitPlayerScore ();
				highScore.text = scoreController.GetScoreText (scoreController.GetHighScore ());
			}
			Time.timeScale = 0f;
			if (songManager.GetComponent<SongManager> ().songSet) {
				songManager.GetComponent<SongManager> ().song.Pause ();
			} else {
				songManager.SetActive (false);
			}
		}
	}
}
