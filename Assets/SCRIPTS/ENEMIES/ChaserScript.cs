using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChaserScript : MonoBehaviour {

    Transform thisTransform;
    Grid_Script GScript;
    public float enemySpeed = 1.0f;
    //public float timeToStop = 3.0f;
    //public float timeStopped = 1.0f;

    public float areaOfDetection = 1.5f;

    
    bool chasing = false;
    bool detecting = false;
    bool moving = false;

    int rnd;
    bool stoppedAlready = false;
    Animator wolfAnimator;
    public float detectingTime = 2.0f;

    List<GameObject> tilesToMove = new List<GameObject>();

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        GScript = (Grid_Script)GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid_Script>();
        wolfAnimator = thisTransform.GetComponent<Animator>();
        //detecting = true;
        Invoke("DelayTheChasing", 3.0f);
        InvokeRepeating("SmellAround", 0.0f, 2.0f);
        InvokeRepeating("FindTilesAround", 2.0f, 2.2f);
        InvokeRepeating("MoveOrNotToMove", 2.0f, 1.1f);
	}

    void DelayTheChasing()
    {
        detecting = true;
    }

	// Update is called once per frame
	void Update () {
        
        //wolfAnimator.SetFloat("Speed", 0.0f);
        if (detecting == true)
        {

            DetectingArea();
        }
        if(chasing == true){
            Chasing();
            //Invoke("SetStop", timeToStop);
        }
        if (chasing == false)
        {
            if (moving == true)
            {
                MoveRandomly();
            }
            
        }
        if (Game_Manager.levelFinished == true)
        {
            CancelInvoke();
        }
                  
	}

    void DetectingArea()
    {
        Collider[] hitColliders = Physics.OverlapSphere(thisTransform.position, areaOfDetection);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].transform.tag == "Player")
            {
                chasing = true;
                detecting = false;                
                //Chasing();
                //Invoke("SetStop", 3.0f);
                Invoke("StopDetecting", 3.0f);
            }
        }
        
    }

    void Chasing()
    {
        if (Game_Manager.levelFinished == false)
        {
            //wolfAnimator.SetFloat("Speed", 0.2f);
            wolfAnimator.SetBool("Speed", true);
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * enemySpeed);
            //thisTransform.position = Vector3.MoveTowards(thisTransform.position, playerPosition, Time.deltaTime * enemySpeed);
            Quaternion targetRotation = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - thisTransform.position);
            thisTransform.rotation = targetRotation;
            stoppedAlready = false;
        }
    }

    void StopDetecting()
    {
        chasing = false;
        Invoke("StartDetecting", detectingTime);
        wolfAnimator.SetBool("Speed", false);
    }

    void StartDetecting()
    {
        detecting = true;
    }

    void SmellAround()
    {
        if (chasing == false)
        {
            wolfAnimator.SetTrigger("LookAround");
        }
    }

    void FindTilesAround()
    {
        RaycastHit checkAround;
        Vector3 currentStandingTile = new Vector3(0.0f, 0.0f, 0.0f);
        tilesToMove.Clear();
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
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(0.0f, 3.0f, 1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-1.0f, 3.0f, 0.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(0.0f, 3.0f, -1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(1.0f, 3.0f, 1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-1.0f, 3.0f, -1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(1.0f, 3.0f, -1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        Physics.Raycast(currentStandingTile + new Vector3(-1.0f, 3.0f, 1.0f), new Vector3(0.0f, -0.1f, 0.0f), out checkAround);
        if (checkAround.collider != null)
        {
            if (checkAround.collider.tag == "Grid_Group")
            {
                tilesToMove.Add(checkAround.collider.gameObject);
            }
        }
        rnd = Random.Range(0, tilesToMove.Count - 1);
    }

    void MoveRandomly()
    {       
            //Debug.Log(rnd);
            //Debug.Log(tilesToMove[rnd].transform.tag);
        try
        {
            thisTransform.position = Vector3.MoveTowards(thisTransform.position, tilesToMove[rnd].transform.position, Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(-(-tilesToMove[rnd].transform.position + transform.position));
            thisTransform.rotation = targetRotation;
        }
        catch
        {

        }
    }

    void MoveOrNotToMove()
    {
        if (moving == true)
        {
            moving = false;
            if (chasing == false)
            {
                wolfAnimator.SetBool("Speed", false);
            }
            
        }
        else
        {
            moving = true;
            wolfAnimator.SetBool("Speed", true);
        }
    }
   
    //IEnumerator WaitForTiles()
    //{
        //yield return new WaitForSeconds(timeToStop);
    //}
}
