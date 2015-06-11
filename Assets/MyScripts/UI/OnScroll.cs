using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnScroll : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        
	}
	

	// Update is called once per frame
	void Update () {
       
	}

    Vector3 initPosition;
    GameObject togglel;

    public void onScroll()
    {
        if (togglel == null)
        {
            togglel = GameObject.Find("Form");

            initPosition = togglel.transform.localPosition;
        }

        Scrollbar scrollBar = GameObject.FindGameObjectWithTag("Scroll").GetComponent<Scrollbar>();
      
      GameObject.Find ("Form").transform.localPosition = initPosition + new Vector3(0, scrollBar.value*300,0);
    
    }
}
