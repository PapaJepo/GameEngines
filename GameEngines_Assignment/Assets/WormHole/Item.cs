using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private Transform rotater;

    private void Awake()
    {
        rotater = transform.GetChild(0);
    }

    public void Position(Wormhole hole, float curveRotation, float ringRotation)
    {
        //transform.SetParent(hole.prefab)
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
