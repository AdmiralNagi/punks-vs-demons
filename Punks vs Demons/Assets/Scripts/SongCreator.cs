using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongCreator : MonoBehaviour {
	List<string> beats;
	public SongManager songManager;
	public AudioSource song;
	// Use this for initialization
	void Start () {
		song.Play ();
		beats = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			float roundedBeat = Mathf.Round(songManager.trackPosInBeats * 10f) / 10f;
			string currentBeat = Mathf.Round(songManager.trackPosInBeats * 2f) / 2f + "f, ";
			beats.Add (currentBeat);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			System.IO.File.WriteAllLines(@"C:\Users\God\Desktop\Beats\storm.txt", beats.ToArray());
		}
	}


}
