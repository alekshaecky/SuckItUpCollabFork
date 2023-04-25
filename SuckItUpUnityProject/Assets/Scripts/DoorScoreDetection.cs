using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScoreDetection : MonoBehaviour
{
    public Transform player;
    public int DoorDestroy = 150;
    public float range = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < range)
        {
            var score = PlayerPrefs.GetInt("PrefsTempScore");
            if (score >= DoorDestroy)
            {
                Debug.Log("Door Destroyed");
                Destroy(gameObject);
            }
            
            Debug.Log("Score High" + score);
        }
    }
}
