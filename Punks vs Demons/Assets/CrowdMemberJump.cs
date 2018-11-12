using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMemberJump : MonoBehaviour {
	private Rigidbody rb;

	void Start () {
		rb = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Jump ();
	}

	private bool jumping = false;
	[SerializeField]private float jumpMultiplier;
	void Jump(){
		if (!jumping) {
			rb.AddForce (transform.up * jumpMultiplier, ForceMode.Impulse);
			jumping = true;
			StartCoroutine ("PulseMove");
		}
	}

	IEnumerator PulseMove() {
		float waitTime = Random.value;
		yield return new WaitForSeconds(waitTime);
		jumping = false;
	}
}
