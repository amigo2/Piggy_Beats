using UnityEngine;
using System.Collections;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
//Remove this for the product version

public class SmoothCameraMovement : MonoBehaviour
{

    Transform target;
    public float distance = 20.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;

    public float lookAtHeight = 0.0f;

    public Rigidbody parentRigidbody;

    public float rotationSnapTime = 0.3F;

    public float distanceSnapTime;
    public float distanceMultiplier;

    private Vector3 lookAtVector;

    private float usedDistance;

    float wantedRotationAngle;
    float wantedHeight;

    float currentRotationAngle;
    float currentHeight;

    Quaternion currentRotation;
    Vector3 wantedPosition;

    private float yVelocity = 0.0F;
    private float zVelocity = 0.0F;

    void Start()
    {

        lookAtVector = new Vector3(0.0f, lookAtHeight, 0.0f);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {

        wantedHeight = target.position.y + height;
        currentHeight = transform.position.y;

        //wantedRotationAngle = target.eulerAngles.y;
        //currentRotationAngle = transform.eulerAngles.y;

        currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        wantedPosition = target.position;
        wantedPosition.y = currentHeight;

        usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime);

        wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);
               
        transform.position = wantedPosition;

        transform.LookAt(target.position + lookAtVector);
    }
}
