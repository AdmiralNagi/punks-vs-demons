using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {
	[SerializeField]private GameObject winLossPanel;
	[SerializeField]private Text winLossText;
	[SerializeField]private GameObject songManager;
	private float lastNote;

	// Use this for initialization
	void Start () {
		winLossPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (lastNote <= 0) {
			int lastNoteIndex = songManager.GetComponent<SongManager> ().notes.Length - 1;
			lastNote = songManager.GetComponent<SongManager> ().notes [lastNoteIndex];
		}

		if (GetComponentInParent<BoundaryController> ().Demons >= 99) {
			winLossPanel.SetActive (true);
			winLossText.text = "DEMONS RECKT THE SHOW";
			winLossText.color = new Color (160f, 0f, 0f);
			Time.timeScale = 0f;
			if (songManager.GetComponent<SongManager> ().song) {
				songManager.GetComponent<SongManager> ().song.Pause ();
			} else {
				songManager.SetActive (false);
			}
		} else if (lastNote < songManager.GetComponent<SongManager> ().trackPosInBeats) {
			winLossPanel.SetActive (true);
			winLossText.text = "YOU VANQUISHED";
			winLossText.color = new Color (0f, 89f, 41f);
			Time.timeScale = 0f;
			if (songManager.GetComponent<SongManager> ().song) {
				songManager.GetComponent<SongManager> ().song.Pause ();
			} else {
				songManager.SetActive (false);
			}
		}
	}
}
