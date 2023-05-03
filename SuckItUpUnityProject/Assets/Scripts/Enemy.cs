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
	Patrol patrol;

	private Material hitEffect;

	// Start is called before the first frame update
	void Start()
	{
		//GameObject camera;

		TargetObject = GameObject.FindGameObjectWithTag("Player");
		EnemyController = GetComponent<CharacterController>();
		AudioIndex = SoundBoard.Instance.AddSoundEffect(MyDeathSFX);
		//camera = GameObject.Find("Main Camera");
		//cameraShake = camera.GetComponent<CameraShake>();
		cameraShake = Camera.main.gameObject.GetComponent<CameraShake>();
		bAlive = true;
		patrol = GetComponent<Patrol>();

		hitEffect = GameObject.Find("ScreenSplashEffect").GetComponent<Renderer>().material;
	}

	// Update is called once per frame
	private void Update()
	{
		float TargetDistance = Vector3.Distance(this.transform.position, TargetObject.transform.position);

		// stay at location until Player moves into AlertDistance
		if (TargetDistance <= AlertDistance)
		{
			if (patrol && patrol.enabled) patrol.enabled = false;
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
			if (EnemyController)
			{
				EnemyController.Move(moveVector);
			}
            

            
		}
		else
        {
			if (patrol && patrol.enabled == false) patrol.enabled = true;
		}

		if (hitEffect.color.a > 0)
		{
			var color = hitEffect.color;
			color.a -= 0.02f * Time.deltaTime;
			hitEffect.color = color;

			if (hitEffect.color.a <= 0f)
			{
				color.a = 0f; // Need to make sure it's 0
				hitEffect.color = color;
				Reload(); // Unfortunately, there is a delay caused by the Load. 
			}
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

			// Show visual hit effect.
			if (hitEffect)
			{
				// You cannot change the values of color, so you have to get it, change it, and set it.
				var color = hitEffect.color;
				if (color.a == 0f) // because we hit the collider more than once. 
				{
					color.a = 0.6f;
				}
				hitEffect.color = color;
			}
			
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