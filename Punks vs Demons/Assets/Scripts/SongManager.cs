using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongManager : MonoBehaviour {
	private SongSettings songSettings;
	public Transform[] originPositions;
	public Transform[] endPositions;
	public Transform spawnPosition;

	public List<GameObject>[] LaneNotes;

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
	public float spawnTime;

	public float bpm = 120;
	public float[] notes;
	public int noteIndex=0;

	//prototyping purposes
	public float trackLengthInMin;
	public GameObject note;
	public AudioSource song;
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
		LaneNotes = new List<GameObject>[4];
		for (int i = 0; i < LaneNotes.Length; i++) {
			LaneNotes[i] = new List<GameObject>();
		}

		secPerBeat = 60f / bpm;
		beatsShownEarly = 10;

		dsptimesong = (float)AudioSettings.dspTime;

		if (!songSettings || songSettings.fashionPunk == false) {
			//prototyping purposes
			notes = new float[(int)((bpm * trackLengthInMin) / beatsPerMeasure)];
			for (int x = 0; x < notes.Length; x++) {
				notes [x] = (float)(x) * beatsPerMeasure + beatsShownEarly - beatsPerMeasure + 1.0f;
			}
		} else if (songSettings.fashionPunk == true) {
			notes = song.GetComponent<FashionPunk> ().fashionPunkBeats;
			song.Play ();
		}
	}
		
	// Update is called once per frame
	void Update () {
		trackPosistion = (float)(AudioSettings.dspTime - dsptimesong);

		if (noteIndex < notes.Length && notes [noteIndex] < trackPosInBeats + beatsShownEarly + spawnTime) {
			GameObject newNote = Instantiate (note);
			//int listIndex = note.GetComponent<TrackNote> ().WhatColorIndex;
			int listIndex = newNote.GetComponent<TrackNote>().WhatColorIndex;
			//Debug.Log (listIndex.ToString ());
			LaneNotes [listIndex].Add (newNote);
			noteIndex++;
		}

		trackPosInBeats = trackPosistion / secPerBeat;
	}
}
