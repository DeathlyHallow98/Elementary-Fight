using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShield : MonoBehaviour
{
    private float scale = 0f;
    private GameObject ground;
    private Transform earthElemental;
    void Start()
    {
        transform.localScale = new Vector3(1.7f, scale, 1.7f);
        ground = GameObject.FindGameObjectWithTag("Ground");
        earthElemental = GameObject.FindGameObjectWithTag("EarthElemental").transform;
        MeshRenderer groundMesh = ground.GetComponent<MeshRenderer>();
        Material groundMaterial = groundMesh.material;
        gameObject.transform.Find("EarthShield").GetComponent<MeshRenderer>().material = groundMaterial;
    }
    private void Update()
    {
        if (scale <= 1.5f)
        {
            scale += 0.2f;
            transform.localScale = new Vector3(1.7f, scale, 1.7f);
        }

        transform.Find("EarthShield").transform.position = earthElemental.position ;
        Destroy(gameObject, 10);
    }
}
