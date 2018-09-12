using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSettings : MonoBehaviour {
	
	private static bool created = false;

	void Awake(){
		if (!created) {
			DontDestroyOnLoad (this.gameObject);
			created = true;
		}
	}

	public float bpm = 120;
	public float beatsPerMeasure = 4;

	void Start(){
		bpm = 120;
		beatsPerMeasure = 4;
	}
}
