using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCubes = new GameObject[128];
    public float CircleRadius;
    public float _MaxScale;
    public AudioPeer AudioRef;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <128; i ++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -2.8125f * i, 0);
            //this.transform.rotation = new Quaternion(0, 0, 25,1);
            _instanceSampleCube.transform.position = Vector3.forward * 1f;

            _sampleCubes[i] = _instanceSampleCube;

        }

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < 128;i++)
        {
            if(_sampleCubes != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(0.6f, (AudioRef._samples[i] * _MaxScale) + 0.5f, 0.6f);
            }
        }
    }
}
