using UnityEngine;
using System.Collections;

public class hitpoints : MonoBehaviour {
	public int hp = 5;

	void Start () {
	
	}
	
	void Update () {
		if (hp <= 0) {
			Destroy(this.gameObject);
		}
	}

	public void Hit(int dmg)
	{
		hp -= dmg;
	}
}
