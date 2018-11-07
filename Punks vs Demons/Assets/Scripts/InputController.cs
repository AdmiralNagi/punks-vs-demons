using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

	[SerializeField]private GoalNoteCollision noteLocation;
	[SerializeField]private BoundaryController punksDemonRatio;
	private int laneIndex;
	public Text resultText;
	[SerializeField]private SongManager songManager;
	[SerializeField]private MemberHealth health;
	[SerializeField]private MemberSpecial sp;
	[SerializeField]private Button thisButton;
	[SerializeField]private GameObject timingRing;
	[SerializeField]private GameObject badTimingRing;

	// Use this for initialization
	void Start () {
		resultText.text = "";
		laneIndex = int.Parse (noteLocation.gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		if (health.CurrentHealth <= 0) {
			thisButton.interactable = false;
		} else if (health.CurrentHealth >= health.MaxHealth){
			thisButton.interactable = true;
		}
	}

	public void LaneButtonPress(){
		if (noteLocation.OnGoal){
			resultText.color = Color.green;
			resultText.text = "GOOD";
			if (sp.SpecialValue < sp.MaxSpecial) {
				sp.SpecialValue++;
			}
			timingRing.SetActive(true);
			StartCoroutine("TextFlash");

			if (punksDemonRatio.Punks < 99) {
				punksDemonRatio.Punks++;
				punksDemonRatio.Demons--;
			}

			if (songManager.LaneNotes [laneIndex].Count > 0) {
				GameObject noteToDestroy = songManager.LaneNotes [laneIndex] [0].gameObject;
				songManager.LaneNotes [laneIndex].RemoveAt(0);
				Destroy (noteToDestroy);
				noteLocation.OnGoal = false;
			}
		}
		else{
			resultText.color = Color.red;
			resultText.text = "BAD";
			badTimingRing.SetActive (true);
			StartCoroutine("TextFlash");

			if (punksDemonRatio.Demons < 99) {
				punksDemonRatio.Punks--;
				punksDemonRatio.Demons++;
			}
		}

	}

	IEnumerator TextFlash(){
		yield return new WaitForSeconds (0.25f);
		resultText.text = "";
		badTimingRing.SetActive(false);
		timingRing.SetActive (false);
	}
}
