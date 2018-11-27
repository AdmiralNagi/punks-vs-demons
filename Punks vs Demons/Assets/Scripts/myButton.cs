using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class myButton : MonoBehaviour, IPointerDownHandler {

	public InputController input;

	public void OnPointerDown(PointerEventData data){
		input.LaneButtonPress ();
	}
}
