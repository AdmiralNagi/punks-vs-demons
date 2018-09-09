using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TrackNote : MonoBehaviour {

	public SongManager songManager;
	//arrays of note colors, starting points, and end points
	public Material[] noteColors;

	//index number of the current color
	private int whatColorIndex;
	Vector3 originPos;
	Vector3 endPos;
	float beatsShownEarly;
	float beatOfThisNote;
	float trackPosInBeats;

	// Use this for initialization
	void Start () {
		songManager = GameObject.Find ("SongManager").GetComponent<SongManager> ();
		beatsShownEarly = songManager.beatsShownEarly;
		if(songManager.noteIndex < songManager.notes.Length)
			beatOfThisNote = songManager.notes [songManager.noteIndex];
		//currently this is random, but this will change to hard programmed after track editor is complete
		whatColorIndex = Random.Range(0,noteColors.Length);
		gameObject.GetComponent<Renderer> ().material = noteColors [whatColorIndex];

		originPos = songManager.originPositions [whatColorIndex].position;
		endPos = songManager.endPositions [whatColorIndex].position;
		transform.position = originPos;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (originPos, endPos,
			(beatsShownEarly - (beatOfThisNote - songManager.trackPosInBeats)) / beatsShownEarly);

		if (transform.position.Equals (endPos)) {
			songManager.metronomeClick.Play ();
			Destroy (gameObject);
		}
	}
}
