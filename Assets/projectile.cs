using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float forward;
    public float upward;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetButtonUp("Fire1"))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
            rb.drag = 0;
        }
        
    }
}
