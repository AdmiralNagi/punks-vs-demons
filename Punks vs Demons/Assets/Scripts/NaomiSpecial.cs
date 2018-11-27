using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaomiSpecial : MonoBehaviour {
	public ScoreController scoreController;
	public Text multiplierTitleText;
	public Text multiplierText;
	public MemberSpecial naomi;
	public float specialDuration = 10f;

	private Color lightBlue;

	void Start(){
		lightBlue = new Color (0f, 1f, 250f / 255f);
	}

	public void DoubleMultiply() {
		naomi.SpecialValue = 0;
		multiplierText.color = lightBlue;
		multiplierTitleText.color = lightBlue;
		scoreController.specialMultiplier = 2;
		StartCoroutine ("SpecialDuration");
	}

	IEnumerator SpecialDuration(){
		yield return new WaitForSeconds (specialDuration);
		multiplierText.color = Color.white;
		multiplierTitleText.color = Color.white;
		scoreController.specialMultiplier = 1;
	}
}
