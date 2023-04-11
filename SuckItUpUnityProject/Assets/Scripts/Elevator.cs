using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Attach to an elevator platform to move up and down at steady speed. 
 * Requires an object with a collider at top and bottom to reverse direction. 
 */
public class Elevator : MonoBehaviour
{

    private float speed = 5.0f;
    private Rigidbody rb;
    //private GameObject player;
    //private Rigidbody prb;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, -speed, 0);
    }

    void moveDown()
    {
        rb.velocity = Vector3.down * speed;
    }

    void moveUp()
    {
        rb.velocity = Vector3.up * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "ElevatorBouncerTop":
                rb.velocity = Vector3.zero;
                Invoke("moveDown", 3);
                break;
            case "ElevatorBouncerBottom":
                rb.velocity = Vector3.zero;
                Invoke("moveUp", 3);
                break;
            default:
                break;
        }
    }

    
}
