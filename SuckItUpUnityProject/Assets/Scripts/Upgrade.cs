using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{

    private GameObject upgradeVFX;

    public AudioClip successSFX;
    public AudioClip failSFX;
    private int upgradeAudioIndex;
    private int failAudioIndex;

    // Start is called before the first frame update
    void Start()
    {
        upgradeAudioIndex = SoundBoard.Instance.AddSoundEffect(successSFX);
        failAudioIndex = SoundBoard.Instance.AddSoundEffect(failSFX);

        upgradeVFX = GameObject.Find("StarBurstParticles");
        if (upgradeVFX) upgradeVFX.SetActive(false); // turn off the effect now that we have a reference. 
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int score = PlayerPrefs.GetInt("PrefsTotalScore");
        int currentVaccumPower = PlayerPrefs.GetInt("PrefsCurrentVacuumPower");
        int newVaccumPower;

        if (score >= 250000) // 250000+ 
        {
            newVaccumPower = 5;
        }
        else if (score >= 50000) //50000 - 249999
        {
            newVaccumPower = 4;
        }
        else if (score >= 10000) // 10000 - 49999
        {
            newVaccumPower = 3;
        }
        else if (score >= 1000) // 1000 - 9999
        {
            newVaccumPower = 2;
        }
        else // 0 - 999
        {
            newVaccumPower = 1;
        }

        if (newVaccumPower > currentVaccumPower) {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", newVaccumPower);
            PlayerPrefs.Save();
            upgradeVFX.SetActive(true);
            // Play an Upgrade sound
            if (upgradeAudioIndex != null) {
                SoundBoard.Instance.PlaySFX(upgradeAudioIndex);
            }
            GameObject.Find("Alert").GetComponent<Alert>().SetAlertText("Upgraded from: " + currentVaccumPower + " to: " + newVaccumPower + "!");
            StartCoroutine("waitABit");
        }
        else
        {
            // Play a Sorry Sound. 
            if (failAudioIndex != null)
            {
                SoundBoard.Instance.PlaySFX(failAudioIndex);
            }
            GameObject.Find("Alert").GetComponent<Alert>().SetAlertText("Vacuum more to upgrade!");
        }
    }

    private IEnumerator waitABit()
    {
        yield return new WaitForSeconds(2.0f);
        upgradeVFX.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
