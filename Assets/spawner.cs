using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public Transform unit;
	private float timeStamp;
	public float cooldownInSec = 3;
	void Start () {
		timeStamp = 0;
	}
	
	
	void Update () {
		/*if (Input.GetKey (KeyCode.Q)) {
			Instantiate(unit, this.transform.position, Quaternion.identity);
		}*/
		if (timeStamp <= Time.time) {
			timeStamp = Time.time + cooldownInSec;
			Instantiate(unit, this.transform.position, Quaternion.identity);
		}
	}
}
