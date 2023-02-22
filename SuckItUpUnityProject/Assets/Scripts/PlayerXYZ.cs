using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerXYZ : MonoBehaviour
{
    CharacterController playerController;
  
   

    // Start is called beforethe first frame update
    void Start()
    {
        // Store reference for character controller component
        playerController = GetComponent<CharacterController>();
        float Xpos = PlayerPrefs.GetFloat("PrefsPlayerPosX");
        float Ypos = PlayerPrefs.GetFloat("PrefsPlayerPosY");
        float Zpos = PlayerPrefs.GetFloat("PrefsPlayerPosZ");
        transform.position = new Vector3(Xpos, Ypos, Zpos);
        Physics.SyncTransforms(); //update transforms so Physics works after teleport
    }

}
