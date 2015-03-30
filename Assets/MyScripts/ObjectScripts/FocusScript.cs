using UnityEngine;
using System.Collections;
using System;


public class FocusScript : MonoBehaviour {

	public SMKCameraUtilities cameraRig;
	public float timeNeededToEnterFocus;
	public float timeNeededToExitFocus;

	private bool itIsVisible;
	private bool centered;
	private bool inFocus;

	private float enteredCenterTime;
	private float exitCenterTime;
	private float enteredFocusTime;
	private float exitFocusTime;
	private float focusDuration;

	// Use this for initializationuni
	void Start () {
		
		itIsVisible = false;
		centered = false;
		inFocus = false;
	}
	


	// Update is called once per frame
	void Update () {
		
		if(itIsVisible)	{
			
			centered = checkIfCentered();

			checkIfInFocus();

		}
		else
		{
			//DBG*******
			GetComponent<Renderer>().material.color = new Color(1,0,0,1);
			//DBG*******
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

//Functions to use
	void enteredFocus ()
	{
		Debug.Log(enteredFocusTime);
	}

	void exitFocus()
	{
		Debug.Log(enteredFocusTime);
		Debug.Log(exitFocusTime);
		Debug.Log(exitFocusTime - enteredFocusTime);
	}

//......................

	bool checkIfCentered()
	{
		
		bool inCenter = cameraRig.isObjectInCenterOfView(gameObject);
		if(inCenter) {

			if(centered == false)
			{
				enteredCenterTime = Time.time;
			}

			//DBG*************
			if(inFocus == false){
			GetComponent<Renderer>().material.color = new Color(0,1,1,1); //cyan
			}
			//DBG*************

			return true;
		}
		else
		{

			if(centered == true)
			{
				exitFocusTime = Time.time;
			}	

			//DBG***********
			GetComponent<Renderer>().material.color = new Color(1,0,0,1);

			if(inFocus == true){
				GetComponent<Renderer>().material.color = new Color(0.5f,0.5f,0,1);
			}
			//DBG*************

			return false;
		}
	}

	void checkIfInFocus()
	{
		float timeDiff;

		if(centered && inFocus == false){

			timeDiff = Time.time - enteredCenterTime;
			if(timeDiff >= 1)
			{

				enteredFocusTime = Time.time;
				inFocus = true;
				enteredFocus();

				//DBG*************
				GetComponent<Renderer>().material.color = new Color(0,1,0,1);
				//DBG*************

			}
		}

		if((centered == false || itIsVisible == false) && inFocus == true)
		{
			timeDiff = Time.time - exitFocusTime;
			if (timeDiff >= 1)
			{
				exitFocusTime = Time.time;
				inFocus = false;
				exitFocus();

				//DBG***********
				GetComponent<Renderer>().material.color = new Color(1,0,0,1);
				//DBG***********
			}
		}

		if(centered == true && inFocus == true)
		{
			//DBG*************
			GetComponent<Renderer>().material.color = new Color(0,1,0,1);
			//DBG*************
		}
	}


}
