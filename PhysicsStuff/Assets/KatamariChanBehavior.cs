using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatamariChanBehavior : MonoBehaviour
{
    [HideInInspector]
    public int Score;
    // Start is called before the first frame update

    private Rigidbody rb;
    private List<SpringJoint> removals;
    List<SpringJoint> springJoints = new List<SpringJoint>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //break connections
        if (Input.GetAxis("Jump") != 0)
        {

            foreach (SpringJoint springJoint in springJoints)
            {

                springJoint.breakForce = 0;
                springJoint.breakTorque = 0;

            }
            springJoints.Clear();

        }
        if (Input.GetAxis("Fire1") != 0)
        {
            rb.isKinematic = !rb.isKinematic;
        }
    }

    //attach items when colliding 
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Collectable"))
        {

            other.gameObject.tag = "Collected";
            Score++;


            other.gameObject.AddComponent<SpringJoint>();
            SpringJoint spring = other.gameObject.GetComponent<SpringJoint>();
            spring.connectedBody = this.rb;
            spring.tolerance = 1;
            spring.minDistance = 0;

            spring.maxDistance = 1;
            spring.spring = 10000;
            spring.damper = 10000000000;
            springJoints.Add(spring);
        }
    }
}
