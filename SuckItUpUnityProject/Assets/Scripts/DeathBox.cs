using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
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
			SoundBoard.Instance.PlaySFX(AudioIndex);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
        {
			// Don't let floating Junk get stuck inside or below the Deathbox. 
			// Just bounce it back up. 
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
			rb.velocity = -rb.velocity;
		}
	}
}
