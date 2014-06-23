using UnityEngine;
using System.Collections;

public class PositioningJoystick : MonoBehaviour {

    public float fittingScreenGapValue = 0.02f;
    Transform thisTransform;

    //Create Margins.
    Vector2 minimumMargin;
    Vector2 worldPosOffScreen;

	// Use this for initialization
	void Start () {
        /*thisTransform = transform;
        minimumMargin = new Vector2(Screen.width * fittingScreenGapValue, Screen.height * fittingScreenGapValue);
        worldPosOffScreen = Camera.main.ScreenToWorldPoint(minimumMargin);
        thisTransform.position = new Vector3(worldPosOffScreen.x, worldPosOffScreen.y);
        Debug.Log(worldPosOffScreen);*/
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
