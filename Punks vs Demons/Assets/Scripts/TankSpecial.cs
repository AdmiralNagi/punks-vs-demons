using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpecial : MonoBehaviour {
	public bool shielded = false;
	[SerializeField]private MemberSpecial tank;
	[SerializeField]private float shieldDuration = 10f;

	[SerializeField]private SpriteRenderer tankColor;
	[SerializeField]private SpriteRenderer bergeColor;
	[SerializeField]private SpriteRenderer naomiColor;
	[SerializeField]private SpriteRenderer jonnyColor;

	private Color lightBlue;

	void Start(){
		lightBlue = new Color (0f, 1f, 250f / 255f);
	}

	public void ShieldAll(){
		tankColor.color = lightBlue;
		bergeColor.color = lightBlue;
		naomiColor.color = lightBlue;
		jonnyColor.color = lightBlue;
		tank.SpecialValue = 0;
		shielded = true;
		StartCoroutine ("ShieldDuration");
	}

	IEnumerator ShieldDuration(){
		yield return new WaitForSeconds (shieldDuration);
		tankColor.color = Color.white;
		bergeColor.color = Color.white;
		naomiColor.color = Color.white;
		jonnyColor.color = Color.white;
		shielded = false;
	}
}
