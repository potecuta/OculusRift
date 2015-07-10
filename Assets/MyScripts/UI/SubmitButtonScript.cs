using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine.UI;
using DataModel;
using System;
using System.Diagnostics;

public class SubmitButtonScript : MonoBehaviour {

    GameObject form;
    GameObject selectScene;
	GameObject DorintaFumat;
   // Use this for initialization
	void Start () {
        if (selectScene == null && name=="GameObject")
        {
            form = GameObject.Find("Form");
            selectScene = GameObject.Find("SelectScene");
			DorintaFumat = GameObject.Find("DorintaFumat");
			DorintaFumat.SetActive(false);
            selectScene.SetActive(false);
        }
        

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addToScore()
    {
        
        if(!gameObject.GetComponent<Toggle>().isOn)
            Globals.userScore -= Int32.Parse(name[name.Length - 1].ToString());
        else
        Globals.userScore += Int32.Parse(name[name.Length-1].ToString());

		UnityEngine.Debug.Log(Globals.userScore);
        

    }

    public void setGender()
    {
        Toggle toggle = gameObject.GetComponent<Toggle>();
        if (gameObject.GetComponent<Toggle>().isOn)
            if (name == "F")
                Globals.gender = "F";
            else
                if (name == "B")
                    Globals.gender = "M";
		UnityEngine.Debug.Log (Globals.gender);
    }

    public void postInfo()
    {
		string age = GameObject.Find ("AgeInputField").transform.GetChild(2).GetComponent<Text> ().text;
		string smokingAge = GameObject.Find("SmokingAgeInputField").transform.GetChild(2).GetComponent<Text> ().text;

        User newUser = new User("", "", Globals.gender, age, smokingAge, 0, Globals.userScore);

        RequestManager rM = GameObject.FindObjectOfType<RequestManager>();
        SimpleJSON.JSONClass gameData = new SimpleJSON.JSONClass();
        gameData["oculusUser"] = newUser.writeUserInJson();
        string user = gameData.ToString();
        //rM.sendGameData(user);
		System.IO.File.WriteAllText(Environment.CurrentDirectory + @"/Kitchen/userConfig.txt", user);

		string text = System.IO.File.ReadAllText(Environment.CurrentDirectory + @"/Kitchen/userId.txt");
		if (text.Length == 0) {
			System.IO.File.WriteAllText (Environment.CurrentDirectory + @"/Kitchen/userId.txt", "1");
		} else {
			int id = Int32.Parse(text) + 1;
			System.IO.File.WriteAllText(Environment.CurrentDirectory + @"/Kitchen/userId.txt", id.ToString());

		}


        form.SetActive(false);
        selectScene.SetActive(true);
        GameObject.Find("Scrollbar").SetActive(false);       
    }

    public void LoadKitchen()
    {

		var processStartInfo = new ProcessStartInfo(Directory.GetCurrentDirectory() 
		                                            + @"\Kitchen\Kitchen_DirectToRift.exe");
		processStartInfo.WorkingDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory() + @"\Kitchen\Kitchen_DirectToRift.exe");
		Process.Start(processStartInfo);
		//Application.LoadLevel(2);
    }

    public void LoadForest()
    {
		var processStartInfo = new ProcessStartInfo(Directory.GetCurrentDirectory() 
		                                            + @"\Forest\Forest_DirectToRift.exe");
		processStartInfo.WorkingDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory() + @"\Forest\Forest_DirectToRift.exe");
		Process.Start(processStartInfo);
    }
}
