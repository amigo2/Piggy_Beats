using UnityEngine;
using System.Collections;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
//Remove this for the product version

public class TileNotesScript : MonoBehaviour {

    Transform thisTransform;
    string tilePosName;
    Animator tileAnimator;


    public string colorTile;

    public bool pickedUpCorrectly;
    public bool stepedOnAlready;
        
    SpawnTiles SpawnScript;
    SoundScript soundScript;
    Score scoreScript;

    int scoreCheck; 

    public Material greyMat;

    public GameObject score100;
    public GameObject score200;

    [HideInInspector]
    public string nextToPickUp = "";

	// Use this for initialization
	void Start () {
        scoreCheck = PlayerPrefs.GetInt("HighScore");

        thisTransform = transform;
        tilePosName = thisTransform.name;
        SpawnScript = (SpawnTiles)GameObject.FindGameObjectWithTag("Grid").GetComponent<SpawnTiles>();
        soundScript = (SoundScript)GameObject.FindGameObjectWithTag("Grid").GetComponent<SoundScript>();
        scoreScript = (Score)GameObject.FindGameObjectWithTag("Grid").GetComponent<Score>();

        //tileAnimator = thisTransform.GetChild(0).GetComponent<Animator>();
        tileAnimator = thisTransform.GetComponent<Animator>();
        
        Invoke("SetColliderReady", 1.0f); //I enable the collider a bit after the beginning

        //Debug.Log(SpawnScript.notesCombination);
	}
	
	// Update is called once per frame
	void Update () {
        //SetHighScore();
              
	}

   
    void SetRelunchTiles()
    {
        SpawnScript.SetBoolsToFalse();
        SpawnScript.SetFuckedUpBoolsToFalse();
        SpawnScript.SetBoolsCorrectToDefault();
        pickedUpCorrectly = false;
        stepedOnAlready = false;
        SpawnScript.NextCombination();
        
    }
        

    void GetNextToPickUp()
    {
        if (SpawnScript.firstPickedUp == false)
        {
            nextToPickUp = "1";
        }
        else if (SpawnScript.firstPickedUp == true
            && SpawnScript.secondPickedUp == false)
        {
            nextToPickUp = "2";
        }
        else if (SpawnScript.firstPickedUp == true
            && SpawnScript.secondPickedUp == true
            && SpawnScript.thirdPickedUp == false)
        {
            nextToPickUp = "3";
        }
        else if (SpawnScript.firstPickedUp == true
            && SpawnScript.secondPickedUp == true
            && SpawnScript.thirdPickedUp == true
            && SpawnScript.fourthPickedUp == false)
        {
            nextToPickUp = "4";
        }
    }

