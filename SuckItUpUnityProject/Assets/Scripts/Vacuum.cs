using UnityEngine;
using System.Collections;

public class Vacuum : MonoBehaviour
{
	// Apply a force to a rigidbody in the Scene at the point
	// where it is clicked.

	// The force with which the target is "poked" when hit.
	
	//public float suckForce;
	//public float powerMultiplier;

	private GameObject NozzleSuckVFX; // Effect indicating nozzle is actively sucking up stuff.
	private GameObject NozzleTrackVFX; // Trail effect indication object is being tracked/sucked.
	private GameObject NozzleSmokeVFX; // Smoke showing when Nozzle is inactive.
	
	public GameObject NozzleDustCloudPrefab; // Dust Cloud on sucked item. 
	private GameObject dustCloud;

	public GameObject FullVFX; // Shows when nozzle is full.


	private int nozzleRank;

	public AudioClip VacuumSFX;                   // vacuum sound
	int VacuumAudioIndex;                  // SoundBoard audio index
	public AudioClip FullSFX;                   // when bag is full sound
	int FullAudioIndex;
	public AudioClip ObjectSuckedSFX;
	int SuckedAudioIndex;
	int Capacity;

	// Start is called before the first frame update
	void Start()
	{
		nozzleRank = PlayerPrefs.GetInt("PrefsCurrentVacuumPower");

		// They are different for each nozzle, so we need to get them.
		// Only 1 Nozzle is active at a time, so this should always get the correct FX for the nozzle.
		NozzleSuckVFX = GameObject.FindWithTag("NozzleSuckVFX");
		//Debug.Log(NozzleSuckVFX);
		NozzleTrackVFX = GameObject.FindWithTag("NozzleTrackVFX");
		NozzleSmokeVFX = GameObject.FindWithTag("NozzleSmokeVFX");

		//--------

		VacuumAudioIndex = SoundBoard.Instance.AddSoundEffect(VacuumSFX);
		SuckedAudioIndex = SoundBoard.Instance.AddSoundEffect(ObjectSuckedSFX);
		FullAudioIndex = SoundBoard.Instance.AddSoundEffect(FullSFX);
		Capacity = GetCapacity();


		if (NozzleSuckVFX) {
			NozzleSuckVFX.SetActive(false);
		}
		if (NozzleTrackVFX) {
			NozzleTrackVFX.SetActive(false);
		}
		if (NozzleSmokeVFX) {
			NozzleSmokeVFX.SetActive(true);
		}
	}

	public int GetCapacity()
	{
		switch (nozzleRank)
        {
			case 1:
				return 100;
			case 2:
				return 1000;
			case 3:
				return 10000;
			case 4:
				return 50000;
			case 5:
				return 100000;
			default:
				Debug.Log("Nozzle Rank is out of Range: " + nozzleRank);
				return 0;
        }
	}

	public bool IsSuckable(float objMass)
	{
		// verify object rigidbody mass is suckable at current nozzleRank
		if (nozzleRank == 1)
		{
			return (objMass < 25f);
		}
		if (nozzleRank == 2)
		{
			return (objMass < 100f);
		}
		if (nozzleRank == 3)
		{
			return (objMass < 1000f);
		}
		if (nozzleRank == 4)
		{
			return (objMass < 10000f);
		}
		// else nozzleRank is 5
		return true;
	}

public float SuckForce(float objMass)
	{
		// verify object rigidbody mass is suckable at current nozzleRank
		if (objMass < 25)
		{
#if UNITY_WEBGL
            return 100f;
#else
			return 10f;
#endif
		}
		if (objMass < 100)
		{
#if UNITY_WEBGL
			return 500f;
#else
			return 50f;
#endif
		}
		if (objMass < 1000)
		{
#if UNITY_WEBGL
            return 7500f;
#else
			return 750f;
#endif
		}
		if (objMass < 10000)
		{
#if UNITY_WEBGL
			return 80000f;
#else
			return 8000f;
#endif
		}
		// else bigger than 10000
#if UNITY_WEBGL
		return 300000f;
#else
		return 30000f;
#endif
	}


