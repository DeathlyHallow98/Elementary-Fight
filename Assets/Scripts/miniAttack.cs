using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniAttack : MonoBehaviour
{
    public GameObject projPreFab;
    public float drag = 0;
    public float scale = 2f;
    public float timer;
 


    // Update is called once per frame
    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("pressed");
          
            Attack();
            projPreFab.GetComponent<Rigidbody>().drag = 200;
            // projPreFab.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);

        }
       
    }

    void Attack()
    {
        Instantiate(projPreFab, transform.position, transform.rotation);

        //add a timer here

    }
   
}
