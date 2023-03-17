using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        // start the music for this scene
        SoundBoard.Instance.PlayMusic(gameMusic);
    }
}
