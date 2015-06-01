using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataModel;
using SimpleJSON;


public class EventManager : MonoBehaviour {

	private List<FocusEvent> eventList;


	// Use this for initialization
	void Start () {
		eventList = new List<FocusEvent>();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	public void addFocusEvent (FocusEvent focusEvent)
	{
		eventList.Add(focusEvent);
	} 

	public JSONArray getJsonList()
	{
		JSONArray jsonToReturn = new JSONArray();
		
		sortEventList();


		foreach (FocusEvent element in eventList)
		{

			jsonToReturn.Add("eventList", element.getJson());

		}


		return jsonToReturn;
	}

    public void sendJson()
    {
        JSONArray jsonToReturn = new JSONArray();

        sortEventList();

        RequestManager reqMan = gameObject.GetComponent<RequestManager>();

        foreach (FocusEvent element in eventList)
        {

            string js = element.getJson().ToString();
           
            reqMan.sendEvent(js);

        }
    }

	private void sortEventList()
	{
		eventList.Sort(CompareEventsByStartTime);
	}

	private static int CompareEventsByStartTime(FocusEvent a, FocusEvent b)
	{
		if(a == null)
		{
			if(b == null)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}
		else
		{

			if(b == null)
			{
				return 1;
			}
			else
			{
				// return a.enteredFocusTime.CompareTo(b.enteredFocusTime);
				 return a.ExitFocusTime.CompareTo(b.ExitFocusTime);
			}
		}
	}

}
