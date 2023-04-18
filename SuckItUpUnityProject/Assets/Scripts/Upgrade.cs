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
