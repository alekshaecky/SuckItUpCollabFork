using UnityEngine;

public class Vacuum : MonoBehaviour
{
    // Apply a force to a rigidbody in the Scene at the point
    // where it is clicked.

    // The force with which the target is "poked" when hit.
    public float suckForce;

    AudioClip VacuumSFX;                   // vacuum sound
    int AudioIndex;                  // SoundBoard audio index

    // Start is called before the first frame update
    void Start()
    {
        AudioIndex = SoundBoard.Instance.AddSoundEffect(VacuumSFX);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SoundBoard.Instance.PlaySFX(AudioIndex);    // needs a parameter for looping 
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // needs a parameter for stopping a sound that is playing by index
        }

        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            //Debug.DrawLine(ray.origin, ray.GetPoint(10.0f));

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(ray.direction * suckForce * -1.0f, hit.point);
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
    }

	private void OnTriggerEnter(Collider other)
	{
        //Debug.Log("Triggered by " + other.gameObject.name);

        // if we are actually vacuuming then test if "other" is suckable
        if (Input.GetButton("Fire1"))
        {
            // get the objects rigidbody
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            // if it has a rigidbody
            if (rb != null)
            {
                // see if rigidbody is affected by physics
                if (rb.isKinematic == false)
                {
                    int ScoreAmount = PlayerPrefs.GetInt("PrefsTempScore");
                    ScoreAmount += (int)(rb.mass);
                    PlayerPrefs.SetInt("PrefsTempScore", ScoreAmount);
                    PlayerPrefs.Save();
                    Destroy(other.gameObject);
                }
            }
		}
    }
}
