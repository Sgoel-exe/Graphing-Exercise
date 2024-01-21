using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPAthScript : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor((transform.position - target.position).magnitude * 100 ) == 0f)
        {
            return;
        }
        lookAtTarget();
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        
    }

    void lookAtTarget()
    {
        transform.LookAt(target);
    }
}
