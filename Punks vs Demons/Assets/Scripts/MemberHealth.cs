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
		set{ currentHealth = value; }
	}

	private bool recharging;
	private Color originalHealthColor;
	private Color rechargeColor;
	private float originalR;
	private float originalB;
	private float originalG;
	private float rechargeR = 195f / 255f;
	private float rechargeG = 126f / 255f;
	private float rechargeB = 49f / 255f;


	// Use this for initialization
	void Start () {
		originalColor = memberPanel.color;
		currentHealth = maxHealth;
		hpDisplay.text = currentHealth + "/" + maxHealth;
		if (healthColor) {
			originalHealthColor = healthColor.color;
			rechargeColor = new Color (rechargeR, rechargeG, rechargeB);
		}
	}


	void Update () {
		CheckRegen ();
		UpdateHealthText ();
		UpdateHealthBar ();
	}

	private float timeSinceDamage;
	[SerializeField]private float regenRate = 1f;
	void CheckRegen(){
		if (timeSinceDamage != null) {
			timeSinceDamage += Time.deltaTime;

			if (timeSinceDamage >= regenRate && currentHealth < maxHealth) {
				currentHealth++;
				timeSinceDamage = 0f;
			}
		}
	}

	void UpdateHealthText(){
		if (currentHealth >= 10) {
			hpDisplay.text = "HP " + (int)currentHealth + "/" + maxHealth;
		} else {
			hpDisplay.text = "HP 0" + (int)currentHealth + "/" + maxHealth;
		}
	}
		
	[SerializeField]private Image memberPanel;
	private Color originalColor;
	private bool isFlashing = false;
	void UpdateHealthBar(){
		if (healthBar) {
			if (!recharging) {
				healthBar.anchorMax = new Vector2 (currentHealth / maxHealth, 1f);
				if (currentHealth <= 0) {
					healthColor.color = rechargeColor;
					memberPanel.color = rechargeColor;
					recharging = true;
				} else if (!isFlashing && currentHealth <= 3) {
					memberPanel.color = Color.red;
					isFlashing = true;
					StartCoroutine ("LowHealth");
				}
			} else if (recharging) {
				spriteColor.color = Color.black;
				RechargeLerp ();
				if (currentHealth >= maxHealth) {
					healthColor.color = originalHealthColor;
					spriteColor.color = Color.white;
					memberPanel.color = originalColor;
					recharging = false;
				}
			}
		}
	}

	IEnumerator LowHealth(){
		yield return new WaitForSeconds (.25f);
		if (!recharging) {
			memberPanel.color = originalColor;
		}
		yield return new WaitForSeconds (.25f);
		isFlashing = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Note")) {
			if (currentHealth > 0 && !recharging) {
				timeSinceDamage = 0f;
				currentHealth--;
				TakeDamage ();
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

	[SerializeField]private SpriteRenderer spriteColor;
	[SerializeField]private AudioSource hitSound;
	void TakeDamage(){
			spriteColor.color = Color.red;
			hitSound.Play ();
			StartCoroutine ("DamageFlash");
	}

	IEnumerator DamageFlash(){
		yield return new WaitForSeconds (.1f);
		spriteColor.color = Color.white;
	}
}
