using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BergeSpecial : MonoBehaviour {
	[SerializeField]private FlameController flame;
	[SerializeField]private MemberSpecial berge;
	private bool flaming;
	private Vector3 target;

	void Start(){
		target = flame.targetLocation.position;
	}

	void Update(){
		if (flaming) {
			berge.SpecialValue = 0;

			if (flame.transform.position == target) {
				flame.transform.position = flame.startPosition;
				flame.gameObject.SetActive (false);
				flaming = false;
			}
		}
	}

	public void FlameOn(){
		flame.currentLerpTime = 0f;
		flame.gameObject.SetActive (true);
		flaming = true;
	}
}
