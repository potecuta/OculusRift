using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public HUDComponent onScreenCanvas;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void printOnScreenMessage(string text, float timeToShow)
    {
        onScreenCanvas.showCanvas();
        onScreenCanvas.setText(text);
        onScreenCanvas.setTimer(timeToShow);
    }

}