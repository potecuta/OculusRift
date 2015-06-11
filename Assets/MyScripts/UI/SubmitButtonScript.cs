using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using UnityEngine.UI;
using DataModel;

public class SubmitButtonScript : MonoBehaviour {

   // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void postInfo()
    {
        string firstName = GameObject.Find("firstNameInputField").GetComponent<Text>().text;
        string lastName = GameObject.Find("lastNameInputField").GetComponent<Text>().text;
        User newUser = new User(firstName, lastName, "M", 99, 100, 1);
        RequestManager rM = GameObject.FindObjectOfType<RequestManager>();
        SimpleJSON.JSONClass gameData = new SimpleJSON.JSONClass();
        gameData["oculusUser"] = newUser.writeUserInJson();
        string user = gameData.ToString();
        rM.sendGameData(user);
        if(Globals.userID!=0)
             Application.LoadLevel(1);
    }
}
