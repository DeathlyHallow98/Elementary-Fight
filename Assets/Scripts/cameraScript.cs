using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothSpeed =0.5f;
    public Vector3 offset;
    private Vector3 velocity;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    private Camera cam;
    public float limit = 37f;
    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if(targets.Count ==0)
        {
            return;
        }
        Vector3 center = getCenterPoint();
        Vector3 newPos = center + offset;
       // Vector3 finalPos = targets.position + offset;
        //Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, smoothSpeed * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothSpeed);

        float zoom = Mathf.Lerp(maxZoom, minZoom, GetDistance() / limit);
        cam.fieldOfView =Mathf.Lerp(cam.fieldOfView,zoom,Time.deltaTime);
    

    }
    private float GetDistance()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i< targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    private Vector3 getCenterPoint()
    {
        if(targets.Count ==1)
        {
            return targets[0].position;
        }
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i=0; i< targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
