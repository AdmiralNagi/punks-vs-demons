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
	//[SerializeField]private Image specialColor;
	[SerializeField]private Text spDisplay;

	private Vector2 empty;
	private Vector2 filled;
	// Use this for initialization
	void Start () {
		empty = new Vector2(0f, 1f);
		filled = new Vector2(1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (specialValue >= 10) {
			spDisplay.text = (int)specialValue + "/" + maxSpecial;
		} else {
			spDisplay.text = "0" + (int)specialValue + "/" + maxSpecial;
		}

		specialBar.anchorMax = new Vector2 (specialValue / maxSpecial, 1f);
	}
}
