using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine.UI;
using DataModel;
using System;

public class SubmitButtonScript : MonoBehaviour {

    GameObject form;
    GameObject selectScene;
   // Use this for initialization
	void Start () {
        if (selectScene == null && name=="GameObject")
        {
            form = GameObject.Find("Form");
            selectScene = GameObject.Find("SelectScene");
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
    }

    public void postInfo()
    {
		string age = GameObject.Find ("AgeInputField").GetComponentInChildren<Text> ().text;
		string smokingAge = GameObject.Find("SmokingAgeInputField").GetComponentInChildren<Text>().text;
     //   User newUser = new User(firstName, lastName, "M", 99, 100, 1);
      //  RequestManager rM = GameObject.FindObjectOfType<RequestManager>();
      //  SimpleJSON.JSONClass gameData = new SimpleJSON.JSONClass();
       // gameData["oculusUser"] = newUser.writeUserInJson();
       // string user = gameData.ToString();
       // rM.sendGameData(user);

        //if(Globals.userID!=0)
          //   Application.LoadLevel(1);
        form.SetActive(false);
         selectScene.SetActive(true);
         GameObject.Find("Scrollbar").SetActive(false);       
    }

    public void LoadForest()
    {
		GameObject.Find ("GlobalManager").GetComponent<CameraManager> ().activateOculusCamera ();
        Application.LoadLevel(2);
    }

    public void LoadKitchen()
    {
		GameObject.Find ("GlobalManager").GetComponent<CameraManager> ().activateOculusCamera ();
        Application.LoadLevel(1);
    }
}
