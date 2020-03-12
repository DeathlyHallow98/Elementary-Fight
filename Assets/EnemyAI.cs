using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private bool canJump = true;
    private bool canMove = true;
    //private bool canLightAttack = true;
    //private bool canChargeAttack = true;
    //private bool canShield = true;
    private bool facingRight = true; // check where the player is facing
    private bool[] canRun = new bool[5];
    private float waitTime;
    public float moveSpeed = 1f;
    public float jumpForce = 10f; // jump force
    public float numberOfJumps = 2;
    public float gravity = -20f;
    public float timer;
    public GameObject Player;
    public Rigidbody rb;
    public int horizontal; // values between -1,0,1

    public NavMeshAgent nav;
    delegate void MoveSets(int x);

    List<MoveSets> moveSet;

    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        rb = gameObject.GetComponent<Rigidbody>();
        //canRun[0] = true;
        //canRun[1] = true;
        //canRun[2] = true;
        //canRun[3] = true;
        //canRun[4] = true;
        Debug.Log("Start ran");
        moveSet = new List<MoveSets>();
        moveSet.Add(lightAttack);
        moveSet.Add(chargedAttack);
        moveSet.Add(shield);
        moveSet.Add(move);
        moveSet.Add(jump);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int i = Random.Range(0, 5);
        if (numberOfJumps < 2)
        {
            canJump = false;
        }
        //moveSet[i]();
        //Debug.Log("index i: "+i);
        //Debug.Log(canMove);
        //moveSet[3](i);
        if (timer >= 0.5)
        {
            moveSet[4](i);
            timer = 0;
           // StartCoroutine(Timeout(i));
        }
        
    }

    public void lightAttack(int x)
    {
      Debug.Log("Light Attack");
      canRun[x] = true;
    }
    public void chargedAttack(int x)
    {
       Debug.Log("Charged Attack");
       canRun[x] = true;
    }
    public void shield(int x)
    {
      Debug.Log("Shield");
      canRun[x] = true;

    }
    public void move(int x)
    {
        Debug.Log(nav.velocity);
        float xPos = gameObject.transform.position.x;
        float newX = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log("move");
        try
        {
            float playerPos = Player.transform.position.x;
            newX = Random.Range(xPos, playerPos);

            if ((transform.position.x > playerPos && facingRight) || (transform.position.x < playerPos && !facingRight))
            {
                Flip();
            }

        }
        catch
        {
            Debug.Log("No Player");
            newX = xPos + Random.Range(xPos - 100, xPos + 100);
        }


        Vector3 target = new Vector3(newX, transform.position.y, transform.position.z);
       
        nav.SetDestination(target);




    }
    public void jump(int x)
    {
        Debug.Log("Jumoed");
        if (canJump)
        {

           // rb.AddForce(new Vector2(0f, jumpForce), ForceMode.Impulse);
            rb.velocity += Vector3.up * jumpForce;
            numberOfJumps--;
        }

    }
    public void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    IEnumerator Timeout(int i)
    {
        float timePassed = 0;
        Debug.Log("Timeout i: " + i);
        canRun[i] = false;

        switch (i)
        {
            case 3:
                waitTime = 4;

                    break;
            default:
                waitTime = 5;
                break;
        }


        while (timePassed < waitTime)
        {
            moveSet[i](i);
            timePassed += Time.deltaTime;
          //  Debug.Log(canRun[i] + " " + i);
        }

        // yield return new WaitForSeconds(waitTime);
     //   canRun[i] = true;
        yield return null;


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