    bool CheckPickedUp(string colorTile)
    {
        
        
        bool rightOne = false;

                       
            switch (nextToPickUp)
            {
                case "1":
                    if (colorTile == SpawnScript.firstColor)
                    {
                        //Objects_Hit_Player.firstPickedUP = true; //It's the variable that I use to change the UI but should be change
                        SpawnScript.firstCorrect = true;
                        rightOne = true;
                    }
                   

                    break;
                case "2":
                    if (colorTile == SpawnScript.secondColor)
                    {
                        //Objects_Hit_Player.secondPickedUP = true;
                        SpawnScript.secondCorrect = true;
                        rightOne = true;
                    }
                    
                    
                    break;
                case "3":
                    if (colorTile == SpawnScript.thirdColor)
                    {
                        //Objects_Hit_Player.thirdPickedUP = true;
                        SpawnScript.thirdCorrect = true;
                        rightOne = true;
                    }
                    
                    break;
                case "4":
                    if (colorTile == SpawnScript.fourthColor)
                    {
                        //Objects_Hit_Player.fourthPickedUP = true;
                        SpawnScript.fourthCorrect = true;
                        rightOne = true;
                    }
                    
                    break;
            
        }
        
        return rightOne;
    }

    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.collider.transform.tag != "Player")
        {
            return;
        }

        if (stepedOnAlready == true)
        {
            return;
        }

        thisTransform.GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f);

        GetNextToPickUp(); //Gets the next one to pick up

        if (SpawnTiles.fuckedUpSequence == false)
        {
            switch (colorTile)
            {
                case "Orange":

                    if (CheckPickedUp("Orange") == true)
                    {
                       pickedUpCorrectly = true;
                    }
                    else
                    {
                       TurnToGrey(); //Should I do it here?
                       SetToGreyTheRest();
                       SpawnTiles.fuckedUpSequence = true;
                    }
                    break;
                case "Green":

                    if (CheckPickedUp("Green") == true)
                    {
                        pickedUpCorrectly = true;
                    }
                    else
                    {
                        TurnToGrey(); //Should I do it here?
                        SetToGreyTheRest();
                        SpawnTiles.fuckedUpSequence = true;
                        
                    }
                    break;
                case "Yellow":

                    if (CheckPickedUp("Yellow") == true)
                    {
                        pickedUpCorrectly = true;
                    }
                    else
                    {
                        TurnToGrey(); //Should I do it here?
                        SetToGreyTheRest();
                        SpawnTiles.fuckedUpSequence = true;
                        
                    }
                    break;
                case "Blue":

                    if (CheckPickedUp("Blue") == true)
                    {
                       pickedUpCorrectly = true;
                    }
                    else
                    {
                        TurnToGrey(); //Should I do it here?
                        SetToGreyTheRest();
                       SpawnTiles.fuckedUpSequence = true;
                       
                    }
                    break;
                case "White":

                    if (CheckPickedUp("White") == true)
                    {
                       pickedUpCorrectly = true;
                    }
                    else
                    {
                        TurnToGrey(); //Should I do it here?
                        SetToGreyTheRest();
                        SpawnTiles.fuckedUpSequence = true;
                        
                    }
                    break;
                case "Purple":

                    if (CheckPickedUp("Purple") == true)
                    {
                       pickedUpCorrectly = true;
                    }
                    else
                    {
                        TurnToGrey(); //Should I do it here?
                        SetToGreyTheRest();
                        SpawnTiles.fuckedUpSequence = true;
                        
                    }
                    break;
                case "Red":

                    if (CheckPickedUp("Red") == true)
                    {
                        pickedUpCorrectly = true;
                    }
                    else
                    {
                        TurnToGrey(); //Should I do it here?
                        SetToGreyTheRest();
                        SpawnTiles.fuckedUpSequence = true;
                    }
                    break;
            }
        }
            PlaySoundAndParticle(); //Plays sound and particle...
            ShowGettingScore(); //Shows the score animation controlling if the sequence is fucked up or not already         
            SetNextPickedUp();
            tileAnimator.SetTrigger("StepOn"); //Triggers animation of stepped on
            

            stepedOnAlready = true; //Just in case we would like to use the collider for something else without disabling it
            thisTransform.collider.enabled = false; //Disables the collider

            /*if (pickedUpCorrectly == false)
            {
                tileAnimator.SetBool("Done", true);
            }*/        
        

            //It's not so clear but just for trying
            /*if (SpawnScript.fourthPickedUp == true && Game_Manager.levelFinished == false)
            {
                Invoke("SetRelunchTiles", 1.0f);
                //SetRelunchTiles();

            }*/

            if (SpawnScript.fourthPickedUp == true)
            {
                //Debug.Log(Score.comboCounter);
                Invoke("SetRelunchTiles", 1.0f);
                //SetRelunchTiles();

            }
    }

    void SetNextPickedUp()
    {
        bool picked = false;
        switch (nextToPickUp)
        {
            case "1":
                SpawnScript.firstPickedUp = true;
                break;
            case "2":
                SpawnScript.secondPickedUp = true;
                break;
            case "3":
                SpawnScript.thirdPickedUp = true;
                break;
            case "4":
                SpawnScript.fourthPickedUp = true;
                break;
        }     
    }

    void ShowGettingScore()
    {
        if (SpawnTiles.fuckedUpSequence == true)
        {
            GameObject score100Pref = (GameObject)GameObject.Instantiate(score100, thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
            //Add the score
            scoreScript.AddScore(100);
        }
        else
        {
            GameObject score200Pref = (GameObject)GameObject.Instantiate(score200, thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
            scoreScript.AddScore(220);
        }
    }

    void TurnToGrey()
    {
        //Debug.Log("Yeah I'm here");
		for (int i = 1; i <= SpawnScript.combinationSize + 1; i++) {
			try
			{
				bool isCorrect = GameObject.Find(i.ToString()).GetComponent<TileNotesScript>().pickedUpCorrectly;
				if(isCorrect == false){
                    try
                    {
                        GameObject tilePref = GameObject.Find(i.ToString());
                        //tilePref.transform.GetChild(0).transform.renderer.material = greyMat;
                        //colorTile = "Grey"; //To control that is fucked up
                        Animator tileAnim = tilePref.GetComponent<Animator>();
                        tileAnim.SetTrigger("GoSilver");
                        
                    }
                    catch
                    {
                    }
					
				}
			}
			catch{
			}

		}
   }

    void SetToGreyTheRest()
    {
        if (SpawnScript.firstCorrect == false)
        {
            SpawnScript.firstFuckedUp = true;
        }
        if (SpawnScript.secondCorrect == false)
        {
            SpawnScript.secondFuckedUp = true;
        }
        if (SpawnScript.thirdCorrect == false)
        {
            SpawnScript.thirdFuckedUp = true;
        }
        if (SpawnScript.fourthCorrect == false)
        {
            SpawnScript.fourthFuckedUp = true;
        }
    }
        

    void PlaySoundAndParticle()
    {
        try
        {
            soundScript.PlaySoundNote((int)thisTransform.position.z);
            Debug.Log(thisTransform.position.z);
        }
        catch
        {

        }
        try
        {
            soundScript.ShowParticle(colorTile, thisTransform.position);
        }
        catch
        {

        }
    }

   

    void SetToDestroy()
    {
        tileAnimator.SetTrigger("Destroyed");
        Invoke("AutoDestroy", 1.0f);
    }
        
    void AutoDestroy()
    {
        Destroy(thisTransform.gameObject);
    }

    void SetColliderReady()
    {
        thisTransform.collider.enabled = true;
    }

    

}
