using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport1 : MonoBehaviour
{

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // check if the name of the object is "Player"
        if (other.gameObject.name == "First Person Controller")
        {
            Debug.Log("New Scene");
            // reload current level using the scenemanager
            SceneManager.LoadScene("Class1");
            PlayerPrefs.SetFloat("PrefsPlayerPosX", transform.position.x);
            PlayerPrefs.SetFloat("PrefsPlayerPosY", transform.position.y + 1);
            PlayerPrefs.SetFloat("PrefsPlayerPosZ", transform.position.z - 3);
            PlayerPrefs.Save();



        }


    }

}
