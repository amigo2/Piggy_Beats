using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
//Remove this for the product version

public class SpawnTiles : MonoBehaviour {

    //Tiles with the notes
    
    public GameObject blueTileNote;
    public GameObject greenTileNote;
    public GameObject orangeTileNote;
    public GameObject purpleTileNote;
    public GameObject redTileNote;
    public GameObject whiteTileNote;
    public GameObject yellowTileNote;

    //PREFABS TO SPWAN
    public GameObject Coin;
    public GameObject Heart;
    public GameObject Boots;
    public GameObject Chest;
    public GameObject CoinsEffect;
      

    public static bool fuckedUpSequence;

    public bool firstCorrect, secondCorrect, thirdCorrect, fourthCorrect;
    public bool firstFuckedUp, secondFuckedUp, thirdFuckedUp, fourthFuckedUp;

    [HideInInspector]
    public string notesCombination;
    
    public int combinationSize = 3;

    public GameObject scenario1, scenario2, scenario3, scenario4, scenario5, scenario6, scenario7;
    int numberOfScenario = 1;
    string nameOfScenario;
    GameObject currentFloor;

    //I should use lists for these...

    [HideInInspector]
    public bool firstPickedUp, secondPickedUp, thirdPickedUp, fourthPickedUp;
     

    [HideInInspector]
    public string firstColor, secondColor, thirdColor, fourthColor;
        
    int x;
    int z;

    [HideInInspector]
    public List<Vector3> PrevPos = new List<Vector3>();

    //SCRIPTS
    Grid_Script gridScript;
    Combinations combScript;
    SpawnEnemies spawnEnemiesScript;
    Game_Manager GMScript;
    Score ScoreScript;
    Player_Script playerScript;

    Animator piggyAnimator;
    Rigidbody piggyRigidbody;


	// Use this for initialization
	void Start () {
        //Debug.Log("This is Spawn Tiles script");  
        //Gets some scripts
        GMScript = (Game_Manager)GameObject.FindGameObjectWithTag("Grid").GetComponent<Game_Manager>();
        gridScript = (Grid_Script)GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid_Script>();
        combScript = (Combinations)GameObject.FindGameObjectWithTag("Grid").GetComponent<Combinations>();
        spawnEnemiesScript = (SpawnEnemies)GameObject.FindGameObjectWithTag("Grid").GetComponent<SpawnEnemies>();
        ScoreScript = (Score)GameObject.FindGameObjectWithTag("Grid").GetComponent<Score>();
        playerScript = (Player_Script)GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();

        SetFuckedUpBoolsToFalse();
        SetBoolsCorrectToDefault();

        notesCombination = combScript.SetRandomCoinCombination(combinationSize); //Sets the combination (at the moment totally random)
        combScript.CheckEachNote(notesCombination, combinationSize); //Checks which color is each one
                
        //SetTiles();
        Invoke("SetTiles", 1.3f);


        currentFloor = GameObject.Find("Scenario1");
        
	}
	
	// Update is called once per frame
	void Update () {
            
            //SetScore();
                
    }

    public void SetFuckedUpBoolsToFalse()
    {
        firstFuckedUp = false;
        secondFuckedUp = false;
        thirdFuckedUp = false;
        fourthFuckedUp = false;
    }

    public void SetBoolsCorrectToDefault()
    {
        firstCorrect = false;
        secondCorrect = false;
        thirdCorrect = false;
        fourthCorrect = false;
    }
   
    public void SetBoolsToFalse()
    {
        firstPickedUp = false;
        secondPickedUp = false;
        thirdPickedUp = false;
        fourthPickedUp = false;
        
    }

