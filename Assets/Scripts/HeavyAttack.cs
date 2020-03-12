using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projPreFab;
    public float drag = 0;
    public float scale = 2f;

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Debug.Log("pressed2");
            Attack();
            projPreFab.GetComponent<Rigidbody>().drag = 200;
        }
    }
    void Attack()
    {
        Instantiate(projPreFab, transform.position, transform.rotation);
    }
}
