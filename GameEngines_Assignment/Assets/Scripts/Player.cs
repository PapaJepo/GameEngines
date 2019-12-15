using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HolePrefab holePrefab;
    public float velocity;
    private Wormhole currentHole;
    private Transform world, rotater;
    private float worldRotation, avatarRotation;
    public float rotationVelocity;
    // Start is called before the first frame update
    void Start()
    {
        world = holePrefab.transform.parent;
        rotater = transform.GetChild(0);
        currentHole = holePrefab.SetupFirstPipe();
        //deltaRotation = 360f / (2f * Mathf.PI * currentHole.CurveRadius);
        SetUpCurrentHole();
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
            currentHole = holePrefab.SetUpNextPipe();
            // deltaRotation = 360f / (2f * Mathf.PI * currentHole.CurveRadius);
            SetUpCurrentHole();
            systemRotation = delta * deltaRotation;
        }

        holePrefab.transform.localRotation = Quaternion.Euler(0f, 0f, systemRotation);

        UpdateAvatarRotation();
    }

    private void SetUpCurrentHole()
    {
        deltaRotation = 360f / (2f * Mathf.PI * currentHole.CurveRadius);
        worldRotation += currentHole.RelativeRotation;
        if(worldRotation < 0f)
        {
            worldRotation += 360f;
        }
        else if(worldRotation >= 360f)
        {
            worldRotation -= 360f;
        }
        world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }

    private void UpdateAvatarRotation()
    {
        avatarRotation +=
        rotationVelocity * Time.deltaTime * Input.GetAxis("Horizontal");
        if (avatarRotation < 0f)
        {
            avatarRotation += 360f;
        }
        else if (avatarRotation >= 360f)
        {
            avatarRotation -= 360f;
        }
        rotater.localRotation = Quaternion.Euler(avatarRotation, 0f, 0f);
    }
}
