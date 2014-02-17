using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		//gameObject.renderer.sortingOrder = 2;
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
