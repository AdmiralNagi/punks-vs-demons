using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour {
	public Transform player;
	[SerializeField]private float speed = 2.0f;
	private Rigidbody rb;
	Vector3 lastPosition;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		float x_direction = Random.Range(-1f, 1f);
		float z_direction = Random.Range(-1f, 1f);
		rb.AddForce (new Vector3(x_direction, 0, z_direction) * speed, ForceMode.Impulse);
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt (player);

		rb.AddRelativeForce((transform.position - lastPosition) * speed, ForceMode.Impulse);
		lastPosition = transform.position;
			
	}
}
