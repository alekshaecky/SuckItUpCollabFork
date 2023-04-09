using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomBarrier : MonoBehaviour
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
		Debug.Log("Triggered");
		if (other.CompareTag("Player"))
		{
			Debug.Log("Triggered Player");
			SoundBoard.Instance.PlaySFX(AudioIndex);

			if (shockwavePrefab != null)
			{
				Instantiate(shockwavePrefab, transform.position, Quaternion.identity);  // play particle or visual effect
			}
			gameObject.GetComponent<Collider>().enabled = false;

		}
	}
	private void OnTriggerExit(Collider other)
    {
		gameObject.GetComponent<Collider>().enabled = true;
	}
}
