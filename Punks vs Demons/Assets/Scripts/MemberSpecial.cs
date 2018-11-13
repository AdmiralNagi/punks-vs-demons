using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberSpecial : MonoBehaviour {
	private float specialValue;
	public float SpecialValue{
		set { specialValue = value; }
		get { return specialValue; }
	}
	[SerializeField]private float maxSpecial;
	public float MaxSpecial{
		get { return maxSpecial; }
	}

	[SerializeField]private RectTransform specialBar;
	[SerializeField]private Text spDisplay;
	[SerializeField]private Text spIcon;
	private bool specialAvailable = false;
	public bool SpecialAvailable{
		get{ return specialAvailable; }
	}


	[SerializeField]private GameObject spButton;
	void Update () {
		UpdateSpecialTextAndBar ();
		if (SpecialCheck ()) {
			StartLerp ();
		}
		spButton.gameObject.SetActive (specialAvailable);
		SpecialLerp ();
	}

	void UpdateSpecialTextAndBar() {
		if (specialValue >= 10) {
			spDisplay.text = "SP " + (int)specialValue + "/" + maxSpecial;
		} else {
			spDisplay.text = "SP 0" + (int)specialValue + "/" + maxSpecial;
		}

		specialBar.anchorMax = new Vector2 (specialValue / maxSpecial, 1f);
	}

	bool SpecialCheck(){
		if (specialValue == maxSpecial) {
			specialAvailable = true;
		} else {
			specialAvailable = false;
		}

		return specialAvailable;
	}

	bool isLerping;
	float startingAlpha;
	float targetAlpha;
	public float fadeTime = 1f;
	private float startFade;
	void SpecialLerp(){
		if (isLerping) {
			startFade += Time.deltaTime;

			if (startFade > fadeTime) {
				startFade = fadeTime;
				isLerping = false;
			}

			float perc = startFade / fadeTime;
			float alpha = Mathf.Lerp (startingAlpha, targetAlpha, perc);
			spIcon.color = new Color (spIcon.color.r, spIcon.color.g, spIcon.color.b, alpha);
		}
	}

	void StartLerp(){
		if (!isLerping) {
			startingAlpha = spIcon.color.a;
			if (startingAlpha > 0) {
				targetAlpha = 0;
			} else {
				targetAlpha = 1f;
			}
			startFade = 0f;
			isLerping = true;
		}
	}
}
