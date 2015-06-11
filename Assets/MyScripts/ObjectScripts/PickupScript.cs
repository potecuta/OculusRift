using UnityEngine;
using System.Collections;
using DataModel;

public class PickupScript : MonoBehaviour {

	public bool debugMode;
    public string location;


	private Transform player;

	private SMKCameraUtilities cameraRig;
	private OVRPlayerController playerController;

	private bool itIsVisible;
	private bool centered;
	private bool beingCarried;

	private float pickTime; 
	private float dropTime;


	// Use this for initialization
	void Start () {
	
		playerController = GameObject.FindObjectOfType<OVRPlayerController>();
		cameraRig = playerController.GetComponent<SMKCameraUtilities>();
		player = GameObject.FindGameObjectWithTag ("MainCamera").transform;

		itIsVisible = false;
		centered = false;
		beingCarried = false;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(itIsVisible)	{
			
			centered = checkIfCentered();

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

		pickUp ();
	}

	void OnBecameVisible()
	{
		enabled = true;
		Debug.Log("tigara");
		
		itIsVisible = true;
		
	} 
	
	void OnBecameInvisible()
	{
		enabled = false;
		
		itIsVisible = false;
	}

	void pickUp()
	{
		if(beingCarried == true)
			{
				if(Input.GetMouseButtonDown(1))
				{
					Debug.Log("drop tigara");	
					gameObject.GetComponent<Rigidbody>().isKinematic = false;
					transform.parent = null;
					beingCarried = false;
					dropTime = Time.time;
					addFocusEvent();

					Destroy(gameObject);
					return;
				}
			}
				

				if(centered && Input.GetMouseButtonDown(0))
				{
					gameObject.GetComponent<Rigidbody>().isKinematic = true;
					transform.parent = player;
					beingCarried = true;

					pickTime = Time.time;
					playSmoke();
				}


	}

	void addFocusEvent()
	{

		FocusEvent focusEvent = new FocusEvent(gameObject.name,"pick",location,pickTime,dropTime);
	
		Object[] objs = GameObject.FindGameObjectsWithTag("GlobalManager");
		if(objs != null)
		{
			GameObject generalManager = objs[0] as GameObject;
			EventManager eventManager = generalManager.GetComponent<EventManager>();
			eventManager.addFocusEvent(focusEvent);
		}

	}

	bool checkIfCentered()
	{
		
		bool inCenter = cameraRig.isObjectInCenterOfView(gameObject);
		if(inCenter) {
		
			return true;
		}
		else
		{

			
			//DBG***********
			if(debugMode)
			{
				GetComponent<Renderer>().material.color = new Color(1,0,0,1);

			}
			//DBG*************
			
			return false;
		}
	}

	public void lightCigarette()
	{
		playSmoke();
	}

	private void playSmoke()
	{
		ParticleSystem smoke = gameObject.GetComponentInChildren<ParticleSystem>();
		smoke.Play();
	}

	private  void stopSmoke()
	{
		ParticleSystem smoke = gameObject.GetComponentInChildren<ParticleSystem>();
		smoke.Stop();
	}


	public bool getBeingCarried()
	{

		return beingCarried;
	}
}
