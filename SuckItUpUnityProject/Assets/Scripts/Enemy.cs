using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	public float AlertDistance;
	public float moveSpeed;
	public int EnemyScore;

	GameObject TargetObject;				// reference to player or target
	Vector3 moveVector;                     // current movement
	AudioClip MyDeathSFX;                   // death sound
	int AudioIndex;							// SoundBoard audio index
	CharacterController EnemyController;    // character controller for movement
	CameraShake cameraShake;                // to make Main Camera shake
	bool bAlive;                            // is enemy alive

	// Start is called before the first frame update
	void Start()
	{
		GameObject camera;

		TargetObject = GameObject.FindGameObjectWithTag("Player");
		EnemyController = GetComponent<CharacterController>();
		AudioIndex = SoundBoard.Instance.AddSoundEffect(MyDeathSFX);
		camera = GameObject.Find("Main Camera");
		cameraShake = camera.GetComponent<CameraShake>();
		bAlive = true;
	}

	// Update is called once per frame
	private void Update()
	{
		float TargetDistance = Vector3.Distance(this.transform.position, TargetObject.transform.position);

		// stay at location until Player moves into AlertDistance
		if (TargetDistance <= AlertDistance)
		{
			// look at target X & Z, but enemy's Y
			Vector3 myLookVec = TargetObject.transform.position;
			myLookVec.y = transform.position.y;
			transform.LookAt(myLookVec);

			// set forward/backward movement based on input
			moveVector = new Vector3(0, 0, moveSpeed * Time.deltaTime);
			// adjust the Y movement based on gravity
			moveVector.y = Physics.gravity.y * Time.deltaTime;
			// move foward or backward based on rotation direction, up or down with gravity
			moveVector = transform.rotation * moveVector;   // multiply by rotation

			// move in the forward facing direction (already rotated toward player), by moveSpeed
			EnemyController.Move(moveVector);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.CompareTag("Player") && bAlive)
		{
			bAlive = false;
			// move off screen hack
			transform.position = new Vector3(transform.position.x, 1000.0f, transform.position.z);

			SoundBoard.Instance.PlaySFX(AudioIndex);

			if (cameraShake != null)
			{
				//shake camera
				StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
			}
			Invoke("Reload", 2);  // wait 2 seconds, then reload level
		}
	}

	void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void OnDestroy()
	{
		if (bAlive == true)
		{
			int Score = PlayerPrefs.GetInt("PrefsScore") + EnemyScore;
			PlayerPrefs.SetInt("PrefsScore", Score);
			PlayerPrefs.Save();
		}
	}
}