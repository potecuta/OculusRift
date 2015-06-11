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
        }
        selectScene.SetActive(false);
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

    public void postInfo()
    {
 //       string firstName = GameObject.Find("firstNameInputField").GetComponent<Text>().text;
   //     string lastName = GameObject.Find("lastNameInputField").GetComponent<Text>().text;
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
       
    }
    public void LoadForest()
    {
        Application.LoadLevel(2);
    }

    public void LoadKitchen()
    {
        Application.LoadLevel(1);
    }
}
