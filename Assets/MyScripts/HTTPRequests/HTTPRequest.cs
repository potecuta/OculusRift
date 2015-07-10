using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class HTTPRequest : MonoBehaviour {

    void Start() { }

    public WWW GET(string url)
    {
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
        return www;
    }

    public WWW POST(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
        return www;
    }

    public WWW POST(string url, string postString)
    {
        WWWForm form = new WWWForm();
        Dictionary<string, string> headers = new Dictionary<string, string>();
        byte[] rawData = form.data;

        headers.Add("Content-Type", "application/json;charset=UTF-8");
        //headers.Add("Content-Encoding", "text/plain");
        rawData = System.Text.Encoding.UTF8.GetBytes(postString.ToCharArray());
       

        WWW www = new WWW(url, rawData, headers);
      


        StartCoroutine(WaitForRequest(www));


		System.IO.File.WriteAllText(Environment.CurrentDirectory + "temp.txt", www.responseHeaders["userId"]);

        return www;
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        while(!www.isDone){}
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
   
}
