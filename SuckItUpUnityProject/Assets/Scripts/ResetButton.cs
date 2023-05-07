using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public AudioClip ButtonSFX;
    public int indexSFX;

    bool bYesNo;

    // Start is called before the first frame update
    void Start()
    {
        indexSFX = SoundBoard.Instance.AddSoundEffect(ButtonSFX);
        bYesNo = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // detects tap or mouse click events on the object
    void OnMouseDown()
    {
        SoundBoard.Instance.PlaySFX(indexSFX);
        bYesNo = true;
    }

    // Display Back/Escape Button
    private void OnGUI()
    {

        if (bYesNo == true)
        {
            GUI.backgroundColor = Color.red;

            // test if BACK button pressed
            if (GUI.Button(new Rect(Screen.width - 120 - 100, 300, 145, 50), "RESET SAVEGAME"))
            {
                SoundBoard.Instance.PlaySFX(indexSFX);
                PlayerPrefs.DeleteAll();
                bYesNo = false;
                SceneManager.LoadScene(0);
            }

            // test if REPLAY button pressed
            if (GUI.Button(new Rect(Screen.width - 120 - 100, 365, 145, 50), "CANCEL RESET"))
            {
                SoundBoard.Instance.PlaySFX(indexSFX);
                bYesNo = false;
            }
        }
    }
}
