using UnityEngine;
using System.Collections;

public class SMKCameraUtilities : MonoBehaviour {

	public Camera leftEyeCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isObjectInCenterOfView(GameObject obj)
	{
		Vector3 objCenter = obj.GetComponent<Renderer>().bounds.center;
		Vector3	objRelativeToLeftEye = leftEyeCamera.WorldToViewportPoint (objCenter);
 		

		if( objRelativeToLeftEye.x > 0.35 && objRelativeToLeftEye.x < 0.65 && objRelativeToLeftEye.y > 0.35 && objRelativeToLeftEye.y < 0.65)
		{
			return true;
		}


		return false;
	}
}
