using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),
      Random.Range(0f, 1f),
      Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        for (float i = 0; i < 360f; i = i + 0.1f)
        {
            //GetComponent<Light>().color = Color.h
        }

       // GetComponent<Light>().color = Color.RGBToHSV

       
    }

}
