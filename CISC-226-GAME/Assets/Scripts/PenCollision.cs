using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PenCollision : MonoBehaviour
{
    public string allowedTag;
    public Transform Pig;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pig"))
        {
            Physics.IgnoreCollision(Pig.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else
        {
            // Object does not have the allowed tag, block it from entering the pen
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Object blocked from entering pen.");
        }
    }

}

