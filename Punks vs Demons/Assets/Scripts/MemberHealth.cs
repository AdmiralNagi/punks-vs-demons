using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberHealth : MonoBehaviour {
	[SerializeField]private BoundaryController punksDemonRatio;
	[SerializeField]private Text hpDisplay;
	[SerializeField]private int maxHealth = 20;
	private int currentHealth;
	public int CurrentHealth{
		get{ return currentHealth; }
	}


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		hpDisplay.text = "HP " + currentHealth + "/" + maxHealth; 
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth >= 10) {
			hpDisplay.text = "HP " + currentHealth + "/" + maxHealth;
		} else {
			hpDisplay.text = "HP 0" + currentHealth + "/" + maxHealth;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Note")) {
			if (currentHealth > 0) {
				currentHealth--;
			}

			if (punksDemonRatio.Demons < 99) {
				punksDemonRatio.Punks--;
				punksDemonRatio.Demons++;
			}
		}
	}
}
