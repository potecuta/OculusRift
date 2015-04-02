using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDComponent : MonoBehaviour {

    private float timer;
    public Text hudText; 
	// Use this for initialization
	void Start () {
        hideCanvas();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
            gameObject.SetActive(false);
	}

    public void showCanvas()
    {
        gameObject.SetActive(true);
    }

    public void hideCanvas()
    {
        gameObject.SetActive(false);
    }

    public void setTimer(float time)
    {
        timer = time;
    }

    public void setText(string txt)
    {
        hudText.text = txt;
    }
}
