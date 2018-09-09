using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour {

	//current position in seconds
	float trackPosistion;
	//current position in beats
	float trackPosInBeats;
	//duration of a beat
	float secPerBeat;
	//time in seconds since start of track
	float dsptimesong;

	// Use this for initialization
	void Start () {
//		secPerBeat = 60f / bpm;
//
//		dsptimesong = (float)AudioSettings.dspTime;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
