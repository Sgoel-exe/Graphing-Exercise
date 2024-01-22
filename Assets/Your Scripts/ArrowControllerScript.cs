using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControllerScript : MonoBehaviour
{
    public Transform[] arrows;
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
        foreach (Transform arrow in arrows)
        {
            arrow.Translate(Vector3.forward * Time.deltaTime);
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

        float t = 0.166666f;

        foreach (Transform arrow in arrows)
        {
            Vector2 intersectPoint = Vector2.Lerp(targetStart, targetEnd, t);
            arrow.LookAt(intersectPoint);
            t += 0.166666f;
        }
        
    }
}
