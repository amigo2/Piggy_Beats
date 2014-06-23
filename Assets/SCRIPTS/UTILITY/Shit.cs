using UnityEngine;
using System.Collections;

public class Shit : MonoBehaviour {

    public bool boolMouseOver;

    public GUISkin MyGUISkin;



    void OnGUI()
    {
        if (boolMouseOver == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 190, Screen.height / 2 - 140, 240, 320), new GUIContent("", "Mouse Exit Button"));// Exit GUI Box ,MyGUISkin.customStyles[0] must be transparent png or nothing
            GUI.Box(new Rect(Screen.width / 2 - 180, Screen.height / 2 - 130, 220, 300), new GUIContent("", "Mouse Over Box"));// Original box
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 125, 180, 40), "1"))
            {

            }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 75, 180, 40), "2"))
            {

            }
            if (GUI.Button(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 25, 180, 40), "3"))
            {

            }

        }

        GUI.Box(new Rect(Screen.width / 2 - 390, Screen.height / 2 - 140, 210, 70), new GUIContent("", "Mouse Exit Button"));// Mouse Exit BoxMyGUISkin.customStyles[0] must be transparent png or nothing
        GUI.Button(new Rect(Screen.width / 2 - 380, Screen.height / 2 - 130, 200, 50), new GUIContent("MENU", "Mouse Over Button"));// Menu Button



        if (GUI.tooltip == "Mouse Over Button")
        {
            boolMouseOver = true;
        }

        if (GUI.tooltip == "Mouse Exit Button")
        {
            boolMouseOver = false;
        }


    }  
}
