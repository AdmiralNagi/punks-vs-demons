using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text scoreText;
	public int score;
	public Text multiplierText;
	public int multiplier;

	public int combo;
	public int comboStep;
	public int maxCombo;

	void Update() {
		scoreText.text = score.ToString();
		multiplierText.text = "x" + multiplier;
	}
}
