using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile2 : MonoBehaviour
{
    public float speed; //speed of the bullet
    public float upward; //upward speed
    public float scale = 1f; //initial scale of the bullet
    private float forward; //direction of the bullet
    private Rigidbody rb; // bullet's rigidbody
    private Transform tr; // bullet's transform
    private bool released = false; //so that clicking buttons again will not affect it once released

    //initialize everything
    private void Start()
    {
        forward = transform.right.x * speed; //direction times speed (-ve or +ve)
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();

        // tr.localScale = new Vector3(scale, scale, scale);
        // Debug.Log(scale);
        //Debug.Log(tr.localScale);
    }
    void Update()
    {
        //put a delay on the fireing mechanic right now and then add energy meter later. 
        if(Input.GetButtonDown("Fire2"))
        {

        }
        transform.Rotate(new Vector3(100f, 0f, 0f));
        if (Input.GetButtonDown("Fire2"))
        {
            if (scale <= 2)
            {
                scale += 1.0f;
               // tr.localScale = new Vector3(scale, scale, scale);
            }




            //    Debug.Log("s");
        }
        if (Input.GetButtonUp("Fire2"))
        {

            if (!released)
            {
                Debug.Log(forward);
                rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
                rb.drag = 0;
                Destroy(gameObject, 1);

            }
            //once set true, it should be not be set back to false!!!!
            released = true;

        }

    }
}
