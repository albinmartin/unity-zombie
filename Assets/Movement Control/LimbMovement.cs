using UnityEngine;
using System.Collections;

public class LimbMovement : MonoBehaviour {

	public SkeletonWrapper sw;
	public int movementScale = 10;
	protected Vector3 worldCoord;
	public bool trackRotation = true;

	public enum Limb
	{
		HandLeft = Kinect.NuiSkeletonPositionIndex.HandLeft,
		HandRight = Kinect.NuiSkeletonPositionIndex.HandRight,
		HipCenter = Kinect.NuiSkeletonPositionIndex.HipCenter,
		ElbowLeft = Kinect.NuiSkeletonPositionIndex.ElbowLeft,
		ElbowRight = Kinect.NuiSkeletonPositionIndex.ElbowRight
	}

	public Limb limb = Limb.HipCenter;

	void Start () {
		worldCoord = new Vector3 (0, 0, 0);
		//movementScale = 10;
	}

	public virtual void Update () {
		if (sw.pollSkeleton ()) {
			calcPosition();
			calcRotation();
		}
	}

	protected  virtual void calcPosition(){
		Vector3 pos = sw.bonePos[0, (int)limb];
		worldCoord = new Vector3(pos.x, pos.z, 0);
		//transform.Translate(worldCoord*movementScale, Space.Self);
		if (!(float.IsNaN(pos.x) && float.IsNaN(pos.y) && float.IsNaN(pos.z))){
			this.transform.position = worldCoord*movementScale;
		}
	}
	
	protected virtual void calcRotation(){
		if(sw.boneAbsoluteOrientation != null && trackRotation)
		{
			Vector3 center = this.transform.localPosition;
			if(this.renderer != null) //So we can apply script to nonvisible objects
				center = this.renderer.bounds.center;

			this.transform.localRotation = Quaternion.identity;
			this.transform.RotateAround(center, Vector3.forward, sw.boneAbsoluteOrientation[0, (int)limb].eulerAngles.y);
		}
	}
}
