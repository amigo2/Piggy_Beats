using UnityEngine;
using System.Collections;

public class DestroyInmediate : MonoBehaviour {

    Transform thisTransform;
    
    // Use this for initialization
    void Start()
    {
        thisTransform = transform;
        DestroyThisShit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DestroyThisShit()
    {
        Destroy(thisTransform.gameObject);
    }
}
