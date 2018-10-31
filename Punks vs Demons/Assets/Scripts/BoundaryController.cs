using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {
	private int punks = 75;
	public int Punks {
		set { punks = value; }
		get { return punks; }
	}
	private int demons = 25;
	public int Demons {
		set { demons = value; }
		get { return demons; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float scaler = (float)demons * .05f;
		if (scaler >= .1) {
			transform.localScale = new Vector3 (scaler, 1, scaler);
		}
	}
}
