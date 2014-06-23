using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {
           

    bool spawnedAlready = false;


    //VARIABLES EDITING WAVES

    //public int enemiesNumber;
    //public int enemyType; //0 just runner, 1 just chaser, 2 both
    //public int numberOfCombos;

        
    public int waveNumber;

    EnemyList enemyListScript;
    Grid_Script GScript;
    Player_Script playerScript;

    public List<Vector3> spawnPlaces = new List<Vector3>();
    List<Vector3> spawnedPlace = new List<Vector3>();

    public int numberOfWaves = 4;
    string firstWave = "";
    string secondWave = "";
    string thirdWave = "";
    string fourthWave = "";

    Vector3 checkLastSpawned;

    public float heightSpawnWolf = 0.5f;


    public Wave1FirstEnemyType wave1FirstEnemyType;
    public enum Wave1FirstEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    }
    public int wave1FirstEnemyNumber;
    
    public Wave1SecondEnemyType wave1SecondEnemyType;
    public enum Wave1SecondEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    }
    public int wave1SecondEnemyNumber;
    
    public Wave2FirstEnemyType wave2FirstEnemyType;
    public enum Wave2FirstEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    };
    public int wave2FirstEnemyNumber;
   
    public Wave2SecondEnemyType wave2SecondEnemyType;
    public enum Wave2SecondEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    }
    public int wave2SecondEnemyNumber;
   
    public Wave3FirstEnemyType wave3FirstEnemyType;
    public enum Wave3FirstEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    };
    public int wave3FirstEnemyNumber;
   
    public Wave3SecondEnemyType wave3SecondEnemyType;
    public enum Wave3SecondEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    };
    public int wave3SecondEnemyNumber;
    
    public Wave4FirstEnemyType wave4FirstEnemyType;
    public enum Wave4FirstEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    };
    public int wave4FirstEnemyNumber;
    
    public Wave4SecondEnemyType wave4SecondEnemyType;
    public enum Wave4SecondEnemyType
    {
        E001,
        E002,
        E003,
        NONE
    };
    public int wave4SecondEnemyNumber;
    

	// Use this for initialization
	void Start () {
        enemyListScript = (EnemyList)GameObject.FindGameObjectWithTag("Grid").GetComponent<EnemyList>();
        GScript = (Grid_Script)GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid_Script>();
        playerScript = (Player_Script)GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();

        spawnPlaces.Clear();
        spawnedPlace.Clear();

        //CheckTilesAvailable();
        Invoke("CheckTilesAvailable", 0.1f);
        
        
        waveNumber = 1;
        Invoke("CheckWaves", 1.3f);
        //CheckWaves();       
        //Debug.Log("This is Spawn Enemies script");       
	}

    // Update is called once per frame
    void Update()
    {
        
        
	}

    void SpawnSelect()
    {
        switch (Game_Manager.currentLevel)
        {
            case "LEVEL_1":
               
                break;
            case "LEVEL_2":
                
                break;
            case "LEVEL_3":
                
                break;
            case "LEVEL_4":
                
                break;
            case "LEVEL_5":

                break;
        }
    }
        

    public void CheckWaves()
    {
        CheckTilesAvailable();
        switch (waveNumber)
        {
                    case 1:
                     switch (wave1FirstEnemyType)
                        {
                            case Wave1FirstEnemyType.E001:
                                SpawnWave("E001", wave1FirstEnemyNumber);
                                firstWave = "WAVE 1: 1 E001";
                                break;
                            case Wave1FirstEnemyType.E002:
                                SpawnWave("E002", wave1FirstEnemyNumber);
                                firstWave = "WAVE 1: 1 E002";
                                break;
                        }
                        
                                 
                
                        switch (wave1SecondEnemyType)
                        {
                            case Wave1SecondEnemyType.E001:
                                SpawnWave("E001", wave1SecondEnemyNumber);
                                firstWave = firstWave + " + 1 E001";
                                break;
                            case Wave1SecondEnemyType.E002:
                                SpawnWave("E002", wave1SecondEnemyNumber);
                                firstWave = firstWave + " + 1 E002";
                                break;
                        }
                        break;
                   
            case 2:
                        switch (wave2FirstEnemyType)
                        {
                            case Wave2FirstEnemyType.E001:
                                SpawnWave("E001", wave2FirstEnemyNumber);
                                secondWave = "WAVE 2: 1 E001";
                                break;
                            case Wave2FirstEnemyType.E002:
                                SpawnWave("E002", wave2FirstEnemyNumber);
                                secondWave = "WAVE 2: 1 E002";
                                break;
                        }
                               
                        switch (wave2SecondEnemyType)
                        {
                            case Wave2SecondEnemyType.E001:
                                SpawnWave("E001", wave2SecondEnemyNumber);
                                secondWave = secondWave + " + 1 E001";
                                break;
                            case Wave2SecondEnemyType.E002:
                                SpawnWave("E002", wave2SecondEnemyNumber);
                                secondWave = secondWave + " + 1 E002";
                                break;
                        }
                        break;
            case 3:
                
                        switch (wave3FirstEnemyType)
                        {
                            case Wave3FirstEnemyType.E001:
                                SpawnWave("E001", wave3FirstEnemyNumber);
                                thirdWave = "WAVE 3: 1 E001";
                                break;
                            case Wave3FirstEnemyType.E002:
                                SpawnWave("E002", wave3FirstEnemyNumber);
                                thirdWave = "WAVE 3: 1 E002";
                                break;
                        }
                        
                        switch (wave3SecondEnemyType)
                        {
                            case Wave3SecondEnemyType.E001:
                                SpawnWave("E001", wave3SecondEnemyNumber);
                                thirdWave = thirdWave + " + 1 E001";
                                break;
                            case Wave3SecondEnemyType.E002:
                                SpawnWave("E002", wave3SecondEnemyNumber);
                                thirdWave = thirdWave + " + 1 E002";
                                break;
                        }
                        break;
                    
            case 4:
                
                        switch (wave4FirstEnemyType)
                        {
                            case Wave4FirstEnemyType.E001:
                                SpawnWave("E001", wave4FirstEnemyNumber);
                                fourthWave = "WAVE 4: 1 E001";
                                break;
                            case Wave4FirstEnemyType.E002:
                                SpawnWave("E002", wave4FirstEnemyNumber);
                                fourthWave = "WAVE 4: 1 E002";
                                break;
                        }
                                            
                        switch (wave4SecondEnemyType)
                        {
                            case Wave4SecondEnemyType.E001:
                                SpawnWave("E001", wave4SecondEnemyNumber);
                                fourthWave = fourthWave + " + 1 E001";
                                break;
                            case Wave4SecondEnemyType.E002:
                                SpawnWave("E002", wave4SecondEnemyNumber);
                                fourthWave = fourthWave + " + 1 E002";
                                break;
                        }
                        break;
                                  
               
        }
        //waveNumber++;
    }

    void SpawnWave(string enemyType, int enemyNumbers)
    {
        if (enemyNumbers > 0)
        {
            Vector3 gridPosToSpawn;
            GameObject enemyToSpawn = null;
            GameObject enemySpawned = null;
            enemyToSpawn = enemyListScript.getEnemy(enemyType);

            //Debug.Log(enemyToSpawn);
            for (int i = 0; i <= enemyNumbers - 1; i++)
            {
            rerandom:
                
                int randomTile = Random.Range(0, spawnPlaces.Count - 1);
                                
                gridPosToSpawn = spawnPlaces[randomTile];


                if (spawnedPlace.Contains(gridPosToSpawn) && i <= enemyNumbers)
                {
                    goto rerandom;
                }
                                
                if (playerScript.areaAroundPlayer.Contains(gridPosToSpawn) && i <= enemyNumbers)
                {
                    goto rerandom;
                }

                switch (enemyType)
                {
                    case "E001": //Hedgehog
                        enemySpawned = (GameObject)GameObject.Instantiate(enemyToSpawn, gridPosToSpawn + new Vector3(0.0f, 0.2f, 0.0f), Quaternion.identity);
                        break;

                    case "E002": //Wolf
                        enemySpawned = (GameObject)GameObject.Instantiate(enemyToSpawn, gridPosToSpawn + new Vector3(0.0f, heightSpawnWolf, 0.0f), Quaternion.identity);
                        break;

                }

                
                //enemySpawned.transform.name = enemyType + "_" + x + z;
                Animator enemyAnimator = enemySpawned.GetComponent<Animator>();
                enemyAnimator.SetTrigger("Spawn");
                enemySpawned.transform.name = enemyType + "_" + spawnPlaces[randomTile].x + spawnPlaces[randomTile].z;
                spawnedPlace.Add(gridPosToSpawn);
            }
        }
                
    }

    void CheckTilesAvailable()
    {
        RaycastHit checkUnderneath;
        Vector3 tilePosition;
        spawnPlaces.Clear();

        for (int x = 0; x < GScript.Size.x; x++)
        {
            for (int z = 0; z < GScript.Size.z; z++)
            {
                tilePosition = GScript.Grid[x, z].transform.position;
                tilePosition = tilePosition + new Vector3(0.0f, 3.0f, 0.0f);
                Physics.Raycast(tilePosition, new Vector3(0.0f, -0.1f, 0.0f), out checkUnderneath, Mathf.Infinity);
                
                if (checkUnderneath.collider != null && checkUnderneath.collider.transform.tag == "Grid_Group")
                {
                    //Debug.Log(checkUnderneath.collider.transform.tag);
                    spawnPlaces.Add(new Vector3((int)x, 0.0f, (int)z));
                }
            }
        }
        for (int i = 0; i < spawnPlaces.Count; i++)
        {
            //Debug.Log(spawnPlaces[i]);
        }
    }

    public void WaitForSettingTilesAvailable()
    {
       
        StartCoroutine(WaitForTiles());
        
    }

    IEnumerator WaitForTiles()
    {
        
        yield return new WaitForSeconds(1.0f);
    }

}