    public void NextCombination()
    {
                                      
        if(Game_Manager.levelFinished == false){
                if (fuckedUpSequence == false) //Only if the sequence was picked up correctly
                {
                   
                        SpawnReward(); //Spawn the prize
                   
                    //Score.comboCounter++; //Adds one more to the combos                                  
                    //spawnEnemiesScript.waveNumber++; //Adds one more to the waves
                }

                if (Score.comboCounter == 3 && Game_Manager.levelIsInfinite == false)
                {
                    //SpawnChest();
                    Invoke("SpawnChest", 2.0f);
                }

                fuckedUpSequence = false;
                Score.comboCounter++; //Adds one more to the combos                                  
                spawnEnemiesScript.waveNumber++; //Adds one more to the waves

                PrevPos.Clear();
                DestroyTiles(); //Destroys all the tiles before setting the new ones
                               
                Objects_Hit_Player.ResetPicked();

                //Debug.Log(Game_Manager.levelIsInfinite);
                
                    //Controls if the combos needed has been reached (I shouldn't do it here probably)
                    if (ControlLevelFinished() == true && Game_Manager.levelIsInfinite == false)
                    {
                       
                        GMScript.SetLevelsFinished();
                        GMScript.SetToFinishLevel();
                        ScoreScript.SetScore(); //Controls if the score is better than the best one...
                        
                        return;
                            
                    }
                    //else if (ControlLevelFinished() == true && Game_Manager.levelIsInfinite == true)
                    else if (Game_Manager.levelIsInfinite == true)
                    {
                        //Debug.Log("Yeah yeah");
                        //Debug.Log(Score.comboCounter + " " + Game_Manager.levelIsInfinite);
                        
                        RenewSequencesSpawning();

                        return;

                    }

                    /*else if (GameObject.FindGameObjectWithTag("Player").transform.position.y < 2.0f)
                    {
                        GMScript.SetLevelsFinished();
                        GMScript.SetToFinishLevel();
                        ScoreScript.SetScore(); //Controls if the score is better than the best one...
                    }*/

                   
                        notesCombination = combScript.SetRandomCoinCombination(combinationSize);
                        combScript.CheckEachNote(notesCombination, combinationSize);
                        spawnEnemiesScript.CheckWaves(); //Launches the next wave of enemies
                        Invoke("SetTiles", 2.0f);
                   

                    
                //SetTiles();    
        }     
        
    }

    //This is for infinite mode
    public void RenewSequencesSpawning()
    {        
            //Here I should insert the destroy animation of the grid and spawn the new one    
            piggyAnimator = (Animator)GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            piggyRigidbody = (Rigidbody)GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

            piggyAnimator.SetTrigger("Jumping");
            piggyRigidbody.useGravity = false;

            
            if (spawnEnemiesScript.waveNumber > 4)
            {
                spawnEnemiesScript.waveNumber = 1;
            }

            notesCombination = combScript.SetRandomCoinCombination(combinationSize);
            combScript.CheckEachNote(notesCombination, combinationSize);

            
            //spawnEnemiesScript.CheckWaves(); //Launches the next wave of enemies

            //Move next floor
            try
            {
                /*GameObject floorToDestroy = (GameObject)GameObject.Find("Scenario" + (numberOfScenario - 1));
                Destroy(floorToDestroy.gameObject);*/
                Destroy(currentFloor.gameObject);
            }
            catch
            {

            }

            int randomScenario = Random.Range(1, 8);
            //nameOfScenario = "Scenario" + randomScenario;
            
            switch (randomScenario)
            {
                case 1:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario1, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
                case 2:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario2, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
                case 3:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario3, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
                case 4:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario4, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
                case 5:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario5, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
                case 6:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario6, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
                case 7:
                    currentFloor = (GameObject)GameObject.Instantiate(scenario7, new Vector3(3.0f, -3.0f, 3.0f), Quaternion.identity);
                    break;
            }
        currentFloor.name = "Scenario" + numberOfScenario;
        numberOfScenario++;
        InvokeRepeating("MoveFloor", 0.0f, 0.1f);
    }



    void MoveFloor()
    {
        currentFloor.transform.Translate(new Vector3(0.0f, 0.1f, 0.0f));
        //Debug.Log(floorTwo.transform.position.y);
        playerScript.isDropping = true;

        if (currentFloor.transform.position.y >= 0.0f)
        {
            playerScript.isDropping = false;
            Score.comboCounter = 0;
            currentFloor.transform.position = new Vector3(3.0f, 0.0f, 3.0f);
            piggyRigidbody.useGravity = true;
            spawnEnemiesScript.CheckWaves(); //Launches the next wave of enemies
            piggyAnimator.SetTrigger("Land");
            CancelInvoke();
            Invoke("SetTiles", 3.0f);
        }
        
    }

   

