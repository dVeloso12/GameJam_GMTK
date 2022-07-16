using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	Vector3 diceVelocity;
	[Header("Dices")]
	[SerializeField] bool NormalDice = true;
	[SerializeField] bool WeaponDice;


	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && NormalDice)
		{
				switch (col.gameObject.name) {
					case "1":
						DiceNumberTextScript.diceNumber = 3;
						break;
					case "2":
						DiceNumberTextScript.diceNumber = 4;
						break;
					case "3":
						DiceNumberTextScript.diceNumber = 1;
						break;
					case "4":
						DiceNumberTextScript.diceNumber = 2;
						break;
					case "5":
						DiceNumberTextScript.diceNumber = 6;
						break;
					case "6":
						DiceNumberTextScript.diceNumber = 5;
						break;
				}
			
		}
	}
}
