using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDComponent : MonoBehaviour {
    
    public bool defaultCoords = true;
    
    private float timer;
    private Text hudText;
    private int lengthText;

    GameObject hudGO;
    GameObject hudTextGO;
    GameObject hudPanelBkgrGO;

    // Use this for initialization
	void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            ShowCanvas();
            timer -= Time.deltaTime;
        }
        else
            HideCanvas();
        if (defaultCoords)
            ResetToDefaultCoords();
        //setText("We are ... Experience with Oculus Rift would be a huge benefit, as well as in ... app is built on unity and requires android pro addon i dont have unity pro or ... for layout i love thi");
    
	}


// var target : Transform; 
//  var moveSpeed = 20; 
//  var rotationSpeed = 5; 
//  var myTransform : Transform;
 
//  function Awake() { myTransform = transform; }
//  function Start() {
//  target = GameObject.FindWithTag("Player").transform; 
//  }
 
//  function Update () {
 
//   myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
//   Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime); 
//   myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;


    public void ResetToDefaultCoords()
    {
        GameObject cameraRig = GameObject.FindGameObjectWithTag("MainCamera");


        RectTransform rtHandler = GetComponent<RectTransform>();
        rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 5);
        rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 5);
        rtHandler.localPosition = new Vector3(0.0f, 0.0f, 1.5f);
        rtHandler.localScale = new Vector3(.5f, .1f, .2f);
        // rtHandler.localPosition = new Vector3(10.0f, 1.7f, 0.5f);
        
        Transform myTransform = rtHandler.transform;
        float rotationSpeed = 5.0f;
        float moveSpeed = 20.0f;
       	myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
       		Quaternion.LookRotation(cameraRig.transform.position - myTransform.position),
       		rotationSpeed*Time.deltaTime);
       	rtHandler.position += myTransform.forward;

    }

    public void InitiateSettings()
    {
    	Debug.Log("initiate settings");
        hudGO = gameObject;
        hudPanelBkgrGO = gameObject.transform.FindChild("hudPanelBkgrGO").gameObject;
        hudTextGO = hudPanelBkgrGO.transform.FindChild("hudTextGO").gameObject;

        GameObject cameraRig = GameObject.FindGameObjectWithTag("MainCamera");

        //CanvasSettings
        Canvas cHandler = hudGO.GetComponent<Canvas>();
            cHandler.renderMode = RenderMode.WorldSpace;
        RectTransform rtHandler = hudGO.GetComponent<RectTransform>();
        rtHandler.anchoredPosition3D = Vector3.zero;
        
        rtHandler.anchorMax = Vector2.zero;
        rtHandler.anchorMin = Vector2.zero;
        rtHandler.pivot = new Vector2(0.5f, 0.5f);
        rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, .1f);
        rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, .1f);
        rtHandler.localScale = new Vector3(.5f, .1f, .2f);
        rtHandler.localPosition = new Vector3(10.0f, 1.7f, 0.5f);
        
        CanvasScaler csHandler = hudGO.GetComponent<CanvasScaler>();
            csHandler.dynamicPixelsPerUnit = 1;
            csHandler.referencePixelsPerUnit = 100;
        GraphicRaycaster grHandler = hudGO.GetComponent<GraphicRaycaster>();
            grHandler.ignoreReversedGraphics = true;
            grHandler.blockingObjects = GraphicRaycaster.BlockingObjects.None;
        defaultCoords = true;
    
        //TextSettings
        Text tHandler = hudTextGO.GetComponent<Text>();
            tHandler.font = Resources.Load<Font>("DINPro-Bold");
            tHandler.material = Resources.Load<Material>("GUIHUD");
            tHandler.fontSize = 180;
            tHandler.text = "TEXT";
            rtHandler = hudTextGO.GetComponent<RectTransform>();
            rtHandler.localPosition = Vector3.zero;
            rtHandler.pivot = new Vector2(.5f, .5f);
            rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 2000f);
            rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2000f);
            rtHandler.localScale = new Vector3(0.0017f, 0.0027f, 0.0017f);
        
        //Background Panel Settings
            rtHandler = hudPanelBkgrGO.GetComponent<RectTransform>();
            
            rtHandler.localPosition = new Vector3(0, 0);
            rtHandler.pivot = new Vector2(.5f, .5f);
            rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 6f);
            rtHandler.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 6f);
            rtHandler.localScale = new Vector3(1, .5f, 1);
            
            Image iHandler = hudPanelBkgrGO.GetComponent<Image>();
            Sprite sp = Resources.Load<Sprite>("UIBackgroundModifiedExposure");
            iHandler.material = Resources.Load<Material>("GUIHUD");
            
            if(sp == null)
            {
                Debug.LogError("SpriteNotFound", this);
            }
            else
            {
                iHandler.sprite = Resources.Load<Sprite>("UIBackgroudModifiedExposure");
            }
                iHandler.color = new Color(.3f, .3f, .3f);
                Color iColor = iHandler.color;
                iColor.a = .1f;
                iHandler.color = iColor;
    }

    public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }

    public void HideCanvas()
    {
        gameObject.SetActive(false);
    }

    public void SetTimer(float time)
    {
        timer = time;
    }

    public void SetText(string txt)
    {
        if ((hudText = gameObject.GetComponentInChildren<Text>()) != null)
        {
            hudText.text = txt;
            lengthText = txt.Length;
        }
    }
}
