using UnityEngine;
using System.Collections;

public class Coin_Behaviour : MonoBehaviour {

	// How the coin behaves. Values are taken from the coin manager
	Coin_Manager CoinManager;
	
	int Value;
	int BouncesLeft;
    Transform thisTransform;

	// Use this for initialization
	void Start () 
	{
		// Get a reference to the coin manager
		CoinManager = (Coin_Manager)GameObject.FindWithTag("Grid").GetComponent("Coin_Manager");
		
		// Set the initial value and the number of bounces of the coin
		Value = CoinManager.Value;
		BouncesLeft = CoinManager.NumberOfBounces;

        thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	
	// Check if there are still bounces left 
	public bool CanBounce()
	{
		if (BouncesLeft > 0)
		{
			return true;
		}
		
		return false;
	}
	
	
	public void Bounce()
	{		
		if(BouncesLeft > 0)
		{
			// Set the bounce vector using the Bounce Height from the coin manager
			rigidbody.AddForce(Vector3.up * CoinManager.BounceForce);
			
			// If there is one bounce for the coin, then use the flat decreased value
			if (CoinManager.NumberOfBounces == 1)
			{
				Value = CoinManager.FlatDecreasedValue;
			}
			// if there is more than one bounce use the decreased value factor
			else
			{
				Value *= (int)CoinManager.DecreasedValueFactor;
			}
			
			BouncesLeft -= 1;
		}
	}
	
	// Returns the money value of the coin
	public int GetValue()
	{
		return Value;
	}

    void OnCollisionEnter()
    {
        thisTransform.animation.Play("Rotate");
        if (CanBounce())
        {
            Bounce();
        }
    }
}
