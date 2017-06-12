using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kittyMove : MonoBehaviour {

	public float maxSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 direction;
		direction.x = Input.GetAxis("Vertical");
		direction.y = Input.GetAxis("Vertical");

		// scale by the maxSpeed parameter
		Vector2 velocity = direction * maxSpeed;

		// move the object
		transform.Translate(velocity * Time.deltaTime);
	}
}
