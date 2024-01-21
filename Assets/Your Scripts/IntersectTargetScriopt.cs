using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntersectTargetScriopt : MonoBehaviour
{
    // Start is called before the first frame update
    private float slope = 0f;
    private float yIntercept = 0f;

    private float speed = 0.05f; 
    private float x = 0f;
    private float curTime = 0f;
    private bool ShouldAdd = true;
    void Start()
    {
        randomize();
        if(x >= 0)
        {
            ShouldAdd = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(curTime >= speed)
        {
            transform.position = new Vector2(line_func(x), x);
            x = ShouldAdd ? x + speed : x - speed;
            curTime = 0f;
        }
        else
        {
            curTime += Time.deltaTime;
        }
        
        
    }

    float line_func(float x)
    {
        return slope * x + yIntercept;
    }

    void randomize()
    {
        float y = Random.Range(-3f, 3f);
        x = Random.Range(-5f, 5f);
        transform.position = new Vector2(x, y);
        slope = Random.Range(0f, 360f);
        slope = Mathf.Tan(slope * Mathf.Deg2Rad);
        yIntercept = y - slope * x;
    }
}
