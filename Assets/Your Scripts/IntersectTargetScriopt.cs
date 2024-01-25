using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntersectTargetScriopt : MonoBehaviour
{
    private float startX;
    private float startY;
    private float endX;
    private float endY;

    private float distance;
    private float velocity;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Generate random start and end points
        startX = Random.Range(-5, 5);
        startY = Random.Range(-3, 3);
        //Make sure the end point is not too close to the start point
        Vector2 pos = Random.Range(1f,4f) * Random.insideUnitCircle.normalized;
        //setEndPoints(pos);
        endX = pos.x;
        endY = pos.y;

        Vector3 start = new Vector3(startX, startY, 0);
        Vector3 end = new Vector3(endX, endY, 0);

        direction = (end - start).normalized;
        //Move the target to the start point and look at the end point
        transform.position = start;

        Debug.Log("Start: " + startX + " " + startY + " End: " + endX + " " + endY);

        //Calculate the velocity based on the distance between the start and end points
        distance = Vector2.Distance(start, end);
        velocity = distance / 6f;
        
        //Debug.Log(velocity);
    }

    // Update is called once per frame
    void Update()
    {
        //Works about 65% of the time
        transform.Translate(Time.deltaTime * velocity * direction);
    }

    void setEndPoints(Vector2 onUnitSphere)
    {
        //Extra measure to make sure that the end points are in the scene.
        if(startX  >= 0)
        {
            endX = - Mathf.Abs(onUnitSphere.x);
        }
        else
        {
            endX = Mathf.Abs(onUnitSphere.x);
        }
        if (startY >= 0)
        {
            endY = -Mathf.Abs(onUnitSphere.y);
        }
        else
        {
            endY = Mathf.Abs(onUnitSphere.y);
        }
    }

    public Vector2 getStartPoint()
    {
        return new Vector2(startX, startY);
    }

    public Vector2 getEndPoint()
    {
        return new Vector2(endX, endY);
    }

    public float getVelocity()
    {
        return velocity;
    }
}
