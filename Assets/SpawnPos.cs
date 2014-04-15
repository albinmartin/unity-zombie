using UnityEngine;
using System.Collections;

public class SpawnPos : MonoBehaviour {

	private Rect rectangle;
	public int size;

	public Rect Rectangle {
		get {
			return rectangle;
		}
	}

	// Use this for initialization
	void Start () {
		rectangle = new Rect ();
		rectangle.center = new Vector2 (this.transform.position.x, this.transform.position.y);
		rectangle.x = this.transform.position.x - (float)size/2.0f;
		rectangle.y = this.transform.position.y - (float)size/2.0f;
		rectangle.width = size;
		rectangle.height = size;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
