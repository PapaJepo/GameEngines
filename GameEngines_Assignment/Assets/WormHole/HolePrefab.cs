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
            if(i>0)
            {
                hole.AlignWith(holes[i - 1]);
            }
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
