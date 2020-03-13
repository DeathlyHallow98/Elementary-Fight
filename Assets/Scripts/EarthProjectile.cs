using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthProjectile : MonoBehaviour
{
    public GameObject player;
    public float speed = 50;
    public float timer = 0;
    private Transform firepoint;
    private Rigidbody rb; // bullet's rigidbody
    private Transform tr; // bullet's transform
    private float forward; //direction of the bullet
    private bool initiated = false;
    private GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        firepoint = GameObject.FindGameObjectWithTag("EarthElemental").transform.Find("firepoint");
        ground = GameObject.FindGameObjectWithTag("Ground");
        MeshRenderer groundMesh = ground.GetComponent<MeshRenderer>();
        Material groundMaterial = groundMesh.material;
        gameObject.GetComponent<MeshRenderer>().material = groundMaterial;
        forward = transform.right.x * speed;
        rb = gameObject.GetComponent<Rigidbody>();
        tr = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (!initiated)
        {
            transform.position = Vector3.MoveTowards(transform.position, firepoint.position, speed * Time.deltaTime);
        }
       

        if(transform.position == firepoint.position)
        {
            initiated = true;
            timer = 0;
            StartCoroutine(Timeout(0.1f));

            
        }
    }
    IEnumerator Timeout(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        rb.AddForce(new Vector2(forward, tr.position.y), ForceMode.Impulse);
        Destroy(gameObject, 1);


    }
}
