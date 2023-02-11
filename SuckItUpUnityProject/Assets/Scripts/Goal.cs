using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
	public GameObject shockwavePrefab;  // set to particle or visual effect
	public AudioClip MySFX;             // set to sound effect to play when goal reached
	int AudioIndex;                     // index value of my sound effect

	private void Start()
	{
		AudioIndex = SoundBoard.Instance.AddSoundEffect(MySFX);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			SoundBoard.Instance.PlaySFX(AudioIndex);

			if (shockwavePrefab != null)
			{
				Instantiate(shockwavePrefab, transform.position, Quaternion.identity);  // play particle or visual effect
			}
			
			// need to set highscore for each level based on current level index

			// store totalscore and reset tempscore
			int TotalScoreAmount = PlayerPrefs.GetInt("PrefsTotalScore") + PlayerPrefs.GetInt("PrefsTempScore");
			PlayerPrefs.SetInt("PrefsTotalScore", TotalScoreAmount);
			PlayerPrefs.SetInt("PrefsTempScore", 0);
			PlayerPrefs.Save();
			SceneManager.LoadScene(PlayerPrefs.GetInt("PrefsStartingSceneIndex")); // loads the HUB
		}
	}
}
