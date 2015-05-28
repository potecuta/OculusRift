using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using DataModel;
using SimpleJSON;


public class DataCollecting : MonoBehaviour {

	private User user;
	private JSONClass gameData;

	// Use this for initialization
	void Start () {
	
		gameData = new JSONClass();
		user = new User("Razvanel","Brezulici", "male", 20, 19, 0.2f);
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.P))
		{
			printJsonToFile();
		}
	}

	public void printJsonToFile()
	{
		populateJson();

		Debug.Log("printJson");
		System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + @"/DateStranse");
		System.IO.File.WriteAllText(Environment.CurrentDirectory + @"/DateStranse/" + fileName(), gameData.ToString());
		
	}
	
	private void populateJson()
	{
		gameData["user"] = user.getJson();
		gameData["event_list"] = gameObject.GetComponent<EventManager>().getJsonList();
	} 

	private string fileName()
	{
		string fullName = string.Concat(user.FirstName, "_", user.FamilyName, "_");
		string fileName = string.Concat(fullName,
										DateTime.Now.ToShortDateString(),
										".txt"
										);

		fileName = fileName.Replace("/","_");

		return fileName;
	}


}