    public void SpawnReward()
    {       

        //Debug.Log(Score.comboCounter);

        if (Score.comboCounter < 3)
        {
            

        launchagain:

            int rndX = Random.Range(0, (int)gridScript.Size.x);
            int rndZ = Random.Range(0, (int)gridScript.Size.z);
            Vector3 placeToSpawn = new Vector3(rndX, 0.0f, rndZ);

            int Rnd = Random.Range(0, 3);
            switch (Rnd)
            {
                case 0:

                    if (spawnEnemiesScript.spawnPlaces.Contains(placeToSpawn))
                    {
                        //Debug.Log(placeToSpawn);
                        GameObject HeartPref = (GameObject)GameObject.Instantiate(Heart, placeToSpawn, Quaternion.identity);
                    }
                    else
                    {
                        goto launchagain;
                    }
                    break;
                case 1:

                    if (spawnEnemiesScript.spawnPlaces.Contains(placeToSpawn))
                    {
                        GameObject BootsPref = (GameObject)GameObject.Instantiate(Boots, placeToSpawn, Quaternion.identity);
                    }
                    else
                    {
                        goto launchagain;
                    }
                    break;
                case 2:
                    if (spawnEnemiesScript.spawnPlaces.Contains(placeToSpawn))
                    {
                        GameObject CoinPref = (GameObject)GameObject.Instantiate(Coin, placeToSpawn, Quaternion.identity);
                        GameObject CoinEffectsPref = (GameObject)GameObject.Instantiate(CoinsEffect, placeToSpawn, Quaternion.identity);
                    }
                    else
                    {
                        goto launchagain;
                    }
                    break;
            }
        }
        
    }

    public void SpawnChest()
    {
        launchagain:

        int rndX = Random.Range(1, (int)gridScript.Size.x - 1);
        int rndZ = Random.Range(1, (int)gridScript.Size.z - 1);
        Vector3 placeToSpawn = new Vector3(rndX, 0.0f, rndZ);

        if (spawnEnemiesScript.spawnPlaces.Contains(placeToSpawn))
        {
            GameObject chestReward = (GameObject)GameObject.Instantiate(Chest, placeToSpawn, Quaternion.identity);
        }
        else
        {
            goto launchagain;
        }

        
    }

    public void DestroyTiles()
    {
        try
        {
            GameObject firstTile = GameObject.Find("1").gameObject;
            firstTile.SendMessage("SetToDestroy");
        }
        catch
        {
        }
        try
        {
            GameObject secondTile = GameObject.Find("2").gameObject;
            secondTile.SendMessage("SetToDestroy");
        }
        catch
        {
        }
        try
        {
            GameObject thirdTile = GameObject.Find("3").gameObject;
            thirdTile.SendMessage("SetToDestroy");
        }
        catch
        {
        }
        try
        {
            GameObject fourthTile = GameObject.Find("4").gameObject;
            fourthTile.SendMessage("SetToDestroy");
        }
        catch
        {
        }                    
        
    }


    public void SetTiles()
    {
        string first = "";
        string second = "";
        string third = "";
        string fourth = "";

        first = notesCombination.Substring(0, 1);
        SetColor(first, "1");
        second = notesCombination.Substring(1, 1);
        SetColor(second, "2");
        third = notesCombination.Substring(2, 1);
        SetColor(third, "3");
        fourth = notesCombination.Substring(3, 1);
        SetColor(fourth, "4");

        Showtile(first, "1");
        Showtile(second, "2");
        Showtile(third, "3");
        Showtile(fourth, "4");
    }

