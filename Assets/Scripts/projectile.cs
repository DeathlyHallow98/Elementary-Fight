using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed; //speed of the bullet
    public float upward; //upward speed
    public float scale = 1f; //initial scale of the bullet
    private float forward; //direction of the bullet
    private Rigidbody rb; // bullet's rigidbody
    private Transform tr; // bullet's transform
    private bool released = false; //so that clicking buttons again will not affect it once released
    private Transform firepoint;
   
    //initialize everything
    private void Start()
    {
        firepoint = GameObject.FindGameObjectWithTag("Player").transform.Find("firepoint");
        forward = transform.right.x * speed; //direction times speed (-ve or +ve)
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();
        tr.localScale = new Vector3(scale, scale, scale); 
        
    }
    void Update()
    {
        if(!released)
        {
            tr.position = firepoint.position;
        }
        //increase the size
        if (Input.GetButton("Fire1"))
        {
           if(scale <=2 && !released)
            {
            scale += 0.1f;
            tr.localScale = new Vector3(scale, scale, scale);
            }
            

        }

        //release the ball and destroy it after one second
        if (Input.GetButtonUp("Fire1"))
        {
              
            if(!released)
            {
                
                rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
                rb.drag = 0;
                Destroy(gameObject, 1);

            }
            //once set true, it should be not be set back to false!!!!
            released = true;

        }

        
    }
}
