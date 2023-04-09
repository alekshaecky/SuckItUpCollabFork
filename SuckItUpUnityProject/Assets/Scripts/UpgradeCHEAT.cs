using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCHEAT : MonoBehaviour
{

    public AudioClip BlingSFX;                   // vacuum sound
    int BlingAudioIndex;                  // SoundBoard audio index
    private bool collidable;

    // Start is called before the first frame update
    void Start()
    {
        BlingAudioIndex = SoundBoard.Instance.AddSoundEffect(BlingSFX);
        collidable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
      
        //  This code can be simplified but I can place 23 pieces of junk in that time.
        if (collidable)
        {
            collidable = false;
            switch (PlayerPrefs.GetInt("PrefsCurrentVacuumPower"))
            {
                case 1:
                    PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 2);
                    break;
                case 2:
                    PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 3);
                    break;
                case 3:
                    PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 4);
                    break;
                case 4:
                    PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 5);
                    break;
                default:
                    PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 1);
                    break;
            }
            SoundBoard.Instance.PlaySFX(BlingAudioIndex);
        }
        collidable = false;

        // Need to prevent multiple triggering events.
        // So we add a cooldown.
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5);
        collidable = true;
    }

}
