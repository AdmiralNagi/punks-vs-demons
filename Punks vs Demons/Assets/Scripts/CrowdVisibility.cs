using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdVisibility : MonoBehaviour {
	[SerializeField] private GameObject mySprite;
	private Rigidbody rb;

	void Start(){
		rb = this.GetComponent<Rigidbody> ();
		Physics.IgnoreLayerCollision (10, 10);
		Physics.IgnoreLayerCollision (9, 10);
	}

	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("CrowdBoundary")) {
			mySprite.SetActive (false);
			rb.isKinematic = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.CompareTag ("CrowdBoundary")) {
			mySprite.SetActive (true);
			rb.isKinematic = false;
		}
	}
}
