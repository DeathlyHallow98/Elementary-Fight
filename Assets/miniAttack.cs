using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniAttack : MonoBehaviour
{
    public GameObject projPreFab;
    public float drag = 0;
    public float scale = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("pressed");
            scale += 0.2f;
            Attack();
            projPreFab.GetComponent<Rigidbody>().drag = 200;
           // projPreFab.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
        }

        

    }
    void Attack()
    {
        while (!Input.GetButtonUp("Fire1"))
        {
            {
                //if (Input.GetButtonDown("Fire1"))
                //{
                //    Debug.Log("pressed");
                //    scale += 0.2f;
                //    projPreFab.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
                //}
                Debug.Log("s");
            }
        }
            Instantiate(projPreFab, transform.position, transform.rotation);

    }
}
