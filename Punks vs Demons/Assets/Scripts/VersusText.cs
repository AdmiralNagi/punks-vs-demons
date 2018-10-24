using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersusText : MonoBehaviour {
	[SerializeField]private BoundaryController punksDemonRatio;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "[" + punksDemonRatio.Punks + ":"
		+ punksDemonRatio.Demons + "]";
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = "[" + punksDemonRatio.Punks + ":"
			+ punksDemonRatio.Demons + "]";
	}
}
