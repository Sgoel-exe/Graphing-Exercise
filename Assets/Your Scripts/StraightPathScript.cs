using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPathScript : MonoBehaviour
{
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }
}
