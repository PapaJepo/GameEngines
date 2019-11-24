using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCubes = new GameObject[32];
    public float CircleRadius;
    public float _MaxScale;
    public AudioPeer AudioRef;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <32; i ++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            _instanceSampleCube.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),
      Random.Range(0f, 1f),
      Random.Range(0f, 1f));
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -11.25f * i, 0);
            //this.transform.rotation = new Quaternion(0, 0, 25,1);
            _instanceSampleCube.transform.position = Vector3.forward * 0.4f;
            _sampleCubes[i] = _instanceSampleCube;

        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 15 * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Vertical") * 3, 0);


        for (int i = 0;i < 32;i++)
        {
            if(_sampleCubes != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(0.1f, (AudioRef._samples[i] * _MaxScale) + 0.2f, 0.1f);
            }
        }
    }
}
