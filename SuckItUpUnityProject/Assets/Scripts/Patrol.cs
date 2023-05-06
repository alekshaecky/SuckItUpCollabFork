using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] spots;
    int index = 0;
    Enemy enemy;
    float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        if (enemy != null) 
        {
            speed = enemy.moveSpeed * 0.02f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spots.Length > 0 ) {
            Debug.Log("Spots: " + spots.Length);
            //calc distance to target location
            float dist = Vector3.Distance(transform.position, spots[index].position);
            if (dist < 1)
            {
                index++;
                if (index >= spots.Length) index = 0;

            }
            //Look at movepoint
            transform.LookAt(spots[index]);
            transform.position += transform.forward * speed;
        }
        else
        {
            Debug.Log("No Spots: " + spots.Length);
        }
    }
}
