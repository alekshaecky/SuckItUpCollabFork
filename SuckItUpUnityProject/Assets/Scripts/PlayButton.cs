using UnityEngine;
using UnityEngine.SceneManagement;

// Play Button script - to launch the scene in PlayerPrefs
public class PlayButton : MonoBehaviour
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
		SceneManager.LoadScene(PlayerPrefs.GetInt("PrefsStartingSceneIndex", 3));
	}
}
