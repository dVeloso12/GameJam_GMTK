using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	[SerializeField] Vector3 StartPosition;
	[SerializeField] float force;
	[SerializeField] public bool canUse;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown(KeyCode.Space) && canUse) {

			DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			transform.localPosition = StartPosition;
			transform.rotation = Quaternion.identity;
			rb.AddForce (transform.up * force * 100);
			rb.AddTorque (dirX, dirY, dirZ);
		}
	}
}
