using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretMenuButton : MonoBehaviour
{
    public AudioClip ButtonSFX;
    public int indexSFX;

    // Start is called before the first frame update
    void Start()
    {
        indexSFX = SoundBoard.Instance.AddSoundEffect(ButtonSFX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // detects tap or mouse click events on the object
    void OnMouseDown()
    {
        SoundBoard.Instance.PlaySFX(indexSFX);
        SceneManager.LoadScene(1);
    }
}
