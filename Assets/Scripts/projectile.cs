using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeepChild
{

 
    //Depth-first search
    public static Transform FindDeepChild(this Transform aParent, string aName)
    {
        foreach(Transform child in aParent)
        {
            if(child.name == aName )
                return child;
            var result = child.FindDeepChild(aName);
            if (result != null)
                return result;
        }
        return null;
    }
  
}
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
    private GameObject player;
    private Animator animator;
    private float projSpeed = 0;


    //initialize everything
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        firepoint =player.transform.FindDeepChild("firepoint");
        animator = player.GetComponent<Animator>();

        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();
        tr.localScale = new Vector3(scale, scale, scale);
      
    }
    void FixedUpdate()
    {
        animator.SetFloat("ProjSpeed", projSpeed);
        forward = firepoint.transform.right.x * speed; //direction times speed (-ve or +ve)
        if (!released)
        {
            tr.position = firepoint.position;
        }
        //increase the size
        if (Input.GetButton("Fire1"))
        {
           if(scale <=2 && !released)
            {
                projSpeed += 0.1f;
            scale += 0.1f;
            tr.localScale = new Vector3(scale, scale, scale);
            }
            

        }

        //release the ball and destroy it after one second
        if (Input.GetButtonUp("Fire1"))
        {
              
            if(!released)
            {
                animator.SetBool("ProjReleased", true);
                rb.AddForce(new Vector2(forward, upward), ForceMode.Impulse);
                rb.drag = 0;
                Destroy(gameObject, 1);

            }
            //once set true, it should be not be set back to false!!!!
            released = true;
            animator.SetBool("ProjReleased", true);
            projSpeed = 0;

        }

        
    }

}
