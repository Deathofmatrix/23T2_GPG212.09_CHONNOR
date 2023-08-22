using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagentiseUpgrade : MonoBehaviour
{

    // public so can be upgraded via the shop 
    // if we decide o go down that path
    public float detectionRadius = 10f;
    public float attractionForce = 10f;

    void Update()
    {   // moving this to a function outside Update resulted in performance issues. ie. the pickups didn't catch up to the boat
        // this works much better in Update

        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("PickUp"))
            {

                Rigidbody pickUpRB = collider.GetComponent<Rigidbody>();
                if (pickUpRB != null)
                {
                    Vector3 directionToPlayer = (transform.position - collider.transform.position).normalized;
                    pickUpRB.AddForce(directionToPlayer * attractionForce);
                }
            }
        }
    }
}

