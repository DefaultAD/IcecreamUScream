using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Stack stack;

    public Transform camTarget;

    public float smoothSpeed = 0.00625f;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 10f, 0);
    }

    void FixedUpdate()
    {
        Vector3 smoothedPosition = transform.position;
        Vector3 desiredPosition = camTarget.position + (offset - new Vector3(0,0, stack.camDistanceZ));
        smoothedPosition.y = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).y;
        transform.position = smoothedPosition;

        //transform.LookAt(camTarget);
    }
}
