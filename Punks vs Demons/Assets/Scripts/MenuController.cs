using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
	[SerializeField]private SongSettings songSettings;
	public Text bpm;
	public Text beatsPerMeasure;

	// Use this for initialization
	void Start () {
		bpm.text = songSettings.bpm.ToString ();
		beatsPerMeasure.text = songSettings.beatsPerMeasure.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		bpm.text = songSettings.bpm.ToString ();
		beatsPerMeasure.text = songSettings.beatsPerMeasure.ToString ();
	}

	public void BpmUp(){
		if(songSettings.bpm < 140){
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
}
