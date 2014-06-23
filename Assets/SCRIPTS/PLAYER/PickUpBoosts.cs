using UnityEngine;
using System.Collections;

public class PickUpBoosts : MonoBehaviour {

    public float radius = 1.0f;
    Transform thisTranform;

    //Effects particles
    GameObject healParticle;
    GameObject speedParticle;


    //Scores prefabs
    public GameObject score100;
    public GameObject score200;

    //Scripts
    ClickAndMove MoveScript;
    Score scoreScript;
    SuperJoystick JoystickScript;
    UI_Script guiScript;

    //Player Animator
    Animator CharAnimator;

    //Audioclips
    public AudioClip CoinSound;

    public GameObject coinRigidBody;
    public GameObject coinCollectingEffect;

    bool chestAlreadyOpened = false;

    Vector3 positionToSpawn;

    GameObject prizeObject;
        
    int numberOfCoins = 0;

    int layerId = 12;
    int layerMask;

    Collider[] hitColliders;

	// Use this for initialization
	void Start () {
        thisTranform = transform;
        scoreScript = (Score)GameObject.FindGameObjectWithTag("Grid").GetComponent<Score>();
        guiScript = (UI_Script)Camera.main.transform.GetComponent<UI_Script>();
        CharAnimator = thisTranform.GetComponent<Animator>();
        layerMask = 1 << layerId;
        chestAlreadyOpened = false;
        numberOfCoins = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (guiScript.showScore == true)
        {
            try
            {
                Destroy(GameObject.FindGameObjectWithTag("Chest").gameObject);
            }
            catch
            {

            }
            
            chestAlreadyOpened = false;
        }

        hitColliders = Physics.OverlapSphere(thisTranform.position, radius, layerMask);
        
        for (int i = 0; i <= hitColliders.Length - 1; i++)
        {
            if (hitColliders[i].transform.GetComponent<BoxCollider>().size.x > 0)
            {
                switch (hitColliders[i].transform.tag)
                {
                    case "Heart":
                        prizeObject = hitColliders[i].transform.gameObject;
                        prizeObject.GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f);
                        if (Player_Script.Player_Current_Life < 100)
                        {
                            Player_Script.Player_Current_Life += 25;
                        }
                        if (Player_Script.Player_Current_Life + 25 > 100)
                        {
                            Player_Script.Player_Current_Life = 100;
                        }
                        if (Player_Script.Player_Current_Life == 100)
                        {
                            GameObject score200Pref = (GameObject)GameObject.Instantiate(score200, hitColliders[i].transform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                            scoreScript.AddScore(200);
                        }
                        //Insert audio of collecting life bonus	
                        healParticle = thisTranform.FindChild("PiggyEffects").transform.FindChild("LE_Healing").transform.gameObject;
                        healParticle.SetActive(true);
                        Invoke("ResetHeal", 4.0f);
                        prizeObject = hitColliders[i].transform.gameObject;
                        prizeObject.GetComponent<BoxCollider>().enabled = false;
                        //Animator prizeAnimator = (Animator)prizeObject.GetComponent<Animator>();
                        //prizeAnimator.SetTrigger("Destroy");
                        //Invoke("DestroyObject", 0.35f);
                        Destroy(hitColliders[i].transform.gameObject);
                        break;
                    case "Boots":
                        prizeObject = hitColliders[i].transform.gameObject;
                        prizeObject.GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f);
                        try
                        {
                            MoveScript = (ClickAndMove)thisTranform.GetComponent<ClickAndMove>();
                            MoveScript.BootsOn = true;
                        }
                        catch
                        {
                        }

                        if (GameObject.Find("TomatoJoystick"))
                        {
                            JoystickScript = (SuperJoystick)GameObject.Find("TomatoJoystick").GetComponent<SuperJoystick>();
                            JoystickScript.BootsOn = true;
                        }
                        speedParticle = thisTranform.FindChild("PiggyEffects").transform.FindChild("LE_SpeedUp").transform.gameObject;
                        speedParticle.SetActive(true);

                        Invoke("ResetSpeed", 5.0f);
                        Invoke("ResetBoots", 5.0f);
                                                
                        //Animator prizeAnimator2 = (Animator)prizeObject.GetComponent<Animator>();
                        //prizeAnimator2.SetTrigger("Destroy");
                        //Invoke("DestroyObject", 0.45f);

                        Destroy(hitColliders[i].transform.gameObject);
                        break;
                    case "Coin":
                        prizeObject = hitColliders[i].transform.gameObject;
                        prizeObject.GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f);
                        try
                        {
                            prizeObject.GetComponent<SphereCollider>().radius = 0.0f;
                        }
                        catch
                        {

                        }
                        //Debug.Log(prizeObject.name);

                        CharAnimator.SetTrigger("Dance1");

                        Coin_Behaviour coin = (Coin_Behaviour)thisTranform.GetComponent<Coin_Behaviour>();
                        AudioSource.PlayClipAtPoint(CoinSound, Camera.main.transform.position);

                        try
                        {
                            //Adds a coin to the counter and the value
                            Score.coinCounter += 1;
                            //Score.moneyCounter += coin.GetValue();
                            GameObject score100Pref = (GameObject)GameObject.Instantiate(score100, hitColliders[i].transform.position + new Vector3(0.0f, 0.5f, 0.0f), Quaternion.identity);
                            GameObject effect = (GameObject)GameObject.Instantiate(coinCollectingEffect, hitColliders[i].transform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
                            scoreScript.AddScore(100);
                        }
                        catch
                        {
                        }
                                                
                        
                        //Animator prizeAnimator3 = (Animator)prizeObject.GetComponent<Animator>();
                        Destroy(hitColliders[i].transform.gameObject);
                        //prizeAnimator3.SetTrigger("Destroy");
                        //Invoke("DestroyObject", 0.55f);
                        
                        break;
                    case "Chest":
                        prizeObject = hitColliders[i].transform.gameObject;
                        prizeObject.GetComponent<BoxCollider>().size = new Vector3(0.0f, 0.0f, 0.0f);
                        Animator chestAnimator = (Animator)hitColliders[i].transform.GetComponent<Animator>();
                        chestAnimator.SetTrigger("Ground");
                                               
                        positionToSpawn = hitColliders[i].transform.position + new Vector3(0.0f, 0.5f, 0.0f);

                        
                        if (scoreScript.scoreCounter >= 3600)
                        {
                            numberOfCoins = 10;
                        }
                        else if (scoreScript.scoreCounter < 3600 && scoreScript.scoreCounter > 2600)
                        {
                            numberOfCoins = 5;
                        }
                        else if (scoreScript.scoreCounter <= 1600 && scoreScript.scoreCounter > 0)
                        {
                            numberOfCoins = 2;
                        }
                        if (chestAlreadyOpened == false)
                        {
                            chestAlreadyOpened = true;
                                                          
                            InvokeRepeating("SpawnCoin", 1.8f, 0.3f);
                            InvokeRepeating("LessCoins", 1.8f, 0.3f);
                                                            
                        }
                                               
                        //Animator prizeAnimator4 = (Animator)prizeObject.GetComponent<Animator>();
                        //prizeAnimator4.SetTrigger("Destroy");
                        //Invoke("DestroyObject", 1.0f);
                        break;
                }
            }
                
            }
        }

   
    void LessCoins()
    {
        numberOfCoins--;
        if (numberOfCoins == 0)
        {
            CancelInvoke();
        }
    }

    void SpawnCoin()
    {        
            float randomPosX = 0.0f;
            float randomPosZ = 0.0f;
            int rerandom = Random.Range(0, 4);
            switch (rerandom)
            {
                case 0:
                    randomPosX = -0.8f;
                    randomPosZ = -0.8f;
                    break;
                case 1:
                    randomPosX = -0.8f;
                    randomPosZ = 0.8f;
                    break;
                case 2:
                    randomPosX = 0.8f;
                    randomPosZ = -0.8f;
                    break;
                case 3:
                    randomPosX = 0.8f;
                    randomPosZ = 0.8f;
                    break;
            }
            GameObject coinReward = (GameObject)GameObject.Instantiate(coinRigidBody, positionToSpawn + new Vector3(randomPosX, 0.0f, randomPosZ), Quaternion.identity);
        
    }

    void DestroyObject()
    {
        //prizeObject.GetComponent<DestroyInmediate>().enabled = true;
        try
        {
            Destroy(prizeObject.gameObject);
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
        //Debug.Log("Hi");
        speedParticle.SetActive(false);
    }

    void ResetBoots()
    {
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
}
