using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //booleans to check if they can perform these actions or not
    private bool canJump = true;
    private bool canMove = true;
    private bool canShield = true;
    private bool facingRight = true; 

    //variables for speed and jump forces and max number of jumps
    public float moveSpeed = 6f;
    public float jumpForce = 10f; 
    public float numberOfJumps = 2;
    public float timer,scale; //timer to create a timer, scale to set the size of the objects

    public GameObject earthProjPrefab,earthShieldPrefab; //prefabs for projectile and shield
    private GameObject ground; //referance to the Ground
    private GameObject Player; //reference to player1 
    private Transform firePoint; //point where the projectiles fire from
    private Rigidbody rb; 

    
    delegate void MoveSets();
    //list of methods
    List<MoveSets> moveSet;

    void Start()
    {
        firePoint = transform.Find("firepoint"); // finds the object with its children
        rb = gameObject.GetComponent<Rigidbody>();

        //initialize the moveset and add the methods
        moveSet = new List<MoveSets>();
        moveSet.Add(lightAttack);
        moveSet.Add(chargedAttack);
        moveSet.Add(shield);
        moveSet.Add(jump);

    }

    void FixedUpdate()
    {
        timer += Time.deltaTime; 
        int i = Random.Range(0, 4); //generates a random number between (0,4]

        //can't jump if limit reached
        if (numberOfJumps < 1) {
            canJump = false;
        }

        //runs a random method between random intervals
        if(timer > Random.Range(1,4))
        { 
            canMove = true;
            timer = 0;
            moveSet[i]();
        }
            
        move();

    }

    //melee attack
    public void lightAttack()
    {
        earthProjPrefab.transform.localScale = new Vector3(scale, scale, scale); //set the local scale
        canMove = false; //briefly stop the player from moving

        ground = GameObject.FindGameObjectWithTag("Ground"); 
        float yPos = ground.transform.position.y; //set the y value to ground's y
        float xPos = firePoint.transform.position.x; //set the x value to the firepoint's x

        Vector3 instancePos = new Vector3(xPos, yPos, transform.position.z);
        Instantiate(earthProjPrefab, instancePos, transform.rotation); //instantiate at that position

        canMove = true;
    }

    //charged attack
    public void chargedAttack()
    {
        //calls light attack but bigger
        scale = 2; 
        lightAttack();
        scale = 1;
    }

    //shield
    public void shield()
    {
        if(numberOfJumps ==2 && canShield) //if grounded
        {
            canShield = false; 
            float yPos = ground.transform.position.y;
            Vector3 instancePos = new Vector3(transform.position.x, yPos, transform.position.z);
            Instantiate(earthShieldPrefab, instancePos, transform.rotation); //instantiate the shield where the player is
            StartCoroutine(Timeout(20)); //shield cooldown for 20s
        }

    }

    //move
    public void move()
    {
        if(canMove)
        {
   
            float xPos = gameObject.transform.position.x; //current x position
            float newX = 0;
            Player = GameObject.FindGameObjectWithTag("Player"); //refernce to the player1
            try
            {   
                float playerPos = Player.transform.position.x; //player's position
                newX = Random.Range(xPos, playerPos); // a random point between player and itself

                if ((transform.position.x > playerPos && facingRight) || (transform.position.x < playerPos && !facingRight))
                {
                    Flip(); //flips based on where the player is
                }

            }
            catch
            {
                //if the player is not in the scene
                Debug.Log("No Player");
                newX = xPos + Random.Range(xPos - 100, xPos + 100);
            }

            //moves toward the random point between player and itself
            Vector3 target = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);

            //once it reaches the target the function stops
            if(transform.position == target)
            {
                canMove = false;
            }

        }

    }

    //jump
    public void jump(){
        if (canJump){   
            rb.AddRelativeForce(new Vector2(0f, jumpForce), ForceMode.Impulse); //adds force in the y direction
            rb.velocity = new Vector2(0, 0); //to avoid interference when double jumping
            numberOfJumps--;
        }

    }
    //flips the player in the oposite direction
    public void Flip(){
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //acts as a timer
    IEnumerator Timeout(float i){
        yield return new WaitForSeconds(i);
        canShield = true;
    }

    // checks if the player is on the ground
    private void OnTriggerStay(Collider other){
        canJump = true;
    }

    //set jumps back to 2 when the player hits the ground
    private void OnTriggerEnter(Collider other){
        numberOfJumps = 2;

    }
}
