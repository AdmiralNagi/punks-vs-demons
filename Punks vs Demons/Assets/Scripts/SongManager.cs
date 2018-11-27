using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SongManager : MonoBehaviour {
	private SongSettings songSettings;
	public Transform[] originPositions;
	public Transform[] endPositions;
	public Transform[] bandMember;
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
	public float beatsPerMeasure = 4;

	void Awake(){
		FindAndSetSongSettings ();

	}

	void FindAndSetSongSettings(){
		if (GameObject.Find ("SongSettings") != null) {
			songSettings = GameObject.Find ("SongSettings").GetComponent<SongSettings> ();
			bpm = songSettings.bpm;
			beatsPerMeasure = songSettings.beatsPerMeasure;
		}
	}

	void Start () {
		InstantiateLaneNotes ();
		secPerBeat = 60f / bpm;
		beatsShownEarly = 10;
		dsptimesong = (float)AudioSettings.dspTime;

		if (!songSettings || songSettings.songChosen == false) {
			SetMetronome ();
		} else if (songSettings.songChosen == true) {
			SetSong ();
		}
	}

	void InstantiateLaneNotes(){
		LaneNotes = new List<GameObject>[4];
		for (int i = 0; i < LaneNotes.Length; i++) {
			LaneNotes[i] = new List<GameObject>();
		}
	}

	void SetMetronome(){
		notes = new float[(int)((bpm * trackLengthInMin) / beatsPerMeasure)];
		for (int x = 0; x < notes.Length; x++) {
			notes [x] = (float)(x) * beatsPerMeasure + beatsShownEarly - beatsPerMeasure;
		}
	}

	public bool songSet = false;
	void SetSong(){
		notes = song.GetComponent<SongBeats> ().songs[songSettings.songIndex];
		song.clip = songSettings.songList [songSettings.songIndex];
		song.Play ();
		songSet = true;
	}
		
	void Update () {
		trackPosistion = (float)(AudioSettings.dspTime - dsptimesong);
		CreateNote ();
		trackPosInBeats = trackPosistion / secPerBeat;
	}

	void CreateNote(){
		if (noteIndex < notes.Length && notes [noteIndex] < trackPosInBeats + beatsShownEarly + spawnTime) {
			GameObject newNote = Instantiate (note);
			int listIndex = newNote.GetComponent<TrackNote>().WhatColorIndex;
			LaneNotes [listIndex].Add (newNote);
		}
	}
}
