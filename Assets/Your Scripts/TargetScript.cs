using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        if(Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        }  
    }
}
