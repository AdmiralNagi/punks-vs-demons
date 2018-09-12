using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongManager : MonoBehaviour {
	private SongSettings songSettings;
	public Transform[] originPositions;
	public Transform[] endPositions;
	//current position in seconds
	float trackPosistion;
	//current position in beats
	public float trackPosInBeats;
	//duration of a beat
	float secPerBeat;
	//time in seconds since start of track
	float dsptimesong;
	//how many beats are previewed
	public float beatsShownEarly;

	public float bpm = 120;
	public float[] notes;
	public int noteIndex=0;

	//prototyping purposes
	public float trackLengthInMin;
	public GameObject note;
	[SerializeField]private float beatsPerMeasure = 4;

	void Awake(){
		if (GameObject.Find ("SongSettings") != null) {
			songSettings = GameObject.Find ("SongSettings").GetComponent<SongSettings> ();
			bpm = songSettings.bpm;
			beatsPerMeasure = songSettings.beatsPerMeasure;
		}
	}
	// Use this for initialization
	void Start () {
		

		secPerBeat = 60f / bpm;
		beatsShownEarly = 10;

		dsptimesong = (float)AudioSettings.dspTime;

		//prototyping purposes
		notes = new float[(int)(bpm*(trackLengthInMin * beatsPerMeasure))];
		for (int x = 0; x < notes.Length; x++) {
			notes [x] = (float)(x) * beatsPerMeasure + beatsShownEarly - beatsPerMeasure + 1.0f;
		}
		//

		//GetComponent<AudioSource> ().Play ();
	}
		
	// Update is called once per frame
	void Update () {
		trackPosistion = (float)(AudioSettings.dspTime - dsptimesong);

		if (noteIndex < notes.Length && notes [noteIndex] < trackPosInBeats + beatsShownEarly) {
			Instantiate (note);

			noteIndex++;
		}

		trackPosInBeats = trackPosistion / secPerBeat;
	}
}
