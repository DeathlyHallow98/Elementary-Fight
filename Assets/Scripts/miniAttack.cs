using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniAttack : MonoBehaviour
{
    public GameObject projPreFab;
    public float drag = 0;
    public float scale = 0.25f;
 
 


    // Update is called once per frame
    void Update()
    {
       
        
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

        //USE THIS CODE IF YOU WANT TO GET RID OF CLONED OBJECTS SHOT AS PROJECTILES
        //---------------------------------------
        var timedestroy = 5.0f;
        GameObject fireball = Instantiate(projPreFab, transform.position, transform.rotation);
        Destroy(fireball, timedestroy);
        //add a timer 

    }
   
}
