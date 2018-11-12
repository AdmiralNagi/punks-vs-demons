using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkController : MonoBehaviour {
	private Rigidbody rb;

	[SerializeField]private Transform target;
	[SerializeField]private float speed = 1f;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		target = GameObject.Find ("DemonSpawnPoint").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MoveToTarget ();
	}
		
	private bool moving = false;
	void MoveToTarget(){
		if (!moving) {
			Vector3 heading = target.position - transform.position;
			heading = new Vector3 (heading.x, 0, heading.z);
			rb.AddForce (heading * speed, ForceMode.Impulse);
			moving = true;
			StartCoroutine ("PulseMove");
		}
	}

	IEnumerator PulseMove() {
		yield return new WaitForSeconds(.25f);
		moving = false;
	}
}
