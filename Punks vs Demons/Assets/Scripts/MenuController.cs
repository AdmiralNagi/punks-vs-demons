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
		songButton.text = songSettings.fashionPunk.ToString();
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
		songSettings.bpm = 200;
		songSettings.beatsPerMeasure = 1;
		songSettings.fashionPunk = !(songSettings.fashionPunk);
		songButton.text = songSettings.fashionPunk.ToString ();
	}
}
