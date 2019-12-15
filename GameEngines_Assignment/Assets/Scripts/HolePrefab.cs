using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolePrefab : MonoBehaviour
{
    public Wormhole holePrefab;

    public int holeCount;

    private Wormhole[] holes;

    private void Awake()
    {
        holes = new Wormhole[holeCount];
        for(int i = 0; i < holes.Length; i++)
        {
            Wormhole hole = holes[i] = Instantiate<Wormhole>(holePrefab);
            hole.transform.SetParent(transform, false);
            hole.Generate();
            if(i>0)
            {
                hole.AlignWith(holes[i - 1]);
            }
        }
    }

    public Wormhole SetupFirstPipe()
    {
        transform.localPosition = new Vector3(0f, -holes[0].CurveRadius);
        return holes[0];
    }

    public Wormhole SetUpNextPipe()
    {
        ShiftPipes();
        AlignNextPipeWithOrigin();
        holes[holes.Length - 1].Generate();
        holes[holes.Length - 1].AlignWith(holes[holes.Length - 2]);
        transform.localPosition = new Vector3(0f, -holes[0].CurveRadius);
        return holes[0];
    }

    private void ShiftPipes()
    {
        Wormhole temp = holes[0];
        for(int i = 1; i < holes.Length; i++)
        {
            holes[i - 1] = holes[i];
        }
        holes[holes.Length - 1] = temp;
    }

    private void AlignNextPipeWithOrigin()
    {
        Transform transformToAlign = holes[0].transform;
        for(int i =1; i < holes.Length; i++)
        {
            holes[i].transform.SetParent(transformToAlign);

        }

        transformToAlign.localPosition = Vector3.zero;
        transformToAlign.localRotation = Quaternion.identity;

        for(int i = 1; i < holes.Length; i++)
        {
            holes[i].transform.SetParent(transform);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
