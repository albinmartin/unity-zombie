using UnityEngine;
using System.Collections;

public class bulletAI : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2.0f);
		//currentlife = System.DateTime.Now.Second;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		currentlife = System.DateTime.Now.Second-currentlife;
		if(currentlife > lifetime)
			//kill*/
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Enemy")
		{
			hitpoints hp = collision.gameObject.GetComponent<hitpoints>();
			if(hp != null)
				hp.Hit(1);
		}
		Destroy (this.gameObject);
	}
}
