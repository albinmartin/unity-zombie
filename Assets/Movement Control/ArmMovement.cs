using UnityEngine;
using System.Collections;

public class ArmMovement : LimbMovement {

	public enum WhichArm { LEFT, RIGHT }
	public WhichArm whichArm = WhichArm.RIGHT;
	private Vector3 arm;
	
	//Weapon
	private bool isShooting;
	private Rigidbody2D bullet;
	private float bulletSpeed = 100.0f;
	private int cooldownInSec = 1;
	private float timeStamp;
	private float weaponRange = 60;

	public bool IsShooting {
		get {
			return isShooting;
		}
	}

	public Vector3 AbsolutePosition
	{
		get{ return this.transform.position; }
	}
	
	void Start () {
		bullet = Resources.Load<Rigidbody2D> ("Prefabs/bullet");
		isShooting = false;
		if (WhichArm.LEFT == whichArm) {
			this.limb = Limb.HandLeft;
		} 
		else{
			this.limb = Limb.HandRight;
		}
	}
	
	public override void Update () {
		calcPosition ();
		calcRotation ();

		if (isShooting && timeStamp <= Time.time) {
			timeStamp = Time.time + cooldownInSec;
			shoot();
		}
	}

	private void shoot(){

		Vector3 dir = zombieDirection ();
		if (dir.magnitude < weaponRange) {
			Rigidbody2D bulletClone = (Rigidbody2D)Instantiate (bullet, this.transform.position, transform.rotation);
			dir.Normalize();
			bulletClone.velocity = new Vector2 (dir.x, dir.z) * bulletSpeed;
		}
	}

	private Vector3 zombieDirection()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		Vector3 toEnemy;
		Vector3 closestEnemyDir = new Vector3 (weaponRange, 0, 0);
		Transform t;
		foreach (GameObject enemy in enemies) {
			t = enemy.GetComponent<Transform>();
			toEnemy = t.position - AbsolutePosition;
			if(Vector3.Angle(arm, toEnemy) < 50)
			{
				if(closestEnemyDir.magnitude > toEnemy.magnitude)
					closestEnemyDir = toEnemy;
			}
		}
		return closestEnemyDir;
	}

	private void createArm(WhichArm wArm){
		Vector3 sampleArm;
		switch (wArm) {
		case WhichArm.LEFT:
			sampleArm = sw.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandLeft] - sw.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowLeft];
			if (!(float.IsNaN(sampleArm.x) && float.IsNaN(sampleArm.y) && float.IsNaN(sampleArm.z))){
				sampleArm.Normalize();
				arm = sampleArm;
			}
			break;
		case WhichArm.RIGHT:
			sampleArm = sw.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.HandRight] - sw.bonePos[0, (int)Kinect.NuiSkeletonPositionIndex.ElbowRight];
			if (!(float.IsNaN(sampleArm.x) && float.IsNaN(sampleArm.y) && float.IsNaN(sampleArm.z))){
				sampleArm.Normalize();
				arm = sampleArm;
			}
			break;
		default:
			break;
		}
	}

	protected  override void calcPosition(){
		//base.calcPosition ();
		Vector3 pos = sw.bonePos[0, (int)Limb.HipCenter] - sw.bonePos [0, (int)limb] ;
		worldCoord = new Vector3(-pos.x, -pos.z, 0);
		if (!(float.IsNaN(pos.x) && float.IsNaN(pos.y) && float.IsNaN(pos.z))){
			this.transform.position = this.transform.parent.position + worldCoord*movementScale;
		}

		createArm (whichArm);
	}
	
	protected override void calcRotation(){
		base.calcRotation ();

		//Calculate if holding arms "orthogonal" to the body
		if (arm != null) {
			float angle = Vector3.Angle(arm, Vector3.down);		
			if(angle > 40)
			{
				isShooting = true;
			}
			else
				isShooting = false;
		}
		/*
		if(sw.boneAbsoluteOrientation != null && trackRotation)
		{
			Vector3 center = this.renderer.bounds.center;
			this.transform.rotation = Quaternion.identity;
			this.transform.RotateAround(center, Vector3.forward, sw.boneLocalOrientation[0, (int)limb].eulerAngles.y);
		}
		*/

	}
}
