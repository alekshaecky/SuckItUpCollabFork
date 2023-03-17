using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public GameObject PatrolSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // calls method SpawnCreature
            PatrolSpawn.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
