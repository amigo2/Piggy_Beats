using UnityEngine;
using System.Collections;

public class AutoDestruction : MonoBehaviour {

	Transform thisTransform;
	public float TimeToAutodestruction;
    Animator thisAnimator;


	// Use this for initialization
	void Start () {
		thisTransform = transform;
        try
        {
            thisAnimator = (Animator)thisTransform.GetComponent<Animator>();
        }
        catch
        {
        }
        if (thisAnimator != null)
        {
            Invoke("PlayDeathAnimation", 4.5f);
        }
		Invoke ("DestroyThisShit", TimeToAutodestruction);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PlayDeathAnimation()
    {
        try
        {
            thisAnimator.SetTrigger("Destroy");
        }
        catch
        {

        }
    }

	void DestroyThisShit(){
		Destroy (thisTransform.gameObject);
	}
}
