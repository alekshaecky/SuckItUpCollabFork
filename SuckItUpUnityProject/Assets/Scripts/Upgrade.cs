using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
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
        // check Nozzle level
        if (PlayerPrefs.GetInt("PrefsTotalScore") < 10000)
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 1);
        }
        if (PlayerPrefs.GetInt("PrefsTotalScore") < 20000)
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 2);
        }
        if (PlayerPrefs.GetInt("PrefsTotalScore") < 25000)
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 3);
        }
        if (PlayerPrefs.GetInt("PrefsTotalScore") < 30000)
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 4);
        }
        // else bigger than 50000
        PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 5);

    }

}
