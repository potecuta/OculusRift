using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System;

public class WaitAndLoad : MonoBehaviour {

    AsyncOperation loader;
    WWW httpObj;
    int sceneNr;

	// Use this for initialization
	void Start () {

		string text = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"/myConfig.txt");
		
		Application.OpenURL(text);
        string url = "www.google.com";
        StartCoroutine(SendRequest(url));
    }

    IEnumerator SendRequest(string url)
    {
        HTTPRequest httpReq = gameObject.GetComponent<HTTPRequest>();
        httpObj = httpReq.GET(url);
        
        if(!httpObj.isDone)
            yield return httpObj;
        sceneNr = 1;
        loader = Application.LoadLevelAsync(sceneNr);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            loader = Application.LoadLevelAsync(1);
            
        }
        else
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                loader = Application.LoadLevelAsync(1);
            }
	}
}
