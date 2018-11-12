using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelector : MonoBehaviour {
	private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite[] sprites;
	// Use this for initialization
	void Start () {
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		if (sprites.Length != null) {
			int randomIndex = Random.Range (0, sprites.Length);

			spriteRenderer.sprite = sprites [randomIndex];
		}
	}
}
