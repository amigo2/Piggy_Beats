using UnityEngine;
using System.Collections;

public class MovementControlSwitcher : MonoBehaviour {

    bool showMoveMenu = false;
    public float fittingScreenGapValue = 0.02f;

    public static string MovementSelected;

    ClickAndMove clickAndMoveScript;
    //Movement_Buttons buttonsMoveScript;
    Movement_Accelerometer accelerometerScript;
    SuperJoystick joystickScript;
    ReallocatePositionAndSizeGUI readjustGUIScript;

    //Create anchor points.
    Vector3 leftUpAnchor = new Vector3(0f, 0f, 0f);

    //Create Margins.
    Vector2 minimumMargin; 

    //Original size, preferred size we are going to use to adapt size of buttons.
    float originalWidth = 854;// Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 2056.
    float originalHeight = 480;//Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 1536.

    // Scale variable
    Vector3 scale;

    public Texture settingsText, clickMoveText, joystickText;

	// Use this for initialization
	void Start () {
        clickAndMoveScript = (ClickAndMove)GameObject.FindGameObjectWithTag("Player").GetComponent<ClickAndMove>();
        accelerometerScript = (Movement_Accelerometer)GameObject.FindGameObjectWithTag("Player").GetComponent<Movement_Accelerometer>();
        joystickScript = (SuperJoystick)Camera.main.transform.FindChild("TomatoJoystick").GetComponent<SuperJoystick>();
        readjustGUIScript = (ReallocatePositionAndSizeGUI)Camera.main.transform.GetComponent<ReallocatePositionAndSizeGUI>();

        minimumMargin = new Vector2(Screen.width * fittingScreenGapValue, Screen.height * fittingScreenGapValue);

        switch (MovementSelected)
        {
            case "ClickAndMove":
                try
                {
                    clickAndMoveScript.enabled = true;
                    Camera.main.transform.FindChild("TomatoJoystick").gameObject.SetActive(false);
                }
                catch
                {

                }
                break;
            case "Joystick":
                try
                {
                    Camera.main.transform.FindChild("TomatoJoystick").gameObject.SetActive(true);
                    clickAndMoveScript.enabled = false;
                }
                catch
                {

                }
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnGUI()
    {
               
        GUI.backgroundColor = Color.clear;
                
        if (GUI.Button(new Rect(readjustGUIScript.ReadjustGUIPosition(754, 380, originalWidth, originalHeight).x, readjustGUIScript.ReadjustGUIPosition(754, 380, originalWidth, originalHeight).y,
            readjustGUIScript.ReadjustGUISize(92, 106, originalWidth, originalHeight).x, readjustGUIScript.ReadjustGUISize(92, 106, originalWidth, originalHeight).y), settingsText))
        {
            if (showMoveMenu == true)
            {
                showMoveMenu = false;
            }
            else
            {
                showMoveMenu = true;
            }
        }            

        if (showMoveMenu == true)
        {
            if (GUI.Button(new Rect(Screen.width - minimumMargin.x - 104, Screen.height - minimumMargin.y - 196, 104, 104), clickMoveText))
            {
                clickAndMoveScript.enabled = true;
                accelerometerScript.enabled = false;
                Camera.main.transform.FindChild("TomatoJoystick").gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().isKinematic = false;
                MovementSelected = "ClickAndMove";
                showMoveMenu = false;
            }
           
            else if (GUI.Button(new Rect(Screen.width - minimumMargin.x - 104, Screen.height - minimumMargin.y - 288, 104, 104), joystickText))
            {
                clickAndMoveScript.enabled = false;
                accelerometerScript.enabled = false;
                Camera.main.transform.FindChild("TomatoJoystick").gameObject.SetActive(true);
                MovementSelected = "Joystick";
                showMoveMenu = false;
            }
            
           
        }

        
    }
}
