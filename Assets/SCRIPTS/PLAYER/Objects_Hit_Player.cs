using UnityEngine;
using System.Collections;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
//Remove this for the product version

public class Objects_Hit_Player : MonoBehaviour {

	//This script is attached to the player 
	//controls what to do when the objects hit it
	
	Transform thisTransform;
	GameObject DroppedObject;
       
    public GameObject smoke;

	//Scripts
    ClickAndMove MoveScript;
    Score scoreScript;
    SuperJoystick JoystickScript;
		
	//Sounds
	public AudioClip CoinSound;
	public AudioClip ChestSound;
    public AudioClip PigHit;
    

	//Animators
	Animator CharAnimator;
	Animator DroppedObjectAnimator;
	
	Rigidbody DroppedObjectPhysics;
	
	//Gameobjects Effects
	//MUSIC NOTES ENGLISH
	//c --> DO --> Black
	//d --> RE --> Green
	//e --> MI --> Yellow
	//f --> FA --> blue
	//g --> SOL --> White
	//a --> LA --> Purple
	//b --> SI --> Red
	
	public GameObject hitEffect;
	
	
	//Combinations script
	Combinations combScript;
	public static bool firstPickedUP = false;
	public static bool secondPickedUP = false;
	public static bool thirdPickedUP = false;
	public static bool fourthPickedUP = false; 
	public static bool notesChecked = false;
	

    //Effects particles
    GameObject healParticle;
    GameObject speedParticle;
    

    //Scores prefabs
    public GameObject score100;
    public GameObject score200;

	// Use this for initialization
	void Start () 
	{
		thisTransform = transform;
        healParticle = thisTransform.FindChild("PiggyEffects").transform.FindChild("LE_Healing").transform.gameObject;
        speedParticle = thisTransform.FindChild("PiggyEffects").transform.FindChild("LE_SpeedUp").transform.gameObject;
        
        CharAnimator = thisTransform.GetComponent<Animator>();
		combScript = (Combinations)GameObject.FindGameObjectWithTag("Grid").GetComponent<Combinations>();
		
        scoreScript = (Score)GameObject.FindGameObjectWithTag("Grid").GetComponent<Score>();
        
		}
	
	// Update is called once per frame
	void Update () 
	{
        
		
	}

    void OnCollisionEnter(Collision Other)
    {
       
        if (Other.collider != null)
        {
            DroppedObject = Other.collider.gameObject;
            
        }

        //Gets the animator component of the object
        DroppedObjectAnimator = DroppedObject.transform.GetComponent<Animator>();
        DroppedObjectPhysics = DroppedObject.transform.GetComponent<Rigidbody>();

        switch (DroppedObject.transform.tag)
        {
            case "Barrel":
                DroppedObjectPhysics.isKinematic = true; //I disable the physics to make it not to bounce 			
                if (Other.collider.transform.position.y >= 0.5)
                {
                    //Player loses life
                    if (Player_Script.Player_Current_Life > 0)
                    {
                        Player_Script.Player_Current_Life -= 25;

                    }

                    GameObject HitEffect = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                    
                    CharAnimator.SetTrigger("Hit");
                    DroppedObjectAnimator.SetTrigger("HitPlayer");

                    AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);

                }
                Invoke("DestroyObject", 0.5f);
                					
                break;
            case "Bird":
                DroppedObjectPhysics.isKinematic = true; //I disable the physics to make it not to bounce
                if (Other.collider.transform.position.y >= 0.5)
                {
                    if (Player_Script.Player_Current_Life > 0)
                    {
                        Player_Script.Player_Current_Life -= 25;

                    }
                    GameObject HitEffect = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                   
                    CharAnimator.SetTrigger("Hit");
                    DroppedObjectAnimator.SetTrigger("HitPlayer");
                    try
                    {
                        DroppedObject.GetComponent<SphereCollider>().enabled = false;
                    }
                    catch
                    {
                    }

                    AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);

                }
                
                Invoke("DestroyObject", 0.1f);
                break;
            case "Tomato":
                DroppedObjectPhysics.isKinematic = true; //I disable the physics to make it not to bounce
                if (Other.collider.transform.position.y >= 0.5)
                {
                    if (Player_Script.Player_Current_Life > 0)
                    {
                        Player_Script.Player_Current_Life -= 25;

                    }
                    GameObject HitEffect = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                   
                    CharAnimator.SetTrigger("Hit");
                    DroppedObjectAnimator.SetTrigger("HitPlayer");

                    AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                }
                                
                Invoke("DestroyObject", 0.5f);
                break;
            case "BeeHive":
                DroppedObjectPhysics.isKinematic = true; //I disable the physics to make it not to bounce
                if (Other.collider.transform.position.y >= 0.5)
                {
                    if (Player_Script.Player_Current_Life > 0)
                    {
                        Player_Script.Player_Current_Life -= 25;

                    }
                    GameObject HitEffect = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                    
                    CharAnimator.SetTrigger("Hit");
                    DroppedObjectAnimator.SetTrigger("HitPlayer");

                    AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                }
                //StartCoroutine("DestroyObject");
                
                Invoke("DestroyObject", 0.5f);
                break;
            
            case "Wolf":
                //thisTransform.GetComponent<Movement_Script_Click>().enabled = false; //Disable the movement script
                //Invoke("EnableMovement", 1.0f);
                CharAnimator.SetTrigger("Hit");
                DroppedObjectAnimator.SetTrigger("Destroy");
                //Invoke("DestroyObject", 1.5f);
                Destroy(DroppedObject.gameObject);
                if (Player_Script.Player_Current_Life > 0)
                    {
                        Player_Script.Player_Current_Life -= 25;

                    }
                GameObject HitEffect2 = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
                AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                    
                break;
            case "Zombie":
                
                CharAnimator.SetTrigger("Hit");
                //DroppedObjectAnimator.SetTrigger("Destroy");
                if (Player_Script.Player_Current_Life > 0)
                {
                    Player_Script.Player_Current_Life -= 25;

                }
                GameObject HitEffect3 = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
                AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                //Invoke("DestroyObject", 0.5f);
                Destroy(DroppedObject.gameObject);
                break;
            case "Hedgehog":

                CharAnimator.SetTrigger("Hit");
                //DroppedObjectAnimator.SetTrigger("Destroy");
                if (Player_Script.Player_Current_Life > 0)
                {
                    Player_Script.Player_Current_Life -= 25;

                }
                GameObject HitEffect4 = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
                AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                //Invoke("DestroyObject", 0.5f);
                Destroy(DroppedObject.gameObject);
                break;
        }
    }
			
			
	
	void DestroyObject(){
        
		try{
            Debug.Log(DroppedObject.transform.tag);
			Destroy (DroppedObject.gameObject);
		}catch{
	
		}
	}
      
	
	void ResetBoots(){
        try
        {
            MoveScript.BootsOn = false;
        }
        catch
        {
        }
        try
        {
            JoystickScript.BootsOn = false;
        }
        catch
        {
        }
	}
		

    void ResetHeal()
    {
        healParticle.SetActive(false);
    }

    void ResetSpeed()
    {
        speedParticle.SetActive(false);
    }
        
        
    public static void ResetPicked()
    {
        firstPickedUP = false;
        secondPickedUP = false;
        thirdPickedUP = false;
        fourthPickedUP = false;
    }

    void EnableMovement()
    {
        //thisTransform.GetComponent<Movement_Script_Click>().enabled = true;
    }

		
}
