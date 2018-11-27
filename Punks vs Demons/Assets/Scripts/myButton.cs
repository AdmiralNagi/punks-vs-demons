using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class myButton : MonoBehaviour, IPointerDownHandler {

	public InputController input;
	public MemberHealth health;

	public void OnPointerDown(PointerEventData data){
		if (!health.recharging) {
			input.LaneButtonPress ();
		}
	}
}