	// Update is called once per frame
	void Update()
	{
		int TempScore = PlayerPrefs.GetInt("PrefsTempScore");

		if (Input.GetButtonDown("Fire1"))
		{
			if (TempScore < Capacity)
			{
				SoundBoard.Instance.PlayLoopedSFX(VacuumAudioIndex);
				// Show Nozzle Effect
				if (NozzleSuckVFX)
				{
					NozzleSuckVFX.SetActive(true);
				}
				if (NozzleTrackVFX)
				{
					NozzleTrackVFX.SetActive(true);
				}
				if (NozzleSmokeVFX)
				{
					NozzleSmokeVFX.SetActive(false);
				}
			}
			else
			{
				// play FULL capacity SFX
				Debug.Log("Full capacity");
				SoundBoard.Instance.PlaySFX(FullAudioIndex);
			}
		}

		if (Input.GetButtonUp("Fire1"))
		{
			// needs a parameter for stopping a sound that is playing by index
			SoundBoard.Instance.StopLoopedSFX();
			// Hide Nozzle Effect
			if (NozzleSuckVFX) {
				NozzleSuckVFX.SetActive(false);
			}
			if (NozzleTrackVFX)
			{
				NozzleTrackVFX.SetActive(false);
			}
			if (NozzleSmokeVFX)
			{
				NozzleSmokeVFX.SetActive(true);
			}
		}

		if (Input.GetButton("Fire1"))
		{
			if (TempScore < Capacity)
			{
				RaycastHit hit;
				Ray ray = new Ray(transform.position, transform.forward);

				//Debug.DrawLine(ray.origin, ray.GetPoint(10.0f));

				if (Physics.Raycast(ray, out hit))
				{
					if (hit.rigidbody != null)
					{
						if (IsSuckable(hit.rigidbody.mass))
						{
							// We need to check if the object is moving on its own, in which case it will resists sucking. 
							// So we turn off its "bounce". See Script BallBounce and Balls in Playground. 
							if (hit.transform.gameObject.tag.Contains("Bounce"))
                            {
								hit.transform.gameObject.tag = "NoBounce";
								//Debug.Log("debouncing");
                            }

								// Get the GameObject: hit.transform.gameObject;
								// Instantiate as child: public static Object Instantiate(Object original, Transform parent);
								if (NozzleDustCloudPrefab)
							{
								dustCloud = Instantiate(NozzleDustCloudPrefab, hit.transform);
							}
							hit.rigidbody.AddForceAtPosition(ray.direction * SuckForce(hit.rigidbody.mass) * -1.0f, hit.point);
						}
						else
						{
							//Debug.Log("Not suckable");
						}
					}
					else
					{
						//Debug.Log("Not rigidbody");
					}
				}
				else
				{
					//Debug.Log("No object hit");
				}
			}
			else
			{
				// turn off sfx & vfx we are full
				// check to only turn off if on
				if (NozzleSuckVFX)
				{
					if (NozzleSuckVFX.activeSelf == true)
					{
						SoundBoard.Instance.StopLoopedSFX();
						// Hide Nozzle Effect
						if (NozzleSuckVFX)
						{
							NozzleSuckVFX.SetActive(false);
						}
						if (NozzleTrackVFX)
						{
							NozzleTrackVFX.SetActive(false);
						}
						if (NozzleSmokeVFX) {
							NozzleSmokeVFX.SetActive(true);
						}
						// play FULL capacity SFX
						Debug.Log("Full capacity");
						SoundBoard.Instance.PlaySFX(FullAudioIndex);
					}
				}
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Rigidbody rb;

		// only allow triggering when actually vacuuming
		if (Input.GetButton("Fire1"))
		{
			//Debug.Log("Triggered by " + other.gameObject.name);

			// get the objects rigidbody
			rb = other.gameObject.GetComponent<Rigidbody>();
			// if it has a rigidbody
			if (rb != null)
			{
				// see if rigidbody is affected by physics
				if (rb.isKinematic == false)
				{
					// check if suck force is moving object
					if (rb.velocity.magnitude > 1.0f)
					{
						Debug.Log("vel = " + rb.velocity.magnitude);
						StartCoroutine(ScaleToTargetCoroutine(rb, new Vector3(0.1f, 0.1f, 0.1f), 0.25f));
					}
					else
					{
						Debug.Log("vel = " + rb.velocity.magnitude);
					}
				}
			}
		}
	}

	private IEnumerator ScaleToTargetCoroutine(Rigidbody rbody, Vector3 targetScale, float duration)
	{
		Vector3 startScale = transform.localScale;
		float timer = 0.0f;
		GameObject gObject;

		gObject = rbody.gameObject;
		SoundBoard.Instance.PlaySFX(SuckedAudioIndex);

		while (timer < duration)
		{
			timer += Time.deltaTime;
			float t = timer / duration;
			//smoother step algorithm
			t = t * t * t * (t * (6f * t - 15f) + 10f); // magic here???
			if (gObject != null)
			{
				gObject.transform.localScale = Vector3.Lerp(startScale, targetScale, t);
			}
			yield return null;
		}

		int ScoreAmount = PlayerPrefs.GetInt("PrefsTempScore");
		if (rbody != null)
		{
			ScoreAmount += (int)(rbody.mass);
		}
		PlayerPrefs.SetInt("PrefsTempScore", ScoreAmount);
		PlayerPrefs.Save();
		if (dustCloud != null)
		{
			Destroy(dustCloud);
		}
		if (gObject != null)
		{
			Destroy(gObject);
		}
		yield return null;
	}
}
