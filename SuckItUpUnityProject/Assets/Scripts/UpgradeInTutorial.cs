using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeInTutorial : MonoBehaviour
{


    private GameObject upgradeVFX;

    public AudioClip successSFX;
    public AudioClip failSFX;
    private int upgradeAudioIndex;
    private int failAudioIndex;

    public GameObject tutorialExit;

    // Start is called before the first frame update
    void Start()
    {
        upgradeAudioIndex = SoundBoard.Instance.AddSoundEffect(successSFX);
        failAudioIndex = SoundBoard.Instance.AddSoundEffect(failSFX);

        upgradeVFX = GameObject.Find("StarBurstParticles");
        if (upgradeVFX) upgradeVFX.SetActive(false); // turn off the effect now that we have a reference. 

        if (PlayerPrefs.GetInt("PrefsCurrentVacuumPower") < 2) {
            tutorialExit.SetActive(false);
        }
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        int score = PlayerPrefs.GetInt("PrefsTempScore");
        int currentVaccumPower = PlayerPrefs.GetInt("PrefsCurrentVacuumPower");
        int newVaccumPower = 1;


        if (score >= 4000)
        {
            //tutorialExit.SetActive(true); 
            string youAreAWinnerMessage = "You've finished the Tutorial! Exit and Play!";
            GameObject.Find("Alert").GetComponent<Alert>().SetAlertText(youAreAWinnerMessage);
        }
        else if (score >= 500)
        {
            newVaccumPower = 4;
        }
        else if (score >= 75) 
        {
            newVaccumPower = 3;
        }
        else if (score >= 7) 
        {
            newVaccumPower = 2;
        }
        else // 0 - 999
        {
            newVaccumPower = 1;
            tutorialExit.SetActive(true);
            string youAreAWinnerMessage = "Tutorial Exit activated. Keep practicing or exit to Play.";
            GameObject.Find("Alert").GetComponent<Alert>().SetAlertText(youAreAWinnerMessage);
        }

        if (newVaccumPower > currentVaccumPower)
        {
            PlayerPrefs.SetInt("PrefsCurrentVacuumPower", newVaccumPower);
            PlayerPrefs.Save();
            upgradeVFX.SetActive(true);
            // Play an Upgrade sound
            SoundBoard.Instance.PlaySFX(upgradeAudioIndex);
            GameObject.Find("Alert").GetComponent<Alert>().SetAlertText("Upgraded from: " + currentVaccumPower + " to: " + newVaccumPower + "!");
            StartCoroutine("waitABit");
        }
        else
        {
            // Play a Sorry Sound. 
            SoundBoard.Instance.PlaySFX(failAudioIndex);
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
