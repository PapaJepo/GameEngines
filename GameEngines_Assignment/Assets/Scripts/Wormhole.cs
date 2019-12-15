using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public float pipeRadius; //1 of 2 radiuses of the Torus

    public float CurveRadius //1 of 2 radiuses of the Torus
    {
        get
        {
            return curveRadius;
        }
    }

    public float CurveAngle
    {
        get
        {
            return curveAngle;
        }
    }
    
    public int  pipeSegementCount;

    private Vector3 GetPointOnTorus (float u, float v)  //This is the 3D sinusoid function to find the points on the Torus
    {
        Vector3 p;
        float r = (curveRadius + pipeRadius * Mathf.Cos(v));
        p.x = r * Mathf.Sin(u);
        p.y = r * Mathf.Cos(u);
        p.z = pipeRadius * Mathf.Sin(v);
        return p;

    }

    private Mesh mesh;
    private Vector3[] vertices; //The vertices and triangles used for mesh generation
    private int[] triangles;

    public float minCurveRadius, maxCurveRadius;
    public int minCurveSegmentCount, maxCurveSegmentCount;

    private float curveRadius;
    private int curveSegmentCount;

    private void Awake() //The mesh is generated when the object wakes up
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Pipe";

        
    }

    private Vector2[] uv;

    public void Generate()//
    {
        curveRadius = Random.Range(minCurveRadius, maxCurveRadius);
        curveSegmentCount = Random.Range(minCurveSegmentCount, maxCurveSegmentCount + 1);

        mesh.Clear();
        SetVertices();
        SetUV();
        SetTriangles();
        mesh.RecalculateNormals();
    }

    private void SetUV()
    {
        uv = new Vector2[vertices.Length];
        for (int i = 0; i < vertices.Length; i += 4)
        {
            uv[i] = Vector2.zero;
            uv[i + 1] = Vector2.right;
            uv[i + 2] = Vector2.up;
            uv[i + 3] = Vector2.one;
        }
        mesh.uv = uv;
    }

    public float ringDistance;
    private float curveAngle;

    private void SetVertices()//This function is generating quads from 4 vertices
    {
        vertices = new Vector3[pipeSegementCount * curveSegmentCount * 4];
        float uStep = ringDistance / curveRadius;
        curveAngle = uStep * curveSegmentCount * (360f / (2f * Mathf.PI));
        CreateFirstQuadRing(uStep);
        int iDelta = pipeSegementCount * 4;
        for(int u = 2, i = iDelta; u<=curveSegmentCount;u++, i+= iDelta)
        {
            CreateQuadRing(u * uStep, i);
        }
        mesh.vertices = vertices;
    }

    private float relativeRotation;

    public float RelativeRotation //This gets the pipes relative rotation
    {
        get
        {
            return relativeRotation;
        }
    }
    public void AlignWith(Wormhole hole) //This ensures that the transforms don't degrade over time
    {
         relativeRotation = Random.Range(0, curveSegmentCount) * 360f / pipeSegementCount;
        transform.SetParent(hole.transform, false);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0f, 0f, -hole.curveAngle);
        transform.Translate(0f, hole.curveRadius, 0f);
        transform.Rotate(relativeRotation, 0f, 0f);
        transform.Translate(0f, -curveRadius, 0f);

        transform.SetParent(hole.transform.parent);
        transform.localScale = Vector3.one;
    }


    private void CreateQuadRing(float u, int i)//Copies the previous two vertices per quad 
    {
        float vStep = (2f * Mathf.PI) / pipeSegementCount;
        int ringOffset = pipeSegementCount * 4;

        Vector3 vertex = GetPointOnTorus(u, 0f);
        for(int v = 1; v <= pipeSegementCount; v++, i+= 4)
        {
            vertices[i] = vertices[i - ringOffset + 2];
            vertices[i + 1] = vertices[i - ringOffset + 3];
            vertices[i + 2] = vertex;
            vertices[i + 3] = vertex = GetPointOnTorus(u, v * vStep);
        }
    }

    private void CreateFirstQuadRing(float u)//This function assigns vertices to quads as it moves through each section of the Torus
    {
        float vStep = (2f * Mathf.PI) / pipeSegementCount;

        Vector3 vertexA = GetPointOnTorus(0f, 0f);
        Vector3 vertexB = GetPointOnTorus(u, 0f);
        for(int v = 1,i = 0; v <= pipeSegementCount; v++,i+=4)
        {
            vertices[i] = vertexA;
            vertices[i+1] = vertexA = GetPointOnTorus(0f, v * vStep);
            vertices[i + 2] = vertexB;
            vertices[i + 3] = vertexB = GetPointOnTorus(u, v * vStep);
        }
    }

    private void SetTriangles()//Each quad has 6 vertices and 2 triangles
    {
        triangles = new int[pipeSegementCount * curveSegmentCount * 6];
        for(int t = 0, i = 0; t < triangles.Length; t+= 6, i+=4)
        {
            triangles[t] = i;
            triangles[t + 1] = triangles[t + 4] = i + 2;
            triangles[t + 2] = triangles[t + 3] = i + 1;
            triangles[t + 5] = i + 3;
        }
        mesh.triangles = triangles;
    }
   

    /*
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
    */
}
