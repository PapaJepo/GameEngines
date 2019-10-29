using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HoverObject : MonoBehaviour
{
    Rigidbody p_rb;
    float p_deadzone = 0.1f;

    public float p_forwardAcl = 100.0f;
    public float p_BackwardAcl = 25.0f;
    float p_currThrust = 0.0f;

    public float p_turnStrength = 10f;
    float p_currturn = 0.0f;

    int p_layerMask;
    public float p_hoverForce = 9.0f;
    public float p_hoverHeight = 2.0f;
    public GameObject[] p_hoverPoints;

    // Start is called before the first frame update
    void Start()
    {
        p_rb = GetComponent<Rigidbody>();

        p_layerMask = 1 << LayerMask.NameToLayer("Characters");
        p_layerMask = ~p_layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        p_currThrust = 0.0f;
        float aclAxis = Input.GetAxis("Vertical");
        /*
        if (aclAxis > p_deadzone)
            p_currThrust = aclAxis * p_forwardAcl;
        else if (aclAxis < -p_deadzone)
            p_currThrust = aclAxis * p_BackwardAcl;
            */
        p_currThrust = aclAxis * p_forwardAcl;
        p_currturn = 0.0f;
        /*
        float turnAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(turnAxis) > p_deadzone)
            p_currturn = turnAxis;*/
    }

    private void FixedUpdate()
    {

        RaycastHit hit;
        /*for (int i = 0; i < p_hoverPoints.Length; i++)
        {
            var hoverPoint = p_hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, p_hoverHeight, p_layerMask))
                p_rb.AddForceAtPosition(Vector3.up * p_hoverForce * (1.0f - (hit.distance / p_hoverHeight)), hoverPoint.transform.position);
            else
            {
                if(transform.position.y > hoverPoint.transform.position.y)
                {
                    p_rb.AddForceAtPosition(hoverPoint.transform.up * p_hoverForce, hoverPoint.transform.position);
                }
                else
                {
                     p_rb.AddForceAtPosition(hoverPoint.transform.up * -p_hoverForce, hoverPoint.transform.position);
                }
            }
        }*/



        //
        if (Mathf.Abs(p_currThrust) > 0)
            p_rb.AddForce(transform.forward * p_currThrust);



        float turnAxis = Input.GetAxis("Horizontal");
        p_rb.AddRelativeTorque(Vector3.up * turnAxis * p_turnStrength);
        /*
        if (p_currturn>0)
        {
            p_rb.AddRelativeTorque(Vector3.up * p_currturn * p_turnStrength);

        }
        else if(p_currturn < 0)
            {
            p_rb.AddRelativeTorque(Vector3.up * p_currturn * p_turnStrength);
        }
        */
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < p_hoverPoints.Length; i++)
        {
            
            Gizmos.DrawSphere(p_hoverPoints[i].transform.position, .1f);
        }
    }
}
