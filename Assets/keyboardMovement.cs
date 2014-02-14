using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class keyboardMovement : MonoBehaviour {
	private float speed;

	// Use this for initialization
	void Start () {
		speed = 0.1f;
	}

	// Update is called once per frame
	void Update () {
		Vector3 curPos = gameObject.transform.position;

		if(Input.GetKey(KeyCode.D)){
			gameObject.transform.Translate(Vector3.right*speed);
		}
		if(Input.GetKey(KeyCode.A)){
			gameObject.transform.Translate(Vector3.left*speed);
		}
		if(Input.GetKey(KeyCode.W)){
			gameObject.transform.Translate(Vector3.up*speed);
		}
		if(Input.GetKey(KeyCode.S)){
			gameObject.transform.Translate(Vector3.down*speed);
		}
	}
}
