using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalNoteCollision : MonoBehaviour {

	private bool onGoal = false;
	public bool OnGoal {
		set{ onGoal = value; }
		get{ return onGoal;}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Note")) {
			onGoal = true;
			//Debug.Log (onGoal.ToString ());
		}
	}

	void OnTriggerExit(Collider other){
		if (other.CompareTag ("Note")) {
			onGoal = false;
			//Debug.Log (onGoal.ToString ());
		}
	}
}
