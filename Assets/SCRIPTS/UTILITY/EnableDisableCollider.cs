using UnityEngine;
using System.Collections;

public class EnableDisableCollider : MonoBehaviour {

    Transform thisTransform;
    public float radius;
	int layerId = 13;
    int layerMask;
    BoxCollider thisCollider;
    
	// Use this for initialization
	void Start () {
	   layerMask = 1 << layerId;
       thisTransform = transform;
       thisCollider = thisTransform.GetComponent<BoxCollider>();
       thisCollider.size = new Vector3(0.0f, 0.0f, 0.0f);
       Invoke("EnableColliderAfterSpawn", 1.0f);
	}
	
	// Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(thisTransform.position, radius, layerMask);

        if (hitColliders.Length > 0)
        {
            thisCollider.enabled = false;
        }
        else
        {
            thisCollider.enabled = true;
        }
                
    }

    void EnableColliderAfterSpawn()
    {
        //thisCollider.enabled = true;
        thisCollider.size = new Vector3(0.05f, 0.05f, 0.03f);
    }
}
