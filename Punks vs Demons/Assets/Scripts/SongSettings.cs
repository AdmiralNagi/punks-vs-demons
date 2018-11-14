using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSettings : MonoBehaviour {
	
	private static bool created = false;
	public bool songChosen = true;
	public AudioClip[] songList;
	public SongBeats songBeats;
	public int songIndex;


	void Awake(){
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}
	}

	public float bpm = 140;
	public float beatsPerMeasure = 4;

	void Start(){
		bpm = 200;
		beatsPerMeasure = 4;
	}
}
