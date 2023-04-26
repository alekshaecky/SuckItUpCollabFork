using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{

    private GameObject upgradeVFX;
    public AudioClip MySFX;

    private int AudioIndex;


    // Start is called before the first frame update
    void Start()
    {
        AudioIndex = SoundBoard.Instance.AddSoundEffect(MySFX);

        upgradeVFX = GameObject.Find("StarBurstParticles");
        if (upgradeVFX) upgradeVFX.SetActive(false); // turn off the effect now that we have a reference. 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Old version of this function. 
    //private void OnTriggerEnter(Collider other)
    //{
    //    // check Nozzle level
    //    if (PlayerPrefs.GetInt("PrefsTotalScore") < 10000)
    //    {
    //        PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 1);
    //    }
    //    if (PlayerPrefs.GetInt("PrefsTotalScore") < 20000)
    //    {
    //        PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 2);
    //    }
    //    if (PlayerPrefs.GetInt("PrefsTotalScore") < 25000)
    //    {
    //        PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 3);
    //    }
    //    if (PlayerPrefs.GetInt("PrefsTotalScore") < 30000)
    //    {
    //        PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 4);
    //    }
    //    // else bigger than 50000
    //    PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 5);
    //    PlayerPrefs.Save();

    //    upgradeVFX.SetActive(true);
    //    StartCoroutine("waitABit");
    //}


    // Fixed version with correct logic. 
    private void OnTriggerEnter(Collider other)
    {
        float score = PlayerPrefs.GetInt("PrefsTotalScore");

        //if (score >= 40000 ) // 40000+ 
        if (score >= 250000) // 250000+ 
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 5);
        }
        //else if (score >= 30000) //30000 - 39000 
        else if (score >= 50000) //50000 - 249999
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 4);
        }
        //else if (score >= 20000) // 20000 - 29999
        else if (score >= 10000) // 10000 - 49999
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 3);
        }
        //else if (score >= 10000) // 10000 - 19999
        else if (score >= 1000) // 1000 - 9999
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 2);
        }
        else // 0 - 999
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 1);
        }
        PlayerPrefs.Save();
        upgradeVFX.SetActive(true);
        StartCoroutine("waitABit");
    }

    private IEnumerator waitABit()
    {
        yield return new WaitForSeconds(2.0f);
        upgradeVFX.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
