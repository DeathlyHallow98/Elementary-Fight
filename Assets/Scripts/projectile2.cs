﻿using System.Collections;
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
<<<<<<< HEAD
    private Transform firepoint;


    // Update is called once per frame
=======
>>>>>>> 40e9b11454c0a0c908525235e453fe5961c7125e

    //initialize everything
    private void Start()
    {
<<<<<<< HEAD
        firepoint = GameObject.FindGameObjectWithTag("Player").transform.Find("firepoint");

        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();
       // tr.localScale = new Vector3(scale, scale, scale);
=======
        forward = transform.right.x * speed; //direction times speed (-ve or +ve)
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();

        // tr.localScale = new Vector3(scale, scale, scale);
        // Debug.Log(scale);
        //Debug.Log(tr.localScale);
>>>>>>> 40e9b11454c0a0c908525235e453fe5961c7125e
    }
    void Update()
    {
        //put a delay on the fireing mechanic right now and then add energy meter later. 

        transform.Rotate(new Vector3(100f, 0f, 0f));
        forward = firepoint.transform.right.x * speed; //direction times speed (-ve or +ve)


        if (!released)
        {
            tr.position = firepoint.position;
        }
        //increase the size
        if (Input.GetButton("Fire2"))
        {
            if (scale <= 2 && !released)
            {
                scale += 0.1f;
               // tr.localScale = new Vector3(scale, scale, scale);
            }


        }
        if (Input.GetButtonUp("Fire2"))
        {

            if (!released)
            {
<<<<<<< HEAD

=======
                Debug.Log(forward);
>>>>>>> 40e9b11454c0a0c908525235e453fe5961c7125e
                rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
                rb.drag = 0;
                Destroy(gameObject, 1);

            }
            //once set true, it should be not be set back to false!!!!
            released = true;
<<<<<<< HEAD
=======

>>>>>>> 40e9b11454c0a0c908525235e453fe5961c7125e
        }

    }
}
