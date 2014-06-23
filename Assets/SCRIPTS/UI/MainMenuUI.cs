using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

    Transform thisTransform;
    Animator fadeAnimator;
    public GUIStyle buttonStyle;

    
    //Original size, preferred size we are going to use to adapt size of buttons.
    float originalWidth = 854;// Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 2056.
    float originalHeight = 480;//Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 1536.

    // Scale variable
    Vector3 scale;
    ReallocatePositionAndSizeGUI readjustGUIscript;

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        fadeAnimator = thisTransform.FindChild("BlackOut").GetComponent<Animator>();
        readjustGUIscript = (ReallocatePositionAndSizeGUI)Camera.main.transform.GetComponent<ReallocatePositionAndSizeGUI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
                

        GUI.backgroundColor = Color.clear;

        //Adventure button
        if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(400, 140, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(400, 140, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(420, 75, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(420, 75, originalWidth, originalHeight).y), ""))
        {
            fadeAnimator.SetTrigger("Blackout");
            Invoke("LoadAdventure", 2.22f);
            
        }

        
        
    }

    

    void LoadAdventure()
    {
        
        Application.LoadLevel("LEVEL_MAP");
        fadeAnimator.SetTrigger("Fadein");
    }
}
