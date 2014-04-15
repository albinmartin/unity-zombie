using UnityEngine;
using System.Collections;

public class levelManager : MonoBehaviour {
	public enum Difficulty { Easy, Medium, Hard };

	GameObject spawner; 
	public Difficulty difficulty = Difficulty.Easy;
	private int numSpawners;
	private int cooldown, newSpawnCooldown;
	private float timestamp;
	private Rect[] spawnPositions;
	public int levelID = 0;
	void Start () {
		timestamp = 0;
		switch (difficulty) {
		case Difficulty.Easy:
			cooldown = 6;
			newSpawnCooldown = 15;
			numSpawners = 4;
			break;
		case Difficulty.Medium:
			cooldown = 4;
			newSpawnCooldown = 10;
			numSpawners = 6;
			break;
		case Difficulty.Hard:
			cooldown = 2;
			newSpawnCooldown = 5;
			numSpawners = 8;
			break;
		default:
			cooldown = 6;
			numSpawners = 4;
			break;
		}

		//Init spawn points for enemies
		GameObject[] sPositions = GameObject.FindGameObjectsWithTag ("SpawnPosEnemy");
		this.spawnPositions = new Rect[sPositions.Length];
		int i = 0;
		foreach(GameObject spawnPos in sPositions)
		{
			this.spawnPositions[i] = spawnPos.GetComponent<SpawnPos>().Rectangle;
		}
	}

	void Update () {

		if (numSpawners > 0 && timestamp <= Time.time) {
			timestamp = Time.time + newSpawnCooldown;
			spawner = (GameObject)Instantiate(Resources.Load("Prefabs/Spawner")); 
			//Position at spawnpoint
			spawner.transform.position = getRndPosition();
			spawner.GetComponent<spawner>().cooldownInSec = cooldown;

			numSpawners--;
		}
		else if(numSpawners <= 0 && GameObject.FindGameObjectsWithTag ("Enemy").Length <= 0){
			//Display level complete
			//Change level
			Application.LoadLevel (levelID+1);
		}
	}

	private Vector3 getRndPosition()
	{
		int index = (int)Random.Range (0, spawnPositions.Length-1);
		int x = (int)Random.Range (spawnPositions [index].x, spawnPositions [index].x + spawnPositions [index].width);
		int y = (int)Random.Range (spawnPositions [index].y, spawnPositions [index].y + spawnPositions [index].height);
		return new Vector3 (x, y, 0);
	}
}
