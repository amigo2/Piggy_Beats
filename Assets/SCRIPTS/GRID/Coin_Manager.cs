using UnityEngine;
using System.Collections;

public class Coin_Manager : MonoBehaviour {

	// Coin manager class to use per level. That way each level can have its own coin behaviour
	
	public int Value = 100; // The initial value of the coin
	public int FlatDecreasedValue = 75; // Value at which the coin will be after one bounce
	public float DecreasedValueFactor = 0.75f; // Factor by which the value of the coin will be multiplied by after each bounce
	public float BounceForce = 600.0f; // The height at which the coin will bounce
	public int NumberOfBounces = 1; // The number of bounces of the coin. If it's one the FlatDecreasedValue variable will be used
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
