using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour {

	public Vector3 startPosition;
	public float currentLerpTime;
	void Start () {
		startPosition = transform.position;
	}

	public Transform targetLocation;
	[SerializeField]private float flameLerpTime = 2f;
	void Update () {
		currentLerpTime += Time.deltaTime;

		if (currentLerpTime > flameLerpTime) {
			currentLerpTime = flameLerpTime;
		}

		float perc = currentLerpTime / flameLerpTime;
		transform.position = Vector3.Lerp (startPosition, targetLocation.position, perc);
	}
}
