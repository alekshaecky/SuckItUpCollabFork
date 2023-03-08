using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnmonster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // calls method SpawnCreature
            SpawnCreature();
        }
            
    }
    void SpawnCreature()
    {
        Vector2 rand = Random.insideUnitCircle;
        Vector3 alert = transform.position + new Vector3(rand.x, 0, rand.y);
        Instantiate(spawnmonster, alert, Quaternion.identity);
    }

}
