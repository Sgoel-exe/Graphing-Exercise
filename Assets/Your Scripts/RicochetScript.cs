using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RicochetScript : MonoBehaviour
{
    public float[] slopes;
    public float[] yIntercepts;
    public float[] normals;

    private bool collisionTimout = false;
    private float collisionTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        calculateNormals();
    }

    // Update is called once per frame
    void Update()
    {
        //Avoid getting stuck in a line
        if (collisionTimout)
        {
            collisionTimer += Time.deltaTime;
            if (collisionTimer >= Time.fixedDeltaTime)
            {
                collisionTimout = false;
                collisionTimer = 0.0f;
            }
        }
        //Check for collision with lines
        for (int i = 0; i < slopes.Length; i++)
        {
            if (checkCollision(i) && !collisionTimout)
            {
                Debug.Log(transform.forward);
                Vector3 newDirection = Vector3.Reflect(transform.forward, new Vector3(1, normals[i], 0));
                transform.rotation = Quaternion.LookRotation(newDirection) * Quaternion.LookRotation(transform.forward);
                collisionTimout = true;
                break;
            }
        }
        //Continue moving forward
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void calculateNormals()
    {
        for (int i = 0; i < slopes.Length; i++)
        {
            normals[i] = -1 / slopes[i];
        }
    }

    bool checkCollision(int i)
    {
        //Finding the current equation of motion
        float currentSlope = Mathf.Atan2(transform.forward.y, transform.forward.x);
        float currentYIntercept = transform.position.y - (currentSlope * transform.position.x);

        //Finding the point of intersection to the line[i]
        float x = (yIntercepts[i] - currentYIntercept) / (currentSlope - slopes[i]);
        float y = (currentSlope * x) + currentYIntercept;

        if(Vector2.Distance(transform.position, new Vector2(x,y)) <= 0.01f)
        {
            return true;
        }
        return false;
    }
}
