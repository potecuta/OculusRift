using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;

public class RequestManager : MonoBehaviour {

	// Use this for initialization
     void Start()
    {
    
    }


    

	// Update is called once per frame
	void Update () {
        
	}


    public void sendGameData(string jsonToSend)
    {
		string text = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"/myConfig.txt");

        HTTPRequest request = gameObject.GetComponent<HTTPRequest>();
        request.POST(text + "/api/oculusUsersWithEvents", jsonToSend);
    }

    public void sendEvent(string jsonToSend)
    {
        HTTPRequest request = gameObject.GetComponent<HTTPRequest>();
        request.POST("http://172.17.254.180:8080/api/oculusEventsWithUsers", jsonToSend);
    }
}
