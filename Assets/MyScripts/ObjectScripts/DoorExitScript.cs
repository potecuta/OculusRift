using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DataModel;


public class DoorExitScript : MonoBehaviour {

	private OVRPlayerController player;
	private SMKCameraUtilities cameraRig;

	private bool itIsVisible;
	private bool centered;
	private bool focused;



	private DataCollecting dataCollector;

	public bool Centered{
		get{ 
			return centered;
		}
	}

	public bool Focused{
		get {
			return focused;
		}
	}


    GameObject globalGameObject;

	void Start () {

		player = GameObject.FindObjectOfType<OVRPlayerController>();
		cameraRig = player.GetComponent<SMKCameraUtilities>();

		UnityEngine.Object[] objs = GameObject.FindGameObjectsWithTag("GlobalManager");
		if(objs != null)
		{
			GameObject generalManager = objs[0] as GameObject;
			dataCollector = generalManager.GetComponent<DataCollecting>();
		}


		itIsVisible = false;
		centered = false;

	}
	


	// Update is called once per frame
	void Update () {
		
		if(itIsVisible)	{
			
			centered = checkIfCentered();
			
			if(centered)
			{
				// Debug.Log("door centered");
				if(Input.GetMouseButtonDown(0))
				{	

					dataCollector.printJsonToFile();
					Application.Quit();
				}
			}
		}

	}


	void OnBecameVisible()
	{
		enabled = true;


		itIsVisible = true;

	} 

	void OnBecameInvisible()
	{
		enabled = false;

		itIsVisible = false;
	}

	bool checkIfCentered()
	{
		
		bool inCenter = cameraRig.isObjectInCenterOfView(gameObject);
		if(inCenter) {
			return true;
		}
	
		return false;
	}

	
}
