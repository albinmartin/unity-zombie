
using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public Transform unit;
	public float timeStamp;
	public float cooldownInSec = 3;
	public int hitpoints = 5;
	void Start () {
		timeStamp = 0;
	}
	
	
	void Update () {
		/*if (Input.GetKey (KeyCode.Q)) {
			Instantiate(unit, this.transform.position, Quaternion.identity);
		}*/
		if (timeStamp <= Random.Range(Time.time-1, Time.time+1)) {
			timeStamp = Time.time + cooldownInSec;
			Instantiate(unit, this.transform.position, Quaternion.identity);
			hitpoints--;
		}
		if (hitpoints <= 0) {
			Destroy(this);		
		}
	}
}
