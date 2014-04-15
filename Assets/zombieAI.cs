using UnityEngine;
using System.Collections;

public class zombieAI : MonoBehaviour {
	public string targetName;
	public float speed;
	private Transform target;
	private float timeStamp = 0;
	private float cooldownInSec = 1.5f;
	private Vector3 randDir;

	// Use this for initialization
	void Start () {
		targetName = "Player";
		speed = 0.30f;
		target = GameObject.Find(targetName).transform.Find("torso");
		randDir = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = getDirection ();
		this.transform.Translate (dir*speed);
	}

	private Vector3 getDirection()
	{
		if (timeStamp <= Time.time) {
			timeStamp = Time.time + cooldownInSec;
			randDir = new Vector3(Random.value, Random.value, Random.value);
		}
		return Vector3.Normalize(target.position - this.transform.position +randDir);
	}
}
