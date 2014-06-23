using UnityEngine;
using System.Collections;

public class MatrixGUI : MonoBehaviour {

    Texture2D homeButtonTexture;

    //Create anchor points.
    Vector3 leftUpAnchor = new Vector3 (0f,0f,0f);

    //Create Margins.
    Vector2 minimumMargin = new Vector2(Screen.width / 10, Screen.height / 10);

    //Original size, preferred size we are going to use to adapt size of buttons.
    float originalWidth = 640;// Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 2048.
    float originalHeight = 480;//Don't know yet but problably if we are going to use textured ones, this might be the iPad size, 1536.

    // Scale variable
    Vector3 scale;




    void OnGUI()
    {
        
        //Initialize values acording to screen size.
        scale.x = Screen.width / originalWidth;
        scale.y = Screen.height / originalHeight;
        scale.z = 1;


        //Save Matrix, what this does is saving the values of the GUI Matrix(translation, scale, rotation) 
        //Open matrix calculation.
        Matrix4x4 svMatrix = GUI.matrix;
        
        //Recalculate the matrix..
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

        //Add al buttons to be recaltulated in whatever the size and maybe position
        GUI.Button(new Rect (100, 100, 100 ,100),"Button");

        //Button clickable. You dont need anymore neither define the position( This needs to be properly tested).
        if (GUI.Button(new Rect(leftUpAnchor.x + minimumMargin.x, leftUpAnchor.y + minimumMargin.y, 100, 50), "HOME"))
        {
            Application.LoadLevel("GAMES_MENU");
        }


        //Close and return ne Matrix value.
        GUI.matrix = svMatrix;
       
    }

}
