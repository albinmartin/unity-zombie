using UnityEngine;
using System.Collections;

public class SpawnPos : MonoBehaviour {

	private Rect rectangle;
	public int size = 5;

	public Rect Rectangle {
		get {
			return rectangle;
		}
	}

	void Awake () {
		/*
		rectangle = new Rect ();
		rectangle.center = new Vector2 (this.transform.position.x, this.transform.position.y);
		rectangle.x = this.transform.position.x - (float)size/2.0f;
		rectangle.y = this.transform.position.y - (float)size/2.0f;
		rectangle.width = size;
		rectangle.height = size;
		*/
		rectangle = new Rect(this.transform.position.x - (float)size/2.0f,this.transform.position.y - (float)size/2.0f, size, size);
	}
	void Start () {
		/*
		rectangle = new Rect ();
		rectangle.center = new Vector2 (this.transform.position.x, this.transform.position.y);
		rectangle.x = this.transform.position.x - (float)size/2.0f;
		rectangle.y = this.transform.position.y - (float)size/2.0f;
		rectangle.width = size;
		rectangle.height = size;
		*/
		//rectangle = new Rect(this.transform.position.x - (float)size/2.0f,this.transform.position.y - (float)size/2.0f, size, size);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
