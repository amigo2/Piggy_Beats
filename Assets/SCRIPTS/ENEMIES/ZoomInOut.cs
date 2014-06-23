using UnityEngine;
using System.Collections;

public class ZoomInOut : MonoBehaviour {

	Transform thisTransform;

	public float ZoomFactor = 10.0f;
    public float Speed;

	void  Start ()
	{
        thisTransform = transform;
	}
	
	void  Update ()
	{
		camera.fieldOfView -= Input.GetAxis ("Mouse ScrollWheel") * ZoomFactor;

      
        /*camera.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        //thisTransform.rotation = Quaternion.Euler(Vector3.zero);
        //thisTransform.position = Vector3.MoveTowards(thisTransform.position, new Vector3(Player_Script.Current_Player_Tile_Position.x, 6.0f, Player_Script.Current_Player_Tile_Position.z - 4), Time.deltaTime * Speed);
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, new Vector3(Player_Script.Current_Player_Tile_Position.x, 6.0f, Player_Script.Current_Player_Tile_Position.z - 4), Time.deltaTime);
        thisTransform.rotation = Quaternion.Euler(new Vector3(60.0f, 0.0f, 0.0f));*/
        
	}
}