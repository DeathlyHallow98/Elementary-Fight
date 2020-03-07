using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    private Transform tr;
    private float scale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();
        tr.localScale = new Vector3(0.81f, scale, 4.42f);
    }
    private void Update()
    {
        if(scale <= 3.0)
        {
            scale += 0.1f;
            tr.localScale = new Vector3(0.81f, scale, 4.42f);
        }
        Destroy(gameObject, 2);
    }
}
