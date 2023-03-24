using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
	public int DoorSceneIndex;			// which scene does this door load
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

			SceneManager.LoadScene(DoorSceneIndex); // loads the classroom
		}
	}
}
