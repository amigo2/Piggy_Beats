using UnityEngine;
using System.Collections;

public class ClickAndMove : MonoBehaviour
{

        bool activateThisMovement;

		private Transform myTransform;				// this transform
		private Vector3 destinationPosition;		// The destination Point
		private float destinationDistance;			// The distance between myTransform and destinationPosition
		
		public float moveSpeed;						// The Speed the character will move
		
		Animator CharAnimator;

		public static bool playerCannotMove = false;
		
		public bool notClickToMove;
		
		public bool BootsOn = false;
		
		public static bool StopMoving;
        Rigidbody playerRigidbody;

        UI_Script guiScript;
        
		void Start () {
			myTransform = transform;							// sets myTransform to this GameObject.transform
			destinationPosition = myTransform.position;		
			CharAnimator = transform.GetComponent<Animator>();
            playerRigidbody = myTransform.GetComponent<Rigidbody>();
            guiScript = (UI_Script)Camera.main.transform.GetComponent<UI_Script>();
		}

			
		
		void Update () {
            if (Game_Manager.moveAndSpawn == true)
            {

                if (guiScript.showScore == true)
                {
                    CharAnimator.SetBool("Speed", false);
                    return;
                }

                // keep track of the distance between this gameObject and destinationPosition
                destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

                if (destinationDistance <= 0.0f)
                {		// To prevent shakin behavior when near destination (before 0.5f)
                    moveSpeed = 0;
                }
                else if (destinationDistance > .5f)
                {			// To Reset Speed to default
                    moveSpeed = 3;
                }


                // Moves the Player if the Left Mouse Button was clicked


                if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0)
                {
                    //Control here that if the click is out of the grid don't move

                    //CharAnimator.SetFloat("Speed", 0.2f); 
                    CharAnimator.SetBool("Speed", true);
                    Plane playerPlane = new Plane(Vector3.up, myTransform.position);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float hitdist = 0.0f;

                    if (playerPlane.Raycast(ray, out hitdist))
                    {
                        Vector3 targetPoint = ray.GetPoint(hitdist);


                        Quaternion targetRotation = Quaternion.LookRotation(-(-targetPoint + transform.position));
                        Quaternion rotationFix = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
                        myTransform.rotation = targetRotation;
                        //myTransform.rotation = rotationFix;
                        destinationPosition = ray.GetPoint(hitdist);


                    }
                }



                // Moves the player if the mouse button is hold down
                if (Input.GetMouseButton(0) && GUIUtility.hotControl == 0)
                {


                    //CharAnimator.SetFloat("Speed", 0.2f); 
                    CharAnimator.SetBool("Speed", true);

                    Plane playerPlane = new Plane(Vector3.up, myTransform.position);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float hitdist = 0.0f;

                    if (playerPlane.Raycast(ray, out hitdist))
                    {
                        Vector3 targetPoint = ray.GetPoint(hitdist);
                        destinationPosition = ray.GetPoint(hitdist);
                        Quaternion targetRotation = Quaternion.LookRotation(-(-targetPoint + transform.position));
                        Quaternion rotationFix = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
                        myTransform.rotation = targetRotation;
                        //myTransform.rotation = rotationFix;
                    }

                }

                if (BootsOn == true)
                {
                    moveSpeed = 5.0f;
                }
                else
                {
                    moveSpeed = 4.0f;
                }

                myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, Time.deltaTime * moveSpeed);

                if (myTransform.position == destinationPosition)
                {
                    //CharAnimator.SetFloat("Speed", 0.0f); //Idle Animation activated
                    CharAnimator.SetBool("Speed", false);
                }


                //myTransform.forward = playerRigidbody.velocity;
            }
		}
  }
		
