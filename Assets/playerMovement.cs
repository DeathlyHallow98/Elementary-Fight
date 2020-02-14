using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 10f;   
    private bool canJump = false;
    public float numberOfJumps = 2;
    public float gravity = -20f;

    // increase the gravity
    // Player movement
    // updates the canJump boolean
    void Update()
    {
        Physics.gravity = new Vector3(0f, gravity, 0f);
        Jump();
        Vector3 playerMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += playerMovement * moveSpeed * Time.deltaTime;
        if(numberOfJumps <1)
        {
            canJump = false;
        }
    }

    //Player Jumps, velocity is et to zero so second jump has the same height
    void Jump()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (Input.GetButtonDown("Jump") && canJump )
        {
            rb.AddForce(new Vector2(0f, jumpForce),ForceMode.Impulse);
            rb.velocity = new Vector2(0, 0);
            numberOfJumps--;
        }
       
    }
   
    //this method checks if the player is on the ground
    private void OnTriggerStay(Collider other)
    {
        canJump = true;
     
    }

    //set jumps back to 2 when the player hits the ground
    private void OnTriggerEnter(Collider other)
    {
        numberOfJumps = 2;
    }
}
