using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Attach to an elevator platform to move up and down at steady speed. 
 * Requires an object with a collider at top and bottom to reverse direction. 
 */
public class Elevator : MonoBehaviour
{

    private float speed = 7.0f;
    private Rigidbody rb;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, -speed, 0);
    }


    void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "ElevatorBouncerTop":
                rb.velocity = Vector3.down * speed;
                break;
            case "ElevatorBouncerBottom":
                rb.velocity = Vector3.up * speed;
                break;
            default:
                rb.velocity = Vector3.up * speed;
                break;
        }
    }

    
}
