using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private PlayerScore playerScore;
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
	[SerializeField]private SongManager songManager;

	void Start(){
		specialMultiplier = 1;
		multiplier = 1;
		comboCounter.text = "";
	}

	void Update() {
		if (songManager.songSet && !playerScoreLoaded) {
			LoadPlayerScore ();
			playerScoreLoaded = true;
		}
		
		scoreText.text = GetScoreText(score);
		multiplierText.text = "x" + (multiplier * specialMultiplier);
		SetShadows ();
	}

	private string currentSongHighScore;
	private bool playerScoreLoaded = false;
	public bool PlayerScoreLoaded{
		get { return playerScoreLoaded; }
	}
	void LoadPlayerScore(){
		playerScore = new PlayerScore ();
		currentSongHighScore = "highScore_" + songManager.song.clip.name;

		if (PlayerPrefs.HasKey(currentSongHighScore)){
			playerScore.highScore = PlayerPrefs.GetInt(currentSongHighScore);
		}
	}

	void SavePlayerScore(){
		PlayerPrefs.SetInt (currentSongHighScore, playerScore.highScore);
	}

	public void SubmitPlayerScore(){
		if (score > playerScore.highScore) {
			playerScore.highScore = score;
			SavePlayerScore ();
		}
	}

	public int GetHighScore(){
		return playerScore.highScore;
	}

	public string GetScoreText(int value){
		string currentScore = "";
		if (value < 1000)
			currentScore += "0";
		if (value < 100)
			currentScore += "0";
		if (value < 10)
			currentScore += "0";

		currentScore += value.ToString ();

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
