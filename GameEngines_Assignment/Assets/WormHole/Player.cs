using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HolePrefab holePrefab;
    public float velocity;
    private Wormhole currentHole;
    // Start is called before the first frame update
    void Start()
    {
        currentHole = holePrefab.SetupFirstPipe();
        deltaRotation = 360f / (2f * Mathf.PI * currentHole.CurveRadius);
    }

    private float distanceTravelled;
    private float deltaRotation;
    private float systemRotation;
    // Update is called once per frame
    void Update()
    {
        float delta = velocity * Time.deltaTime;
        distanceTravelled += delta;
        systemRotation += delta * deltaRotation;

        if(systemRotation >= currentHole.CurveAngle)
        {
            delta = (systemRotation - currentHole.CurveAngle) / deltaRotation;
            currentHole = holePrefab.SetupNextPipe();
            deltaRotation = 360f / (2f * Mathf.PI * currentHole.CurveRadius);
            systemRotation = delta * deltaRotation;
        }

        holePrefab.transform.localRotation = Quaternion.Euler(0f, 0f, systemRotation);
    }
}
