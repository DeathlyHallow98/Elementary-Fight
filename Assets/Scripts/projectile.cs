using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float forward;
    public float upward;
    public float scale = 1f;
    private Rigidbody rb;
    private Transform tr;
    // Update is called once per frame
   
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();
        tr.localScale = new Vector3(scale, scale, scale);
        Debug.Log(scale);
        Debug.Log(tr.localScale);
    }
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
           if(scale <=2)
            {
            scale += 0.01f;
            tr.localScale = new Vector3(scale, scale, scale);
            }

          


        //    Debug.Log("s");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
            rb.drag = 0;
        }
        
    }
}
