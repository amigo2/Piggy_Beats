using UnityEngine;
using System.Collections;

public class Movement_Accelerometer : MonoBehaviour {

    public float speed = 500;
    public float speedAc = 10;

    public Vector3 zeroAc;
    public Vector3 curAc;
    public float sensH = 10;
    public float sensV = 10;
    public float smooth = 0.5f;
    public float GetAxisH = 0;
    public float GetAxisV = 0;

    Transform thisTransform;
    Animator thisAnimator;

	// Use this for initialization
	void Start () {
        thisTransform = transform;
        thisAnimator = thisTransform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            //get input by keyboard
            float movehorizontal = Input.GetAxis("Horizontal");
            float movevertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);

            thisTransform.rotation = Quaternion.LookRotation(-movement);
            thisAnimator.SetBool("Speed", true);

            rigidbody.AddForce(movement * speed * Time.deltaTime);
        }
        else
        {
            //get input by accelerometer
            curAc = Vector3.Lerp(curAc, Input.acceleration - zeroAc, Time.deltaTime / smooth);
            GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
            GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);
            // now use GetAxisV and GetAxisH instead of Input.GetAxis vertical and horizontal
            // If the horizontal and vertical directions are swapped, swap curAc.y and curAc.x
            // in the above equations. If some axis is going in the wrong direction, invert the
            // signal (use -curAc.x or -curAc.y)

            Vector3 movement = new Vector3(GetAxisH, 0.0f, GetAxisV);

            thisTransform.rotation = Quaternion.LookRotation(-movement);
            thisAnimator.SetBool("Speed", true);

            rigidbody.AddForce(movement * speedAc);

        }
    }
}
