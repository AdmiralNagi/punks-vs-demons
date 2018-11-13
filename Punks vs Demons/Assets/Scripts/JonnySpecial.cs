using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JonnySpecial : MonoBehaviour {
	[SerializeField]private MemberHealth healthSR;
	[SerializeField]private MemberHealth healthC;
	[SerializeField]private MemberHealth healthD;
	[SerializeField]private MemberHealth healthSL;
	[SerializeField]private MemberSpecial jonny;

	public void HealAll(){
		if (jonny.SpecialAvailable) {
			healthSR.CurrentHealth = healthC.CurrentHealth = 
			healthD.CurrentHealth = healthSL.CurrentHealth = healthC.MaxHealth;

			jonny.SpecialValue = 0;
		}
	}
}
