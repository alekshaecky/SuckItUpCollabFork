﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when the ESCAPE key is pressed
        if(Input.GetKeyDown(KeyCode.Escape))
		{
            SceneManager.LoadScene(0);      // load the MENU scene at index 0
        }
        
    }
}
