using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemberHealth : MonoBehaviour {
	[SerializeField]private BoundaryController punksDemonRatio;
	[SerializeField]private Text hpDisplay;
	[SerializeField]private float maxHealth = 20f;
	public float MaxHealth{
		get { return maxHealth; }
	}
	[SerializeField]private RectTransform healthBar;
	[SerializeField]private Image healthColor;
	private float currentHealth;
	public float CurrentHealth{
		get{ return currentHealth; }
	}

	private bool recharging;
	private float originalR;
	private float originalB;
	private float originalG;
	private float rechargeR = 195f / 255f;
	private float rechargeG = 126f / 255f;
	private float rechargeB = 49f / 255f;


	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		hpDisplay.text = currentHealth + "/" + maxHealth;
		if (healthColor) {
			originalR = healthColor.color.r;
			originalB = healthColor.color.b;
			originalG = healthColor.color.g;
			//Debug.Log (originalB.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth >= 10) {
			hpDisplay.text = (int)currentHealth + "/" + maxHealth;
		} else {
			hpDisplay.text = "0" + (int)currentHealth + "/" + maxHealth;
		}

		if (healthBar) {
			if (!recharging) {
				healthBar.anchorMax = new Vector2 (currentHealth / maxHealth, 1f);
				if (currentHealth <= 0) {
					healthColor.color = new Color (rechargeR, rechargeG, rechargeB);
					recharging = true;
				}
			} else if (recharging) {
				RechargeLerp ();
				if (currentHealth >= maxHealth) {
					healthColor.color = new Color (originalR, originalG, originalB);
					recharging = false;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Note")) {
			if (currentHealth > 0 && !recharging) {
				currentHealth--;
			}

			if (punksDemonRatio.Demons < 99) {
				punksDemonRatio.Punks--;
				punksDemonRatio.Demons++;
			}
		}
	}

	[SerializeField]private float rechargeSpeed;
	void RechargeLerp(){
		Vector2 empty = new Vector2 (0f, 1f);
		Vector2 full = new Vector2 (1f, 1f);
		currentHealth += Time.deltaTime * (maxHealth/rechargeSpeed);

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		healthBar.anchorMax = Vector2.Lerp (empty, full, currentHealth / maxHealth);
	}
}
