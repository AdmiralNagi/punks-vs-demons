using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TrackNote : MonoBehaviour {

	public SongManager songManager;
	//arrays of note colors, starting points, and end points
	[SerializeField]private Sprite[] noteColor;

	//index number of the current color
	private int whatColorIndex;
	public int WhatColorIndex {
		get {return whatColorIndex;}
	}

	Vector3 originPos;
	Vector3 endPos;
	Vector3 bandMemberPosition;
	[SerializeField]Vector3 spawnPos;
	bool endReached = false;
	bool originReached = false;
	[SerializeField]private float destroySpeed;
	float beatsShownEarly;
	float spawnTime;
	float beatOfThisNote;
	float trackPosInBeats;

	void Awake (){
		//currently this is random, but this will change to hard programmed after track editor is complete
		whatColorIndex = Random.Range(0,noteColor.Length);
	}

	// Use this for initialization
	void Start () {
		songManager = GameObject.Find ("SongManager").GetComponent<SongManager> ();
		beatsShownEarly = songManager.beatsShownEarly;
		spawnTime = songManager.spawnTime;
		if(songManager.noteIndex < songManager.notes.Length)
			beatOfThisNote = songManager.notes [songManager.noteIndex];

		//gameObject.GetComponent<Renderer> ().material = noteColors [whatColorIndex];
		gameObject.GetComponentInChildren<SpriteRenderer>().sprite = noteColor[whatColorIndex];

		originPos = songManager.originPositions [whatColorIndex].position;
		endPos = songManager.endPositions [whatColorIndex].position;
		bandMemberPosition = songManager.bandMember [whatColorIndex].position;
		spawnPos = songManager.spawnPosition.position;
		transform.position = spawnPos;
	}
	
	// Update is called once per frame
	void Update () {
		MoveNote ();
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("DestroyNote")){
			songManager.LaneNotes [whatColorIndex].Remove (gameObject);
			Destroy(gameObject);
		}
	}

	float currentDestroyTime;
	[SerializeField]private float destroyTime;
	void MoveNote () {
		if (!endReached && originReached) {
			transform.position = Vector3.Lerp (originPos, endPos,
				(beatsShownEarly - (beatOfThisNote - songManager.trackPosInBeats)) / beatsShownEarly);
		} else if (!originReached) {
			transform.position = Vector3.Lerp (spawnPos, originPos, 
				(spawnTime - (beatOfThisNote - beatsShownEarly - songManager.trackPosInBeats)) / spawnTime);
		} else if (endReached) {
			
			currentDestroyTime += Time.deltaTime;
			if (currentDestroyTime > destroyTime) {
				currentDestroyTime = destroyTime;
			}

			transform.position = Vector3.Lerp (endPos, bandMemberPosition, currentDestroyTime/destroyTime);
		}
			
		if (transform.position.Equals (endPos)) {
			if (!endReached) {
				currentDestroyTime = 0f;
				endReached = true;
			}
		}
			
		if (transform.position.Equals (originPos)) {
			originReached = true;
		}		
	}
}
