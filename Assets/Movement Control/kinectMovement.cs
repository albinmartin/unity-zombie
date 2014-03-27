using UnityEngine;
using System.Collections;

public class kinectMovement : MonoBehaviour {

	public SkeletonWrapper sw;
	public int movementScale;
	public Vector3 worldCoord;

	// Use this for initialization
	void Start () {
		worldCoord = new Vector3 (0, 0, 0);
		movementScale = 10;
	}

	
	// Update is called once per frame
	void Update () {

		//Position
		if (sw.pollSkeleton ()) {
			Vector3 pos = sw.bonePos [0, (int)Kinect.NuiSkeletonPositionIndex.HipCenter];
			worldCoord = new Vector3(pos.x, pos.z, 0);
			//transform.Translate(worldCoord*movementScale, Space.Self);
			if (!(float.IsNaN(pos.x) && float.IsNaN(pos.y) && float.IsNaN(pos.z))){
				this.transform.localPosition = worldCoord*movementScale;
			
			}
		}
	}
}
