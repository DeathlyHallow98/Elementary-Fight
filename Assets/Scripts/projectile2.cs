using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
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
        transform.Rotate(new Vector3(100f, 0f, 0f));
        if (Input.GetButton("Fire2"))
        {
            if (scale <= 2)
            {
                scale += 0.1f;
                tr.localScale = new Vector3(scale, scale, scale);
            }




            //    Debug.Log("s");
        }
        if (Input.GetButtonUp("Fire2"))
        {
            rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
            
            rb.drag = 0;


            
        }

    }
}
