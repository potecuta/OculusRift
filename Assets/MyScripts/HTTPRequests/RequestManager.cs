﻿using UnityEngine;
using System.Collections;
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

        HTTPRequest request = gameObject.GetComponent<HTTPRequest>();
        request.POST("http://192.168.1.105:8080/api/oculusUsersWithEvents", jsonToSend);
    }

    public void sendEvent(string jsonToSend)
    {
        HTTPRequest request = gameObject.GetComponent<HTTPRequest>();
        request.POST("http://172.17.254.180:8080/api/oculusEventsWithUsers", jsonToSend);
    }
}
