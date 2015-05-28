using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private HUDComponent onScreenCanvasHUDComponent;

    // Use this for initialization
    void Start()
    {
       // try
       // {
       //     GameObject canvas = GameObject.FindGameObjectWithTag("OnScreenCanvas");
       //     onScreenCanvasHUDComponent = canvas.GetComponent<HUDComponent>();
       //     printOnScreenMessage("Welcome! Вяш эи пытынтёюм ылаборарэт, эи видэ лебыр дылыктуч эжт. Хабэо факилиз позтюлант ед мэя, дольор кончэтытюр ан нык. Дуо трётанё трактатоз нэ. Векж дёко едквюэ ыт, про ан алиё эрат констятюам, конгуы лыгэндоч патриоквюы ед эож.", 25);
    
       // }
       // catch(UnityException)
       // {
       //      InitializeHUDComponent();
       //      GameObject canvas = GameObject.FindGameObjectWithTag("OnScreenCanvas");
       //      onScreenCanvasHUDComponent = canvas.GetComponent<HUDComponent>();
       //      printOnScreenMessage("Welcome! Вяш эи пытынтёюм ылаборарэт, эи видэ лебыр дылыктуч эжт. Хабэо факилиз позтюлант ед мэя, дольор кончэтытюр ан нык. Дуо трётанё трактатоз нэ. Векж дёко едквюэ ыт, про ан алиё эрат констятюам, конгуы лыгэндоч патриоквюы ед эож.", 25);

       //      // GameObject gm = GameObject.FindGameObjectWithTag("GlobalManager");
       //      // HTTPRequest hr = gm.GetComponent<HTTPRequest>();
       //      // WWW www = hr.GET("http://google.com");
       //      // printOnScreenMessage(www.text, 200);
       //  }
    
         InitializeHUDComponent();
            GameObject canvas = GameObject.FindGameObjectWithTag("OnScreenCanvas");
            onScreenCanvasHUDComponent = canvas.GetComponent<HUDComponent>();
            printOnScreenMessage("Welcome! Вяш эи пытынтёюм ылаборарэт, эи видэ лебыр дылыктуч эжт. Хабэо факилиз позтюлант ед мэя, дольор кончэтытюр ан нык. Дуо трётанё трактатоз нэ. Векж дёко едквюэ ыт, про ан алиё эрат констятюам, конгуы лыгэндоч патриоквюы ед эож.", 25);
        
     }


    // Update is called once per frame
    void Update()
    {

    }
    
    public void InitializeHUDComponent()
    {
        OVRPlayerController player = GameObject.FindObjectOfType<OVRPlayerController>();
        GameObject centerEyeObj = GameObject.FindGameObjectWithTag("MainCamera");

            if(centerEyeObj != null)
            {Debug.Log("gasit centerEye");}

            GameObject hudGO;
            GameObject hudTextGO;
            GameObject hudPanelBkgrGO;

            hudGO = new GameObject();
            hudTextGO = new GameObject();
            hudPanelBkgrGO = new GameObject();

            hudGO.name = "hudCanvasGO";
            hudGO.tag = "OnScreenCanvas";
            hudTextGO.name = "hudTextGO";
            hudPanelBkgrGO.name = "hudPanelBkgrGO";

            hudGO.transform.parent = centerEyeObj.transform;
            hudTextGO.transform.parent = hudPanelBkgrGO.transform;
            hudPanelBkgrGO.transform.parent = hudGO.transform;
            
            hudGO.AddComponent<Canvas>();
            // hudGO.AddComponent<RectTransform>();
            hudGO.AddComponent<CanvasScaler>();
            hudGO.AddComponent<GraphicRaycaster>();
            hudGO.AddComponent<HUDComponent>();
            
            hudPanelBkgrGO.AddComponent<RectTransform>();
            hudPanelBkgrGO.AddComponent<CanvasRenderer>();
            hudPanelBkgrGO.AddComponent<Image>();

            hudTextGO.AddComponent<RectTransform>();
            hudTextGO.AddComponent<CanvasRenderer>();
            hudTextGO.AddComponent<Text>();
            
            hudGO.GetComponent<HUDComponent>().InitiateSettings();
    }


    public void printOnScreenMessage(string text, float timeToShow)
    {
        if (onScreenCanvasHUDComponent != null)
        {
            Debug.Log("show text");
            onScreenCanvasHUDComponent.ShowCanvas();
            onScreenCanvasHUDComponent.SetText(text);
            onScreenCanvasHUDComponent.SetTimer(timeToShow);
        }
    }

}