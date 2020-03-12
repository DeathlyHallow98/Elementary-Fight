using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 finalPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;

        transform.LookAt(target);
    }
}
