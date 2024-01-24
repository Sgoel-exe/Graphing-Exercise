using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControllerScript : MonoBehaviour
{
    public Transform[] arrows;
    private float[] velocities;
    public IntersectTargetScriopt target;
    // Start is called before the first frame update
    void Start()
    {
        randomize();
        setPointsOfIntersection();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].Translate(Vector3.forward * velocities[i] * Time.deltaTime);
        }
        
    }

    void randomize()
    {
        foreach (Transform arrow in arrows)
        {
            arrow.position = new Vector3(Random.Range(-5, 5), Random.Range(-3, 3), 0);
        }

    }

    private void setPointsOfIntersection()
    {
        Vector2 targetStart = target.getStartPoint();
        Vector2 targetEnd = target.getEndPoint();
        velocities = new float[arrows.Length];

        float t = 1f/6f;

        for (int i = 0; i < arrows.Length; i++)
        {
            Vector2 intersectPoint = Vector2.Lerp(targetStart, targetEnd, t);
            arrows[i].LookAt(intersectPoint);
            velocities[i] = Vector2.Distance(arrows[i].position, intersectPoint) / (i+1);
            t += (1f/6f);
        }
        
    }
}
