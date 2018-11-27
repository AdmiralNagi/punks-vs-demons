using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public Text scoreTextShadow;
	private int score;
	public Text multiplierText;
	public Text multiplierTextShadow;
	private int multiplier;
	public int specialMultiplier;

	public Text comboCounter;
	public Text comboCounterShadow;
	private int combo;
	[SerializeField]private int comboStep;
	[SerializeField]private int maxMultiplier;

	void Start(){
		specialMultiplier = 1;
		multiplier = 1;
		comboCounter.text = "";
	}

	void Update() {
		scoreText.text = SetScoreText();
		multiplierText.text = "x" + (multiplier * specialMultiplier);
		SetShadows ();
	}

	string SetScoreText(){
		string currentScore = "";
		if (score < 1000)
			currentScore += "0";
		if (score < 100)
			currentScore += "0";
		if (score < 10)
			currentScore += "0";

		currentScore += score.ToString ();

		return currentScore;
	}

	void SetShadows(){
		scoreTextShadow.text = scoreText.text;
		multiplierTextShadow.text = multiplierText.text;
		comboCounterShadow.text = comboCounter.text;
	}

	public void ReduceMultiplier(){
		combo = 0;
		comboCounter.text = "";
		if (multiplier > 1) {
			multiplier--;
		}
	}

	public void IncreaseMultiplier(){
		if (multiplier < maxMultiplier) {
			combo++;
			comboCounter.text += ".";
			if (combo >= comboStep) {
				combo = 0;
				comboCounter.text = "";
				multiplier++;
			}
		}
		UpdateScore ();
	}

	public void UpdateScore(){
		int addToScore = 1 * multiplier * specialMultiplier;
		score += addToScore;
	}
}
