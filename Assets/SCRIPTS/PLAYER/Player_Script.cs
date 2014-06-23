using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
//Remove this for the product version

public class Player_Script : MonoBehaviour {

	//LIFE
	public int Player_Initial_Life = 100; //Initial amount of life of the player
	public static int Player_Current_Life; //Current amount of life of the player
    public static bool Player_dead; //Controls if the player is dead
    public GameObject shadow;

    public List<Vector3> areaAroundPlayer = new List<Vector3>();
    Animator playerAnimator;

	//GRID VARIABLES
	public static Vector3 Current_Player_Tile_Position; //Checks the actual tile where the player is 

	Transform thisTransform;
    int rnd;
    public bool isDropping = false;


	// Use this for initialization
	void Start () {
		thisTransform = transform;
		Player_Current_Life = Player_Initial_Life;
        playerAnimator = thisTransform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Control which is the tile where the player is

        if (thisTransform.position.y <= 0.0f)
        {
            thisTransform.position = thisTransform.position + new Vector3(0.0f, 0.1f, 0.0f);
        }

		CheckCurrentTile ();
		if(Player_Current_Life <= 0){
            //Invoke("SetGameFinished", 1.5f);
		//Game_Manager.Game_Finished = true;
		}
        FindAreaAround();
		//Debug.Log (Current_Player_Tile_Position);


	}

    void FindAreaAround()
    {
        RaycastHit checkAround;
        Vector3 currentStandingTile = new Vector3(0.0f, 0.0f, 0.0f);
        areaAroundPlayer.Clear();
        Physics.Raycast(thisTransform.position + new Vector3(0.0f, 0.5f, 0.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            currentStandingTile = checkAround.collider.transform.position;
        }
        else
        {
            return;
        }

        Physics.Raycast(currentStandingTile + new Vector3(1.0f, 3.0f, 0.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(2.0f, 3.0f, 0.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(0.0f, 3.0f, 1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(0.0f, 3.0f, 2.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-1.0f, 3.0f, 0.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-2.0f, 3.0f, 0.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(0.0f, 3.0f, -1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(0.0f, 3.0f, -2.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(1.0f, 3.0f, 1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(2.0f, 3.0f, 2.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-1.0f, 3.0f, -1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-2.0f, 3.0f, -2.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(1.0f, 3.0f, -1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(2.0f, 3.0f, -2.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-1.0f, 3.0f, 1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-2.0f, 3.0f, 2.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                areaAroundPlayer.Add(checkAround.collider.transform.position);
            }
        }
        rnd = Random.Range(0, areaAroundPlayer.Count - 1);
    }
	
	void CheckCurrentTile(){
		RaycastHit CheckTile;
		string TileName;
		int XTemp;
		int ZTemp;
		Vector3 TilePosTemp;
		Physics.Raycast (thisTransform.position + new Vector3(0.0f, 0.3f, 0.0f), new Vector3 (0.0f, -0.1f, 0.0f), out CheckTile);
		if (CheckTile.collider != null) {
			TileName = CheckTile.collider.transform.name;
            Debug.Log(CheckTile.collider.transform.position);
			//Just in 
			try{
			XTemp = int.Parse(TileName.Substring(0, 1));
			ZTemp = int.Parse(TileName.Substring(1, 1));
			TilePosTemp = new Vector3((int)XTemp, 0.0f, (int)ZTemp);
			//Current_Player_Tile_Position = TilePosTemp;
            Current_Player_Tile_Position = CheckTile.collider.transform.position;
            if (isDropping == true)
            {
                GameObject shadowPref = (GameObject)GameObject.Instantiate(shadow, Current_Player_Tile_Position, Quaternion.identity);
            }
            //GameObject shadowPref = (GameObject)GameObject.Instantiate(shadow, Current_Player_Tile_Position + new Vector3(0.2f, 0.0f, 0.2f), Quaternion.identity);
            //GameObject shadowPref2 = (GameObject)GameObject.Instantiate(shadow, Current_Player_Tile_Position + new Vector3(-0.2f, 0.0f, -0.2f), Quaternion.identity);
				//Debug.Log (Current_Player_Tile_Position);
			}
			catch{
			}

		}

	}

    public void PlayDeadAnimation()
    {
        playerAnimator.SetTrigger("Dead");
    }

    void SetGameFinished()
    {
        Game_Manager.levelFinished = true;
    }


}
