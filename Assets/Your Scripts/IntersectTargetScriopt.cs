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

    // Start is called before the first frame update
    void Start()
    {
        startX = Random.Range(-5, 5);
        startY = Random.Range(-3, 3);
        Vector2 pos = Random.Range(1f,5f) * Random.onUnitSphere;
        setEndPoints(pos);
        transform.position = new Vector3(startX, startY, 0);
    }

    // Update is called once per frame
    void Update()
    {
           this.transform.Translate(new Vector3(endX, endY, 0) * Time.deltaTime);
    }

    void setEndPoints(Vector2 onUnitSphere)
    {
        if(startX  > 0)
        {
            endX = - Mathf.Abs(onUnitSphere.x);
        }
        else
        {
            endX = Mathf.Abs(onUnitSphere.x);
        }
        if (startY > 0)
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
}
