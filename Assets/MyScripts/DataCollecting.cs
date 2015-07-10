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
        
		string text = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"/userConfig.txt");
		string gameDataString = gameData.ToString ();
		text = text.TrimEnd ('}');
		text = text.TrimStart ('{');
		text = text + "},";
		gameDataString = gameDataString.Insert (1, text);

		System.IO.Directory.CreateDirectory(Environment.CurrentDirectory + @"/DateStranse");
		System.IO.File.WriteAllText(Environment.CurrentDirectory + @"/DateStranse/" + fileName(), gameDataString);

		gameObject.GetComponent<RequestManager>().sendGameData(gameDataString);
   
        
        Debug.Log("printJson");
		
		
	}
	
	private void populateJson()
	{
       //gameData["oculusUser"] = user.writeUserInJson();
       gameData["oculusEventList"] = gameObject.GetComponent<EventManager>().getJsonList();
	} 

	private string fileName()
	{
		string text = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"/userId.txt");
		string fileName = string.Concat(text,".txt");

		fileName = fileName.Replace("/","_");

		return fileName;
	}


}
