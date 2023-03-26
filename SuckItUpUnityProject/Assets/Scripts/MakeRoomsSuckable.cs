using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is called when you hit the collider on the Final Platform. 
 * - Going to the final platform is a one-way trip. 
 * - You have to have Nozzle5 equipped for this to do anything, but no harm if the script runs otherwise. 
 * - Since the room completely resets for re-entry, nothing to undo. 
 * - Every object that we need to convert has a Tag "MakeSuckable". 
 * - We need to 
 *         1. Change the Mesh to be Convex
 *         2. Add a Rigidbody, Mass = 10000, No Gravity
 */

public class MakeRoomsSuckable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Test if it's the Player. Because there may be other stuff flying around. 
        // Get all GameObjects with Tag MakeSuckable. 
        // Get their MeshCollider. (GetComponent<MeshCollider>)
        // set convex to true. 
        // Add a Rigidbody - SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        // Set mass to 10000
        // Uncheck Gravity
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
