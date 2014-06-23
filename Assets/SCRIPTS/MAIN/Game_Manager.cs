using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {

    public static string currentLevel; //Stores the current level that we are playing
    string currentTemp;
    public int maxTimePerSequence; //Max time to finish the sequence   

    public int numberOfCombosNeeded; //Number of combos we need to pass the level

    public static bool sceneChanged;
    public static bool levelFinished = false;

    bool alreadySet = false;
    public static bool moveAndSpawn = false;
    public static bool levelIsInfinite = false;

    Sequences SeqScript;
    SpawnEnemies spawnEnemiesScript;
    UI_Script guiScript;
    Player_Script playerScript;

    void OnAwake()
    {
        levelFinished = false;
        levelIsInfinite = false;
        
    }

	// Use this for initialization
	void Start () {
        levelIsInfinite = false;

        CheckScene();
        alreadySet = false;
        sceneChanged = false;
        levelFinished = false;
        
        currentTemp = currentLevel;
        moveAndSpawn = false;

        //Just for testing Score
        //Invoke("SetToFinishLevelForTesting", 0.5f);
        //////////////////
              

        spawnEnemiesScript = (SpawnEnemies)GameObject.FindGameObjectWithTag("Grid").GetComponent<SpawnEnemies>();
        spawnEnemiesScript.waveNumber = 1;
        playerScript = (Player_Script) GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
        guiScript = (UI_Script) Camera.main.transform.GetComponent<UI_Script>();
        guiScript.PlayStartAnimation();
        Invoke("SetMoveAndSpawn", 1.5f);
        Score.comboCounter = 0;
        SpawnTiles.fuckedUpSequence = false;

        //SeqScript = (Sequences)GameObject.FindGameObjectWithTag("Grid").GetComponent<Sequences>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Player_Script.Player_Current_Life <= 0 && alreadySet == false)
        {
            alreadySet = true;
            playerScript.PlayDeadAnimation();
            moveAndSpawn = false;
            //Invoke("SetToFinishLevel", 1.30f);
            //SetToFinishLevel();
            SetToFinishLevelPiggyDead();
        }
        
	}

    public void CheckScene()
    {
        currentLevel = Application.loadedLevelName;
        //Debug.Log(currentLevel);
        switch (currentLevel)
        {
            case "LEVEL_1":
                Sequences.numberOfSequences = 4;
                Sequences.numberOfNotes = 4;
                break;
            case "LEVEL_2":
                Sequences.numberOfSequences = 4;
                Sequences.numberOfNotes = 4;
                break;
            case "LEVEL_3":
                Sequences.numberOfSequences = 4;
                Sequences.numberOfNotes = 4;
                break;
            case "LEVEL_4":
                Sequences.numberOfSequences = 4;
                Sequences.numberOfNotes = 4;
                break;
            case "FIRST_WORLD_INFINITE": //Infinite first world
                levelIsInfinite = true;
                Sequences.numberOfSequences = 4;
                Sequences.numberOfNotes = 4;
                break;
                
        }
        //Debug.Log(currentLevel);
        //Debug.Log(levelIsInfinite);
        //Debug.Log(Sequences.numberOfSequences);
    }
       

    public static void LoadNextLevel()
    {
        levelFinished = false;  
        switch (currentLevel)
        {
            case "LEVEL_1":
                Application.LoadLevel("LEVEL_2");
                break;
            case "LEVEL_2":
                Application.LoadLevel("LEVEL_3");
                break;
            case "LEVEL_3":
                Application.LoadLevel("LEVEL_4");
                break;
            case "LEVEL_4":
                Application.LoadLevel("FIRST_WORLD_INFINITE");
                break;
            case "FIRST_WORLD_INFINITE":
                Application.LoadLevel("LEVEL_MAP");
                break;
            
        }
        
    }

    void CheckChangedScene()
    {
        sceneChanged = false;
        CheckScene();
        currentTemp = currentLevel;
    }

    public void SetLevelsFinished()
    {
        switch (currentLevel)
        {
            case "LEVEL_1":
                PlayerPrefs.SetInt("Level1Done", 1);
                break;
            case "LEVEL_2":
                PlayerPrefs.SetInt("Level2Done", 1);
                break;
            case "LEVEL_3":
                PlayerPrefs.SetInt("Level3Done", 1);
                break;
            case "LEVEL_4":
                PlayerPrefs.SetInt("Level4Done", 1);
                break;
            case "LEVEL_5":
                PlayerPrefs.SetInt("Level5Done", 1);
                break;
            case "LEVEL_INFINITE":

                break;

        }
    }

    

    public void SetToFinishLevel()
    {
        
        Invoke("FinishLevel", 0.0f);
        Invoke("ShowFinishAnimation", 9.5f);
        Invoke("setToShowScore", 11.5f);
        StartCoroutine(WaitToFinish());
    }

    public void SetToFinishLevelPiggyDead()
    {

        Invoke("FinishLevel", 1.0f);
        Invoke("ShowFinishAnimation", 3.0f);
        Invoke("setToShowScore", 5.0f);
        StartCoroutine(WaitToFinish());
    }

    public void SetToFinishLevelForTesting()
    {

        Invoke("FinishLevel", 0.0f);
        Invoke("ShowFinishAnimation", 1.0f);
        Invoke("setToShowScore", 1.5f);
        StartCoroutine(WaitToFinish());
    }

    public void SetMoveAndSpawn()
    {
        moveAndSpawn = true;
    }

    IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(1.6f);
    }

    void FinishLevel()
    {
        levelFinished = true;
    }

    void ShowFinishAnimation()
    {
        guiScript.PlayFinishAnimation();
    }

    void setToShowScore()
    {
        guiScript.showScore = true;
        
                
    }
}
