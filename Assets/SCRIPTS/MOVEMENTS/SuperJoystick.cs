using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperJoystick : MonoBehaviour {

    Vector2 previousMousePosition = Vector2.zero;
    Vector2 currentMousePosition = Vector2.zero;
    bool previousFrameMouseDown = false;
    public float speed;
    public GameObject player;
    Rigidbody playerRigidbody;
    Animator playerAnimator;
    
    LayerMask wall;
    int mask = ~(1 << 9);
    public float maxSpeed = 100.0f;
    Vector3 directionFacing;
    bool isInTheJoystick = false;
    bool isClicked = false;
    public Texture joystickButton;
    Vector2 cursorPoint;
    Ray cursorRay;
    public Texture pixel;

    private float degToRad = 0.017453256f; //converts from degrees to radians
    private float radToDeg = 57.29577951f; //converts from radians to degrees

    Vector2 currentPositionVector;
    Transform thisTransform;

    Vector2 pixelCenterOfJoystick;

    public bool BootsOn = false;

    UI_Script guiScript;

    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerAnimator = player.GetComponent<Animator>();
        wall = 9 << LayerMask.NameToLayer("Walls");
        thisTransform = transform;
        guiScript = (UI_Script)Camera.main.transform.GetComponent<UI_Script>();
                
      
    }
       

    private void Update()
    {
        if(Game_Manager.moveAndSpawn == true){
        if (BootsOn == true)
        {
            speed = 3.0f;
            maxSpeed = 3.0f;
        }
        else
        {
            speed = 2.3f;
            maxSpeed = 2.3f;
        }

        if (guiScript.showScore == true)
        {
            return;
        }
        Vector2 mousePos = new Vector2(Input.mousePosition.x,
                                       Input.mousePosition.y);
        //Debug.Log(previousFrameMouseDown);
        cursorPoint = Input.mousePosition;

        if (Input.GetMouseButtonDown(0) && !previousFrameMouseDown)
        {
            RaycastHit checkIfTomato;

            cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(cursorRay, out checkIfTomato, Mathf.Infinity, mask);

            if (checkIfTomato.collider != null)
            {


                if (checkIfTomato.collider.name == "TomatoJoystick")
                {
                    playerAnimator.SetBool("Speed", true);
                    previousMousePosition = mousePos;
                    currentMousePosition = mousePos;
                    previousFrameMouseDown = true;
                    isInTheJoystick = true;
                    isClicked = true;
                }

                else
                {
                    isInTheJoystick = false;
                    isClicked = false;
                    
                }
                
            }
        }

        else if (Input.GetMouseButton(0) && previousFrameMouseDown)
        {
            RaycastHit checkIfTomato;

            cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(cursorRay, out checkIfTomato, Mathf.Infinity, mask);

            if (checkIfTomato.collider != null)
            {


                if (checkIfTomato.collider.name == "TomatoJoystick")
                {
                    isInTheJoystick = true;
                }
                else
                {
                    isInTheJoystick = false;
                }
            }
            else
            {
                isInTheJoystick = false;
            }
                               
            
            isClicked = true;
            playerAnimator.SetBool("Speed", true);
            previousMousePosition = currentMousePosition;
            currentMousePosition = mousePos;
        }

        else if (!Input.GetMouseButton(0))
        {
            previousFrameMouseDown = false;
            isClicked = false;
        }

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 screenPositionXY = new Vector2(screenPosition.x, screenPosition.y);
            Vector2 previousPositionVector = previousMousePosition - screenPositionXY;
            currentPositionVector = currentMousePosition - screenPositionXY;


            if (previousPositionVector != -currentPositionVector && previousFrameMouseDown)
            {
                playerRigidbody.isKinematic = false;
                float rotationAmount = ReturnSignedAngleBetweenVectors(previousPositionVector, currentPositionVector);

                float forceX = currentPositionVector.x;
                float forceZ = currentPositionVector.y;
                //Debug.Log(currentPositionVector);

                if (Mathf.Abs(forceX) > 85.0f)
                {
                    if (forceX < 0)
                    {
                        forceX = -85.0f;
                    }
                    else
                    {
                        forceX = 85.0f;
                    }
                }
                if (Mathf.Abs(forceZ) > 85.0f)
                {
                    if (forceZ < 0)
                    {
                        forceZ = -85.0f;
                    }
                    else
                    {
                        forceZ = 85.0f;
                    }

                }

                directionFacing = new Vector3(forceX, 0.0f, forceZ);
                playerRigidbody.AddForce(directionFacing);
                //Debug.Log(Mathf.Cos(forceX) + "" + Mathf.Sin(forceZ));

                //Debug.Log("ForceX: " + forceX + " ForceZ: " + forceZ);

                playerAnimator.SetBool("Speed", true);
                
            }



            if (Input.GetMouseButtonUp(0))
            {
                playerAnimator.SetBool("Speed", false);
                playerRigidbody.isKinematic = true;
                isClicked = false;

            }


            if (playerRigidbody.velocity.magnitude > maxSpeed)
            {
                try
                {
                    playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxSpeed;
                    
                }
                catch
                {
                }
            }

            player.transform.forward = directionFacing;

            }
        }
    
    private float ReturnSignedAngleBetweenVectors(Vector2 vectorA, Vector2 vectorB)
    {
        Vector3 vector3A = new Vector3(vectorA.x, vectorA.y, 0f);
        Vector3 vector3B = new Vector3(vectorB.x, vectorB.y, 0f);

        if (vector3A == vector3B)
            return 0f;

        // refVector is a 90cw rotation of vector3A
        Vector3 refVector = Vector3.Cross(vector3A, Vector3.forward);
        float dotProduct = Vector3.Dot(refVector, vector3B);

        if (dotProduct > 0)
            return -Vector3.Angle(vector3A, vector3B);
        else if (dotProduct < 0)
            return Vector3.Angle(vector3A, vector3B);
        else
            throw new System.InvalidOperationException("the vectors are opposite");
    }

    void OnGUI()
    {
        if (isInTheJoystick == true && isClicked == true)
        {            
            Vector2 guiPixel = GUIUtility.ScreenToGUIPoint(cursorPoint);
            //Debug.Log(guiPixel);
            GUI.DrawTexture(new Rect(guiPixel.x - 56, (Screen.height - guiPixel.y) - 56, 104, 104), joystickButton, ScaleMode.StretchToFill);
        }
        //Debug.Log(thisTransform.GetComponent<SphereCollider>().bounds.max.x + " " + thisTransform.GetComponent<SphereCollider>().bounds.max.y);

        /*if (isClicked == true)
        {
            Vector2 guiPixel = GUIUtility.ScreenToGUIPoint(cursorPoint);
            if (guiPixel.x > thisTransform.GetComponent<SphereCollider>().bounds.max.x)
            {
                guiPixel.x = thisTransform.GetComponent<SphereCollider>().bounds.max.x;
            }
            if (guiPixel.y > thisTransform.GetComponent<SphereCollider>().bounds.max.y)
            {
                guiPixel.y = thisTransform.GetComponent<SphereCollider>().bounds.max.y;
            }

            //Debug.Log(guiPixel);
            GUI.DrawTexture(new Rect(guiPixel.x - 56, (Screen.height - guiPixel.y) - 56, 104, 104), joystickButton, ScaleMode.StretchToFill);
        }*/

        /*float radius = 80;
        float x = 173;
        float y = 359;       

        for (int i = 0; i < 360; i++)
        {

            float degInRad = i * degToRad;
                                    
            GUI.DrawTexture(new Rect(x + Mathf.Cos(degInRad) * radius, y + Mathf.Sin(degInRad) * radius, 1, 1), joystickButton, ScaleMode.ScaleAndCrop);
            
        }*/
        
        if (isClicked == false)
        {
            Vector2 guiPixel2 = Camera.main.WorldToScreenPoint(thisTransform.position);
            Vector2 guiPixelCenter = GUIUtility.ScreenToGUIPoint(guiPixel2);
            pixelCenterOfJoystick = guiPixelCenter + new Vector2(-56.0f, 56.0f);
            
            //GUI.DrawTexture(new Rect(pixelCenterOfJoystick.x, Screen.height - pixelCenterOfJoystick.y, 104, 104), joystickButton, ScaleMode.StretchToFill);
        }
                
    }
       
   
}
