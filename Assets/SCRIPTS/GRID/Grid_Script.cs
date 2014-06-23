using UnityEngine;
using System.Collections;

public class Grid_Script : MonoBehaviour {

	//SIZE
	public Vector3 Size;//Size of the grid


	//PREFABS
	public GameObject TilePrefab; 

	Transform thisTransform;
	public GameObject[, ] Grid;

	// Use this for initialization
	void Start () 
	{
		thisTransform = transform;	
		CreateGrid ();

	}
	
	// Update is called once per frame
	void Update () 
	{
				
	}
	
	void CreateGrid(){
		//Creates the grid 
		Grid = new GameObject[(int)Size.x, (int)Size.z];

		for (int x = 0; x < Size.x; x++) {
			for (int z = 0; z < Size.z; z++) {
				GameObject NewTile = (GameObject)GameObject.Instantiate(TilePrefab, new Vector3(x, 0.0f, z), Quaternion.identity);
				Grid[x, z] = NewTile;
				NewTile.transform.parent = thisTransform;
				NewTile.transform.name = x.ToString() + z.ToString();
				
			}
		}
	}

}
