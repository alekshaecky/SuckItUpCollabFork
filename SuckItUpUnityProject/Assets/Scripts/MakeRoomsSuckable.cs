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

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Final Target Triggered. TriggerExit");
        // Test if it's the Player. Because there may be other stuff flying around. 
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Final Target Triggered by Player.");
            // Get all GameObjects with Tag MakeSuckable. 
            GameObject[] rooms = GameObject.FindGameObjectsWithTag("MakeSuckable");
            //Debug.Log("Number of Rooms: " + rooms.Length);
            foreach (GameObject room in rooms)
            {
                room.GetComponent<MeshCollider>().convex = true;
                room.AddComponent<Rigidbody>();
                Rigidbody rb = room.GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.mass = 1.0f;

            }
            // Now we poof all the teleporters and targets.
            // They are not suckable because they are too small to see. 

            GameObject[] tps = GameObject.FindGameObjectsWithTag("Teleporter");
            foreach (GameObject teleporter in tps) {
                Destroy(teleporter); 
            }

            GameObject[] tgs = GameObject.FindGameObjectsWithTag("Target");
            foreach (GameObject target in tgs)
            {
                Destroy(target);
            }

            GameObject[] stairs = GameObject.FindGameObjectsWithTag("Stairs");
            foreach (GameObject stair in stairs)
            {
                Destroy(stair);
            }
        }
    }

}
