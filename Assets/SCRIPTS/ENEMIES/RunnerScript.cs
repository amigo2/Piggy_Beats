using UnityEngine;
using System.Collections;

public class RunnerScript : MonoBehaviour
{

    Rigidbody myRigidbody;
    Vector3 oldVel;
    Transform thisTransform;
    Animator runnerAnimator;
	public float MoveSpeed;
	public float AngleMin;
	public float AngleMax;
	float forceX;
	float forceZ;
    Vector3 bouncingForce;
    Vector3 originalVelocity;
    

    void Awake()
    {
		float randomAngle = Random.Range(AngleMin, (AngleMax + 1.0f));
		forceX = MoveSpeed * Mathf.Cos(randomAngle);
		forceZ = MoveSpeed * Mathf.Sin(randomAngle);

        
		bouncingForce = new Vector3(forceX, 0.0f, forceZ);


        thisTransform = transform;

		//thisTransform.forward = new Vector3(-forceX, 0.0f, -forceZ);
        thisTransform.forward = new Vector3(forceX, 0.0f, forceZ);
        myRigidbody = thisTransform.GetComponent<Rigidbody>();
        //myRigidbody.AddForce(bouncingForce);
        Invoke("GiveInitialForce", 1.0f);
    }

    void GiveInitialForce()
    {
        myRigidbody.AddForce(bouncingForce);
        //Debug.Log(myRigidbody.velocity);
    }

    void CheckInitialVelocity()
    {

    }

    void Start()
    {
        //Debug.Log("Hi");
        
        runnerAnimator = thisTransform.GetComponent<Animator>();
        //runnerAnimator.speed = 0.3f;
        runnerAnimator.SetBool("Speed", true);
    }

    void Update()
    {
       
        if (Game_Manager.levelFinished == true)
        {
            myRigidbody.isKinematic = true;
        }
        
    }

    void FixedUpdate()
    {
        oldVel = myRigidbody.velocity;
        if(myRigidbody.velocity.magnitude > 0.0f){
        if (myRigidbody.velocity.magnitude < 2.0f)
        {
            myRigidbody.isKinematic = true;
            //Invoke("AddForceAgain", 0.1f);
            AddForceAgain();
            //Debug.Log(myRigidbody.velocity.magnitude);
        }
        }
        //thisTransform.forward = -myRigidbody.velocity;
    }

    void OnCollisionEnter(Collision c)
    {
        ContactPoint cp = c.contacts[0];

        //Debug.Log(myRigidbody.velocity.magnitude);
        
        // calculate with Vector3.Reflect
        myRigidbody.velocity = Vector3.Reflect(oldVel, cp.normal);
        /*if (myRigidbody.velocity.magnitude < 3.0f)
        {
            myRigidbody.isKinematic = true;
            Invoke("AddForceAgain", 0.1f);
            //Debug.Log(myRigidbody.velocity.magnitude);
        }*/
        //Debug.Log(myRigidbody.velocity);
        try
        {
            thisTransform.forward = myRigidbody.velocity;
            // bumper effect to speed up ball
            //myRigidbody.velocity += cp.normal * 2.0f;
        }
        catch
        {
        }
        
        
    }

    void AddForceAgain()
    {
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce(bouncingForce);
    }
}
