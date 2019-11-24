using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public float curveRadius, pipeRadius;

    public int curveSegmentCount, pipeSegementCount;

    private Vector3 GetPointOnTorus (float u, float v)
    {
        Vector3 p;
        float r = (curveRadius + pipeRadius * Mathf.Cos(v));
        p.x = r * Mathf.Sin(u);
        p.y = r * Mathf.Cos(u);
        p.z = pipeRadius * Mathf.Sin(v);
        return p;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnDrawGizmos()
    {
        float uStep = (2f * Mathf.PI) / curveSegmentCount;
        float vStep = (2f * Mathf.PI) / pipeSegementCount;
        for (int u = 0; u < curveSegmentCount; u++)
        {
            for (int v = 0; v < pipeSegementCount; v++)
            {
                Vector3 point = GetPointOnTorus(u * uStep, v * vStep);
                Gizmos.color = new Color(1f, (float)v / pipeSegementCount, (float)u / curveSegmentCount);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
