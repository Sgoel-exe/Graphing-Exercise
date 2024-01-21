using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPathScript : MonoBehaviour
{
    private float x;
    private float y;
    private float speed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(-45,90,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (y > 1f)
        {
            y = -1f;
            transform.position = new Vector3(x, y, 0);
        }
        transform.position = new Vector3(x, y, 0);
        x += speed;
        y += speed;
        
    }
}
