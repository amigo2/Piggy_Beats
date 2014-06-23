using UnityEngine;
using System.Collections;

public class HitByEnemies : MonoBehaviour {

    Transform thisTransform;
    public float radius;

    Animator enemyAnimator;
    Animator charAnimator;

    public AudioClip PigHit;

    public GameObject hitEffect;

    int counter = 0;

    int layerId = 13;
    int layerMask;

	// Use this for initialization
	void Start () {
	    thisTransform = transform;
        charAnimator = thisTransform.GetComponent<Animator>();
        layerMask = 1 << layerId;
	}
	
	// Update is called once per frame
	void Update () {
	Collider[] hitColliders = Physics.OverlapSphere(thisTransform.position, radius, layerMask);

        if (hitColliders.Length > 0)
            {
            for (int i = 0; i <= hitColliders.Length - 1; i++)
            {
                  switch (hitColliders[i].transform.tag)
                    {
                        case "Hedgehog":
                            enemyAnimator = hitColliders[i].transform.GetComponent<Animator>();
                            charAnimator.SetTrigger("Hit");
                            enemyAnimator.SetTrigger("Destroy");

                            if (Player_Script.Player_Current_Life > 0)
                            {
                                Player_Script.Player_Current_Life -= 25;
                            }
                            GameObject HitEffect = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
                            AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                            hitColliders[i].transform.GetComponent<AutoDestruction>().enabled = true;
                            hitColliders[i].transform.tag = "Temp";
                            break;
                        case "Wolf":
                            enemyAnimator = hitColliders[i].transform.GetComponent<Animator>();
                            charAnimator.SetTrigger("Hit");
                            enemyAnimator.SetTrigger("Destroy");
                            if (Player_Script.Player_Current_Life > 0)
                            {
                                Player_Script.Player_Current_Life -= 25;
                            }
                            GameObject HitEffect2 = (GameObject)GameObject.Instantiate(hitEffect, thisTransform.position + new Vector3(0.0f, 0.1f, 0.0f), Quaternion.identity);
                            AudioSource.PlayClipAtPoint(PigHit, Camera.main.transform.position);
                            hitColliders[i].transform.GetComponent<AutoDestruction>().enabled = true;
                            hitColliders[i].transform.tag = "Temp";
                            break;
                    
                }
            }
            

        }
	}
}
