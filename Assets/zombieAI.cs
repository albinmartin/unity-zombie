using UnityEngine;
using System.Collections;

public class zombieAI : MonoBehaviour {
	public string targetName;
	public float speed = 0.3f;
	private Transform target;
	private float timeStamp = 0;
	private float cooldownInSec = 0.5f;
	private Vector3 randDir;
	private MoveStrategy moveStrategy;
	private Vector3 curVelocity;

	void Start () {
		targetName = "Player";
		target = GameObject.Find(targetName).transform.Find("torso");
		randDir = Vector3.zero;
		curVelocity = Vector3.zero;
		moveStrategy = new MoveToTarget (target.transform);
		timeStamp = 0.0f;
	}

	void Update () {
		if (moveStrategy.IsDone)
			moveStrategy = moveStrategy.Next;

		Vector3 dir = moveStrategy.getDirection (this.transform.position);
		if (timeStamp <= Time.time) 
		{
			timeStamp = Time.time + cooldownInSec;
			randDir = new Vector3 (Random.value, Random.value, 0);
		}

		curVelocity = dir * speed;
		this.transform.position += curVelocity;
	}

	void OnTriggerEnter(Collider collision){
	

		if(collision.gameObject.tag == "Wall")
		{
			Vector3 goRight = Vector3.Cross(curVelocity, new Vector3(0,0,1));
			goRight.Normalize();
			goRight *= 3;
			goRight += this.transform.position + curVelocity.normalized*-0.4f;
			this.moveStrategy = new MoveToPoint(goRight, new MoveToTarget(target.transform));
		}
	
	}
}

public abstract class MoveStrategy
{
	protected MoveStrategy next;
	protected float minDistance = 0.3f;
	protected bool isDone;

	public MoveStrategy Next {
		get {
			return next;
		}
	}
	public bool IsDone {
		get {
			return isDone;
		}
	}
	public abstract Vector3 getDirection(Vector3 currentPos);
}

public class MoveToTarget : MoveStrategy
{
	private Transform target;
	public MoveToTarget(Transform target)
	{
		this.target = target;
		this.isDone = false;
		this.next = null;
	}

	public override Vector3 getDirection (Vector3 currentPos)
	{
		Vector3 dir = Vector3.Normalize (target.transform.position - currentPos);
		if (dir.magnitude < minDistance)
		{
			return Vector3.zero;
		}
		return dir;
	} 
}

public class MoveToPoint : MoveStrategy
{
	private Vector3 goal;

	public MoveToPoint(Vector3 goal, MoveToTarget nextAction)
	{
		this.goal = goal;
		this.isDone = false;
		this.next = nextAction;
	}

	public override Vector3 getDirection (Vector3 currentPos)
	{
		Vector3 dir = Vector3.Normalize(goal - currentPos);
		if ((goal - currentPos).magnitude < minDistance)
		{
			isDone = true;
			return Vector3.zero;
		}
		return dir;

	}
}
