using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaomiSpecial : MonoBehaviour {
	[SerializeField]private FlameController flame;
	[SerializeField]private MemberSpecial naomi;
	private bool flaming;
	private Vector3 target;

	void Start(){
		target = flame.targetLocation.position;
	}

	void Update(){
		if (flaming && flame.transform.position == target) {
			flame.transform.position = flame.startPosition;
			flame.gameObject.SetActive (false);
			flaming = false;
			naomi.SpecialValue = 0;
		}
	}

	public void FlameOn(){
		flame.currentLerpTime = 0f;
		flame.gameObject.SetActive (true);
		flaming = true;

	}
}
