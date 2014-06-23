using UnityEngine;
using System.Collections;

public class DestroyAfterFinished : MonoBehaviour {

    Transform thisTransform;
    Animator thisAnimator;
    bool sentToDestroy = false;

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        thisAnimator = thisTransform.GetComponent<Animator>();
        sentToDestroy = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Game_Manager.levelFinished == true)
        {
            if (sentToDestroy == false)
            {
                thisAnimator.SetTrigger("Destroy");
                thisTransform.GetComponent<AutoDestruction>().enabled = true;
                sentToDestroy = true;
            }
        }

        else if (Score.comboCounter == 1 && Game_Manager.levelIsInfinite == true)
        {
            if (sentToDestroy == false)
            {
                thisAnimator.SetTrigger("Destroy");
                thisTransform.GetComponent<AutoDestruction>().enabled = true;
                sentToDestroy = true;
            }
        }
	}

    
}
