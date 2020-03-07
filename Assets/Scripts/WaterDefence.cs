using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDefence : MonoBehaviour
{
    
    public GameObject projPreFab; //the prefab you want (selected from the game menu)
    // Update is called once per frame
    void Update()
    {
        GameObject shieldExist = GameObject.FindGameObjectWithTag("waterShield");
        if (Input.GetKeyDown(KeyCode.C) && shieldExist == null)
        {
            
            Instantiate(projPreFab, transform.position, transform.rotation);
        }
    }

}
