using UnityEngine;
using System.Collections;
using DataModel;


public class FocusScript : MonoBehaviour {

	public bool debugMode;
	public float timeNeededToEnterFocus;
	public float timeNeededToExitFocus;

	private OVRPlayerController player;
	private SMKCameraUtilities cameraRig;

	private bool itIsVisible;
	private bool centered;
	private bool focused;

	private float enteredCenterTime;
	private float exitCenterTime;
	private float enteredFocusTime;
	private float exitFocusTime;

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
    // UIManager uiMgr;
	// Use this for initializationuni
	void Start () {

        // globalGameObject = GameObject.Find("_GlobalManager"); 
        // uiMgr = (UIManager)globalGameObject.GetComponent("UIManager"); 
        // uiMgr.printOnScreenMessage("123123", 2);


		if(timeNeededToEnterFocus == 0) timeNeededToEnterFocus = 1.5f;
		if(timeNeededToExitFocus == 0) timeNeededToExitFocus = 1.5f;

		player = GameObject.FindObjectOfType<OVRPlayerController>();
		cameraRig = player.GetComponent<SMKCameraUtilities>();

		itIsVisible = false;
		centered = false;
		focused = false;
	}
	


	// Update is called once per frame
	void Update () {
		
		if(itIsVisible)	{
			
			centered = checkIfCentered();

			checkIfFocused();

		}
		else
		{
			//DBG*******
			if(debugMode)
			{
				GetComponent<Renderer>().material.color = new Color(1,0,0,1);
			}
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

		FocusEvent focusEvent = new FocusEvent(gameObject.name,enteredFocusTime,exitFocusTime);
	
		Object[] objs = GameObject.FindGameObjectsWithTag("GlobalManager");
		if(objs != null)
		{
			GameObject generalManager = objs[0] as GameObject;
			EventManager eventManager = generalManager.GetComponent<EventManager>();
			eventManager.addFocusEvent(focusEvent);
		}

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
			if(debugMode)
			{
				if(focused == false){
				GetComponent<Renderer>().material.color = new Color(0,1,1,1); //cyan
				}
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
			if(debugMode)
			{
				GetComponent<Renderer>().material.color = new Color(1,0,0,1);

				if(focused == true){
					GetComponent<Renderer>().material.color = new Color(0.5f,0.5f,0,1);
				}
			}
			//DBG*************

			return false;
		}
	}

	void checkIfFocused()
	{
		float timeDiff;

		if(centered && focused == false){

			timeDiff = Time.time - enteredCenterTime;
			if(timeDiff >= timeNeededToEnterFocus)
			{
                
				enteredFocusTime = Time.time;
				focused = true;
                // uiMgr.printOnScreenMessage("Focused", 3);
				enteredFocus();

				//DBG*************
				if(debugMode)
				{
					GetComponent<Renderer>().material.color = new Color(0,1,0,1);
				}
				//DBG*************

			}
		}

		if((centered == false || itIsVisible == false) && focused == true)
		{
			timeDiff = Time.time - exitFocusTime;
			if (timeDiff >= timeNeededToExitFocus)
			{
				exitFocusTime = Time.time;
				focused = false;
                // uiMgr.printOnScreenMessage("NotFocused", 3);
				exitFocus();

				//DBG***********
				if(debugMode)
				{	
					GetComponent<Renderer>().material.color = new Color(1,0,0,1);
				}
				//DBG***********
			}
		}

		if(centered == true && focused == true)
		{
			//DBG*************
			if(debugMode)
			{
				GetComponent<Renderer>().material.color = new Color(0,1,0,1);
			}
			//DBG*************
		}
	}


}
