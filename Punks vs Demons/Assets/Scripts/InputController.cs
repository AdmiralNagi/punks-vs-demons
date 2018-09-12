using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	[SerializeField]private GoalNoteCollision noteLocation;
	public Text resultText; 
	private string lanePosition;
	private Vector2 touchOrigin = -Vector2.one;

	// Use this for initialization
	void Start () {
		resultText.text = "";
		lanePosition = gameObject.tag.Substring (6);
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_STANDALONE || UNITY_EDITOR

		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100.0f)){
				if (hit.collider.tag.Contains("Origin" + lanePosition)){
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
				}
			}
		}

		#else

		if(Input.touchCount > 0 ){
			Touch myTouch = Input.touches[0];

			if (myTouch.phase == TouchPhase.Began){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(myTouch.position);

				if (Physics.Raycast(ray, out hit, 100.0f)){
					if (hit.collider.tag.Contains("Origin" + lanePosition)){
						if (noteLocation.OnGoal){
							resultText.color = Color.green;
							resultText.text = "GOOD";
						}
						else{
							resultText.color = Color.red;
							resultText.text = "BAD";
						}
					}
				}
			}
		}

		#endif
	}

	IEnumerator TextFlash(){
		yield return new WaitForSeconds (0.25f);
		resultText.text = "";
	}
}
