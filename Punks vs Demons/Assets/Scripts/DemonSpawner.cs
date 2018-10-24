using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour {
	[SerializeField]private Transform player;
	[SerializeField]private BoundaryController demonScore;
	private float totalDemons;
	public GameObject demon;
	public List<GameObject> DemonList;


	// Use this for initialization
	void Start () {
		totalDemons = Mathf.Floor (demonScore.Demons * .5f); 
		DemonList = new List<GameObject> ();

		for (int i = 0; i < totalDemons; i++) {
			SpawnDemon ();
		}
	}

	void Update (){
		totalDemons = Mathf.Floor (demonScore.Demons * .5f);
		if (DemonList.Count < totalDemons) {
			float difference = totalDemons - DemonList.Count;
			for (int i = 0; i < difference; i++) {
				SpawnDemon ();
			}
		} else if (DemonList.Count > totalDemons) {
			float difference = DemonList.Count - totalDemons;
			for (int i = 0; i < difference; i++) {
				GameObject toDelete = DemonList [0];
				DemonList.RemoveAt (0);
				Destroy (toDelete);
				Debug.Log (DemonList.Count.ToString ());
			} 
		}
	}

	void SpawnDemon(){
		GameObject clone;
		clone = Instantiate (demon, transform.position, Quaternion.identity);
		clone.layer = 9;
		clone.GetComponent<DemonController> ().player = this.player;
		DemonList.Add (clone);
	}
}
