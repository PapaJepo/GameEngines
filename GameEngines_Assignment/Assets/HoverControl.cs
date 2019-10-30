using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverControl : MonoBehaviour
{

    public float p_forwardAcl = 100.0f;
    public float p_BackwardAcl = 25.0f;
    float p_currThrust = 0.0f;

    public float p_turnStrength = 10f;
    float p_currturn = 0.0f;

    //

    public float hoverHeight = 1.5f;
    public float maxGroundDist = 5f;
    public float hoverForce = 300f;
    public LayerMask whatIsGround;
    public PIDcontroller hoverPID;
    //

    public float hoverGravity = 20f;

    Rigidbody rb;
    bool isOnGround;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        p_currThrust = 0.0f;
        float aclAxis = Input.GetAxis("Vertical");
        p_currThrust = aclAxis * p_forwardAcl;
        p_currturn = 0.0f;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(p_currThrust) > 0)
            rb.AddForce(transform.forward * p_currThrust);


        float turnAxis = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(Vector3.up * turnAxis * p_turnStrength);
        Hover();
    }


    void Hover()
    {
        Vector3 groundNormal;
        Ray ray = new Ray(transform.position, -transform.up * 10);
        Debug.DrawRay(transform.position, -transform.up * 10, Color.blue);
        RaycastHit hitInfo;
        isOnGround = Physics.Raycast(ray, out hitInfo, maxGroundDist, whatIsGround);

        if (isOnGround)
        {
           // transform.position = transform.position + new Vector3(0, hitInfo.distance, 0);
            Debug.Log(isOnGround);

            float height = hitInfo.distance;
            groundNormal = hitInfo.normal.normalized;

            float forcePercent = hoverPID.Seek(hoverHeight, height);

            Vector3 force = groundNormal * hoverForce * forcePercent;
            Vector3 gravity = -groundNormal * hoverGravity * height;

            rb.AddForce(force, ForceMode.Acceleration);
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}
