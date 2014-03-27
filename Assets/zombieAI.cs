using UnityEngine;
using System.Collections;

public class zombieAI : MonoBehaviour {
	public string targetName;
	public float speed;
	private Transform target;
	// Use this for initialization
	void Start () {
		targetName = "Player";
		speed = 0.10f;
		target = GameObject.Find(targetName).transform.Find("torso");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = getDirection ();
		this.transform.Translate (dir*speed);
	}

	private Vector3 getDirection()
	{
		return Vector3.Normalize(target.position - this.transform.position);
	}
}
