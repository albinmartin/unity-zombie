using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();

		//Default direction
		animator.SetInteger("direction", 0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setDirection(int direction){
		animator.SetInteger("direction", direction);
	}
}
