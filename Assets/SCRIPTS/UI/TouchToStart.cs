using UnityEngine;
using System.Collections;

public class TouchToStart : MonoBehaviour {
    bool timeWaited = false;

	// Use this for initialization
	void Start () {
        Invoke("TimeWaitedTrue", 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (timeWaited == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.LoadLevel("MainMenu");
            }
        }
	}

    void TimeWaitedTrue()
    {
        timeWaited = true;
    }
}
