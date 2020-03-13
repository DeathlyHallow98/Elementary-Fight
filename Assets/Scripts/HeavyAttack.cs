using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projPreFab;
    public float drag = 0;
    public float scale = 2f;
    public float timer;
    public bool AlreadyAttacked = false;
   

   

    // Update is called once per frame
    void Update()
    {

        //put a delay on the fireing mechanic right now and then add energy meter later. 

 
        if (Input.GetButtonDown("Fire2"))
        {
         
            Debug.Log("pressed2");
            heavyAttack();
            projPreFab.GetComponent<Rigidbody>().drag = 200;
            AlreadyAttacked = true;

         
            





        }

        
  }
    void heavyAttack()
    {
        //USE THIS CODE IF YOU WANT TO GET RID OF CLONED OBJECTS SHOT AS PROJECTILES
        //---------------------------------------
        var timedestroy = 3.5f;
        GameObject fireball = Instantiate(projPreFab, transform.position, transform.rotation);
        //Destroy(fireball, timedestroy);
        //-------------------------------------------

    }
}
