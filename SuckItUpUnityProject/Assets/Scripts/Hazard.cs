using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
	public AudioClip HazardSFX;
	public int indexSFX;

	// Start is called before the first frame update
	void Start()
	{
		indexSFX = SoundBoard.Instance.AddSoundEffect(HazardSFX);
	}

	// Update is called once per frame
	private void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SoundBoard.Instance.PlaySFX(indexSFX);
			// need to figure out how to stop the 1st-person player from moving???
			Invoke("Reload", 0.25f);  // wait 1/4 seconds, then reload level
		}
		else
		{
			Destroy(other.gameObject);
		}
	}

	void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}