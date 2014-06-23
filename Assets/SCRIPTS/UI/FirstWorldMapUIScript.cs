using UnityEngine;
using System.Collections;

public class FirstWorldMapUIScript : MonoBehaviour {

    Transform thisTransform;
    Animator fadeAnimator;

    string levelName;

    //Buttons textures
    public Texture worldPicture;
    public Texture level1;
    public Texture level2;
    public Texture level3;
    public Texture level4;
    public Texture level5;
    public Texture levelInfinite;

    public Texture questionLevelRed;
    public Texture questionLevelYellow;
    public Texture questionLevelGreen;

    public Texture goBackTexture;
      

    //Original size, preferred size we are going to use to adapt size of buttons.
    float originalWidth = 854;// Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 2056.
    float originalHeight = 560;//Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 1536.

    
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

        if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(10, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(10, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), "RESET"))
        {
            PlayerPrefs.DeleteAll();

        }

        if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(138, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(138, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), level1))
        {
            //fadeAnimator.SetTrigger("Blackout");
            levelName = "LEVEL_1";
            LoadLevel();
            //Invoke("LoadLevel", 2.20f);
        }

        if (PlayerPrefs.GetInt("Level1Done") == 1)
        {
            if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(260, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(260, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), level2))
            {
                Application.LoadLevel("LEVEL_2");

            }
        }
        else
        {
            if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(260, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(260, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), questionLevelRed))
            {
                //Application.LoadLevel("LEVEL_2");

            }
        }
        if (PlayerPrefs.GetInt("Level2Done") == 1)
             {
                 if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(390, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(390, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), level3))
                 {
                Application.LoadLevel("LEVEL_3");
             }
        }
        else
        {
            if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(390, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(390, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), questionLevelRed))
            {
                //Application.LoadLevel("LEVEL_3");

            }
        }
        if (PlayerPrefs.GetInt("Level3Done") == 1)
             {
                 if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(520, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(650, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), level4))
             {                         
                Application.LoadLevel("LEVEL_4");
             }
        }
        else
        {
            if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(520, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(650, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), questionLevelRed))
            {
                //Application.LoadLevel("LEVEL_4");

            }
        }
        if (PlayerPrefs.GetInt("Level4Done") == 1)
        {
            if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(650, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(780, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), level5))
            {
                //Application.LoadLevel("LEVEL_5");
            }
        }
        else
        {
            if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(650, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(780, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), questionLevelYellow))
            {
                //Application.LoadLevel("LEVEL_5");
            }
        }
        if (PlayerPrefs.GetInt("Level5Done") == 1)
             {
                 if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(730, 10, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(910, 10, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), questionLevelYellow))
             {
                //Application.LoadLevel("LEVEL_INFINITE");
             }
        }


        if (GUI.Button(new Rect(readjustGUIscript.ReadjustGUIPosition(10, 400, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUIPosition(10, 400, originalWidth, originalHeight).y,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).x,
            readjustGUIscript.ReadjustGUISize(128, 128, originalWidth, originalHeight).y), goBackTexture))
        {
            Application.LoadLevel("MainMenu");
        }
                                 
                
    }

    void LoadLevel()
    {     
        Application.LoadLevel(levelName);
    }  

}