    void SetColor(string color, string position)
    {

        //MUSIC NOTES ENGLISH
        //c --> DO --> Orange
        //d --> RE --> Green
        //e --> MI --> Yellow
        //f --> FA --> blue
        //g --> SOL --> White
        //a --> LA --> Purple
        //b --> SI --> Red

        switch (color)
        {
            case "C":
                switch (position)
                {
                    case "1":
                        firstColor = "Orange";
                        break;
                    case "2":
                        secondColor = "Orange";
                        break;
                    case "3":
                        thirdColor = "Orange";
                        break;
                    case "4":
                        fourthColor = "Orange";
                        break;
                }
                break;
            case "D":
                switch (position)
                {
                    case "1":
                        firstColor = "Green";
                        break;
                    case "2":
                        secondColor = "Green";
                        break;
                    case "3":
                        thirdColor = "Green";
                        break;
                    case "4":
                        fourthColor = "Green";
                        break;
                }
                break;
            case "E":
                switch (position)
                {
                    case "1":
                        firstColor = "Yellow";
                        break;
                    case "2":
                        secondColor = "Yellow";
                        break;
                    case "3":
                        thirdColor = "Yellow";
                        break;
                    case "4":
                        fourthColor = "Yellow";
                        break;
                }
                break;
            case "F":
                switch (position)
                {
                    case "1":
                        firstColor = "Blue";
                        break;
                    case "2":
                        secondColor = "Blue";
                        break;
                    case "3":
                        thirdColor = "Blue";
                        break;
                    case "4":
                        fourthColor = "Blue";
                        break;
                }
                break;
            case "G":
                switch (position)
                {
                    case "1":
                        firstColor = "White";
                        break;
                    case "2":
                        secondColor = "White";
                        break;
                    case "3":
                        thirdColor = "White";
                        break;
                    case "4":
                        fourthColor = "White";
                        break;
                }
                break;
            case "A":
                switch (position)
                {
                    case "1":
                        firstColor = "Purple";
                        break;
                    case "2":
                        secondColor = "Purple";
                        break;
                    case "3":
                        thirdColor = "Purple";
                        break;
                    case "4":
                        fourthColor = "Purple";
                        break;
                }
                break;
            case "B":
                switch (position)
                {
                    case "1":
                        firstColor = "Red";
                        break;
                    case "2":
                        secondColor = "Red";
                        break;
                    case "3":
                        thirdColor = "Red";
                        break;
                    case "4":
                        fourthColor = "Red";
                        break;
                }
                break;
        }
    }
    
    
    void Showtile(string colorTileToShow, string positionName)
    {
        //MUSIC NOTES ENGLISH
        //c --> DO --> Black
        //d --> RE --> Green
        //e --> MI --> Yellow
        //f --> FA --> blue
        //g --> SOL --> White
        //a --> LA --> Purple
        //b --> SI --> Red

        re_random: //Controls it doesn't spawn the tiles in the player position

        int x = Random.Range(0, (int)gridScript.Size.x);
        int z = Random.Range(0, (int)gridScript.Size.z);

        Vector3 nextPos = new Vector3((int)x, 0.0f, (int)z);
        for (int i = 0; i < PrevPos.Count; i++)
        {
            if (nextPos == PrevPos[i] || nextPos == Player_Script.Current_Player_Tile_Position)
            {
                goto re_random;
            }
            
            
        }

        PrevPos.Add(nextPos);
        //Debug.Log(spawnEnemiesScript.spawnPlaces.Count);
        if (spawnEnemiesScript.spawnPlaces.Contains(nextPos))
        {
        
            switch (colorTileToShow)
            {
                case "C":
                    GameObject orangeTile = (GameObject)GameObject.Instantiate(orangeTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    orangeTile.transform.name = positionName;
                    TileNotesScript TileScript = (TileNotesScript)orangeTile.GetComponent<TileNotesScript>();
                    TileScript.colorTile = "Orange";
                    break;
                case "D":
                    GameObject greenTile = (GameObject)GameObject.Instantiate(greenTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    greenTile.transform.name = positionName;
                    TileNotesScript TileScript1 = (TileNotesScript)greenTile.GetComponent<TileNotesScript>();
                    TileScript1.colorTile = "Green";
                    break;
                case "E":
                    GameObject yellowTile = (GameObject)GameObject.Instantiate(yellowTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    yellowTile.transform.name = positionName;
                    TileNotesScript TileScript2 = (TileNotesScript)yellowTile.GetComponent<TileNotesScript>();
                    TileScript2.colorTile = "Yellow";
                    break;
                case "F":
                    GameObject blueTile = (GameObject)GameObject.Instantiate(blueTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    blueTile.transform.name = positionName;
                    TileNotesScript TileScript3 = (TileNotesScript)blueTile.GetComponent<TileNotesScript>();
                    TileScript3.colorTile = "Blue";
                    break;
                case "G":
                    GameObject whiteTile = (GameObject)GameObject.Instantiate(whiteTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    whiteTile.transform.name = positionName;
                    TileNotesScript TileScript4 = (TileNotesScript)whiteTile.GetComponent<TileNotesScript>();
                    TileScript4.colorTile = "White";
                    break;
                case "A":
                    GameObject purpleTile = (GameObject)GameObject.Instantiate(purpleTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    purpleTile.transform.name = positionName;
                    TileNotesScript TileScript5 = (TileNotesScript)purpleTile.GetComponent<TileNotesScript>();
                    TileScript5.colorTile = "Purple";
                    break;
                case "B":
                    GameObject redTile = (GameObject)GameObject.Instantiate(redTileNote, nextPos, Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f)));
                    redTile.transform.name = positionName;
                    TileNotesScript TileScript6 = (TileNotesScript)redTile.GetComponent<TileNotesScript>();
                    TileScript6.colorTile = "Red";
                    break;
            }
        }
        else
        {
            goto re_random;
        }
    }

    bool ControlLevelFinished()
    {
        bool finished = false;
        if (Score.comboCounter == Sequences.numberOfSequences)
        {
            if (Game_Manager.levelIsInfinite == false)
            {
                //GMScript.SetToFinishLevel();
                
            }
            finished = true;
        }
        return finished;
    }

    
   

}
