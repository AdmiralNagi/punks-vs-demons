using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	[SerializeField]private SceneController sceneController;
	private SongSettings songSettings;
	public Button firstSong;
	public Button secondSong;
	public GameObject stage1;
	public GameObject stage2;
	public GameObject howToPlay;
	public Text bpm;
	public Text beatsPerMeasure;
	public Text songButton;
	public Text songTitle;

	private string[ , ] songTitleArray = {{"\"STORM\"\nNORMCORE", "\"ABCD\"\nPUDGE"},
		{"\"PUNK FOR FASHION\"\nPSYCHOTIC REACTION","\"SONGTILE\"\nARTIST" }};

	// Use this for initialization
	void Start () {
		songSettings = GameObject.Find ("SongSettings").GetComponent<SongSettings>();
		bpm.text = songSettings.bpm.ToString ();
		beatsPerMeasure.text = songSettings.beatsPerMeasure.ToString ();
		bpmTemp = songSettings.bpm;
	}
	
	// Update is called once per frame
	void Update () {
		songTitle.text = songTitleArray [sceneController.stage - 1, songTitleIndex];
		bpm.text = songSettings.bpm.ToString ();
		beatsPerMeasure.text = songSettings.beatsPerMeasure.ToString ();
	}

	public void BpmUp(){
		if(songSettings.bpm < 240){
			songSettings.bpm++;
		}
	}

	public void BpmDown(){
		if(songSettings.bpm > 60){
			songSettings.bpm--;
		}
	}

	public void MeasureUp(){
		if(songSettings.beatsPerMeasure < 8){
			songSettings.beatsPerMeasure++;
		}
	}

	public void MeasureDown(){
		if(songSettings.beatsPerMeasure > 1){
			songSettings.beatsPerMeasure--;
		}
	}

	public void fashionSong(){
		songSettings.songChosen = true;
		songSettings.bpm = 200f;
		songSettings.songIndex = 0;
	}

	public void stormSong(){
		songSettings.songChosen = true;
		songSettings.bpm = 105f;
		songSettings.songIndex = 1;
	}

	void abcdSong(){
		songSettings.songChosen = true;
		songSettings.bpm = 139f;
		songSettings.songIndex = 2;
	}

	public void StageOne(){
		stage1.SetActive (true);
		stage2.SetActive (false);
		sceneController.stage = 1;
	}

	public void StageTwo(){
		stage1.SetActive (false);
		stage2.SetActive (true);
		sceneController.stage = 2;
	}

	public void HowToPlay(){
		howToPlay.SetActive (!howToPlay.activeInHierarchy);
	}

	public void SongOne(){
		if (sceneController.stage == 1) {
			stormSong ();
		} else if (sceneController.stage == 2) {
			fashionSong ();
		}
	}

	public void SongTwo(){
		if (sceneController.stage == 1) {
			abcdSong ();
		}
	}

	private int songTitleIndex = 0;
	public void RightArrow(){
		if (songTitleIndex < songTitleArray.GetLength(sceneController.stage - 1) -1) {
			songTitleIndex++;
		} else {
			songTitleIndex = 0;
		}
	}

	public void LeftArrow(){
		if (songTitleIndex > 0) {
			songTitleIndex--;
		} else {
			songTitleIndex = songTitleArray.GetLength(sceneController.stage - 1) -1;
		}
	}

	public void Rock(){
		if (!jamOn) {
			if (songTitleIndex == 0) {
				SongOne ();
			} else if (songTitleIndex == 1) {
				SongTwo ();
			}
		}

		sceneController.LoadScene ();
	}

	public GameObject practicePanel;
	public Text practiceBtnText;
	private float bpmTemp;
	private bool jamOn = false;
	public void ActivatePractice(){
		songSettings.songChosen = !(songSettings.songChosen);
		practicePanel.SetActive (!(songSettings.songChosen));
		if (practicePanel.activeInHierarchy) {
			jamOn = true;
			songSettings.bpm = bpmTemp;
			practiceBtnText.text = "BACK";
		} else {
			jamOn = false;
			bpmTemp = songSettings.bpm;
			songSettings.bpm = 120f;
			practiceBtnText.text = "JAM";
		}
	}
}
