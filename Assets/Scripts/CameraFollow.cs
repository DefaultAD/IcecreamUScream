using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public ScoopToppings scoopToppings;
    public Stack stack;

    public Transform camTarget;

    public float smoothSpeed = 1f;
    private Vector3 offset;

    public bool camMoved = false;

    private void Start()
    {
        offset = new Vector3(0, 10f, 0);
    }

    void FixedUpdate()
    {
        //Vector3 smoothedPosition = transform.position;
        //Vector3 desiredPosition = camTarget.position + (offset - new Vector3(0, 0, stack.camDistanceZ));
        //smoothedPosition.y = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).y;

        //transform.position = smoothedPosition;
        if (scoopToppings.isEnd == false && camMoved == false)
        {
            Vector3 smoothedPosition = transform.position;
            Vector3 desiredPosition = camTarget.position + (offset - new Vector3(0, 0, stack.camDistanceZ));
            smoothedPosition.y = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).y;
            smoothedPosition.z = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed).z;

            transform.position = smoothedPosition;
        }
        if (scoopToppings.isEnd == true && camMoved == false)
        {
            Vector3 smoothedPosition1 = transform.position;
            Vector3 desiredPosition1 = camTarget.position + (offset - new Vector3(0, -5, stack.camDistanceZ));
            smoothedPosition1.y = Vector3.Lerp(transform.position, desiredPosition1, smoothSpeed).y;

            transform.position = smoothedPosition1;
            //camMoved = true;
        }

        //transform.LookAt(camTarget);
    }

    public IEnumerator camWait()
    {
        yield return new WaitForSeconds(2f);
        camMoved = true;
    }
}
