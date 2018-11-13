using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	private SongSettings songSettings;
	public Text bpm;
	public Text beatsPerMeasure;
	public Text songButton;

	// Use this for initialization
	void Start () {
		songSettings = GameObject.Find ("SongSettings").GetComponent<SongSettings>();
		bpm.text = songSettings.bpm.ToString ();
		beatsPerMeasure.text = songSettings.beatsPerMeasure.ToString ();
		bpmTemp = songSettings.bpm;
	}
	
	// Update is called once per frame
	void Update () {
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

	public void PlaySong(){
		songSettings.songChosen = !(songSettings.songChosen);
	}

	public GameObject practicePanel;
	public Text practiceBtnText;
	private float bpmTemp;
	public void ActivatePractice(){
		songSettings.songChosen = !(songSettings.songChosen);
		practicePanel.SetActive (!(songSettings.songChosen));
		if (practicePanel.activeInHierarchy) {
			songSettings.bpm = bpmTemp;
			practiceBtnText.text = "BACK";
		} else {
			bpmTemp = songSettings.bpm;
			songSettings.bpm = 200f;
			practiceBtnText.text = "JAM";
		}
	}
}
