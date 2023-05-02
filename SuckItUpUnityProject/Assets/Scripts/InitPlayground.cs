using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // If Nozzle Level is less than 5, deactivate the teleporter and final exit. 
        if (PlayerPrefs.GetInt("PrefsCurrentVacuumPower") < 5)
        {
            // Disable final teleporter
            GameObject.Find("TeleporterFinal").SetActive(false);
            // Disable final exit
            GameObject.Find("LevelExitArchFinal").SetActive(false);
        }
        // If Nozzle Level is less than 3, deactivate ObstacleCourse shortcut teleporter. 
        if (PlayerPrefs.GetInt("PrefsCurrentVacuumPower") < 3)
        {
            GameObject.Find("TeleporterObstacleShortcut").SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
