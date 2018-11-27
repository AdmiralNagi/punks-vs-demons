using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusText : MonoBehaviour {
	[SerializeField]private BoundaryController punksDemonRatio;
	[SerializeField]private RectTransform vsBar;
	[SerializeField]private Image statusPanel;
	private Color originalColor;

	void Start () {
		originalColor = statusPanel.color;		
	}

	private bool isFlashing = false;
	void Update () {
		vsBar.anchorMax = new Vector2 (punksDemonRatio.Punks / 100f, 1f);

		if (!isFlashing && punksDemonRatio.Punks <= 25) {
			statusPanel.color = new Color (166f / 255f, 0f, 0f, 1f);
			isFlashing = true;
			StartCoroutine ("Flash");
		}
	}

	IEnumerator Flash(){
		yield return new WaitForSeconds (.1f);
		statusPanel.color = originalColor;
		yield return new WaitForSeconds (.25f);
		isFlashing = false;
	}
}
