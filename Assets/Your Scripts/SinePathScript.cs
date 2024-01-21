using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinePathScript : MonoBehaviour
{
    private float speed = 0.05f;
    private float x = 0f;
    float curTime = 0f;
    float maxTime = 0.025f;
    private Vector2 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime < maxTime)
        {
            curTime += Time.deltaTime;
            return;
        }
        Move(x);
        setRotation();
        x += speed;
        curTime = 0f;
        lastPos = transform.position;
    }

    float x_func(float degrees)
    {
        return x/Mathf.PI;
    }

    void setRotation()
    {
        float angle = Mathf.Atan2(transform.position.y - lastPos.y, transform.position.x - lastPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(-angle, 90, 0);
    }

    void Move(float x)
    {
        float y = Mathf.Sin(x);
        transform.position = new Vector2(x_func(x), y);
    }
}
