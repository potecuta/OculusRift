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
 		

		if( objRelativeToLeftEye.x > 0.40 && objRelativeToLeftEye.x < 0.60 && objRelativeToLeftEye.y > 0.40 && objRelativeToLeftEye.y < 0.60)
		{

			float distance = Vector3.Distance (gameObject.transform.position, obj.transform.position);

			if(distance < 13)
			{
				return true;
			}

			return false;
		}


		return false;
	}
}
