using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	[SerializeField]private GoalNoteCollision noteLocation;
	private int laneIndex;
	public Text resultText;
	[SerializeField]private SongManager songManager;

	// Use this for initialization
	void Start () {
		resultText.text = "";
		laneIndex = int.Parse (noteLocation.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
//		#if UNITY_STANDALONE || UNITY_EDITOR
//
//		if (Input.GetMouseButtonDown(0)){
//			RaycastHit hit;
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//
//			if (Physics.Raycast(ray, out hit, 100.0f)){
//				if (hit.collider.tag.Contains("End_" + lanePosition)){
//					if (noteLocation.OnGoal){
//						resultText.color = Color.green;
//						resultText.text = "GOOD";
//						StartCoroutine("TextFlash");
//					}
//					else{
//						resultText.color = Color.red;
//						resultText.text = "BAD";
//						StartCoroutine("TextFlash");
//					}
//				}
//			}
//		}
//
//		#else
//
//		if(Input.touchCount > 0 ){
//			Touch myTouch = Input.touches[0];
//
//			if (myTouch.phase == TouchPhase.Began){
//				RaycastHit hit;
//				Ray ray = Camera.main.ScreenPointToRay(myTouch.position);
//
//				if (Physics.Raycast(ray, out hit, 100.0f)){
//					if (hit.collider.tag.Contains("Origin" + lanePosition)){
//						if (noteLocation.OnGoal){
//							resultText.color = Color.green;
//							resultText.text = "GOOD";
//						}
//						else{
//							resultText.color = Color.red;
//							resultText.text = "BAD";
//						}
//					}
//				}
//			}
//		}
//
//		#endif
	}

	public void LaneButtonPress(){
		if (noteLocation.OnGoal){
			resultText.color = Color.green;
			resultText.text = "GOOD";
			StartCoroutine("TextFlash");
		}
		else{
			resultText.color = Color.red;
			resultText.text = "BAD";
			StartCoroutine("TextFlash");
		}

		if (songManager.LaneNotes [laneIndex].Count > 0) {
			Debug.Log (laneIndex.ToString ());
			GameObject noteToDestroy = songManager.LaneNotes [laneIndex] [0].gameObject;
			songManager.LaneNotes [laneIndex].RemoveAt(0);
			Destroy (noteToDestroy);
			noteLocation.OnGoal = false;
		}

	}

	IEnumerator TextFlash(){
		yield return new WaitForSeconds (0.25f);
		resultText.text = "";
	}
}
