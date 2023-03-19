using UnityEngine;
using System.Collections;

public class Vacuum : MonoBehaviour
{
    // Apply a force to a rigidbody in the Scene at the point
    // where it is clicked.

    // The force with which the target is "poked" when hit.
    public float suckForce;
    public float setForce;
    public float GetCapacity; // should use the PlayerPrefs.GetInt("PrefsCurrentVacuumPower") ???
                              // and multiply that by a variable scaling factor ??
                              // set in the inspector (like capacityMultiplier). ?

    public GameObject SuckVFX;
    public GameObject TrackVFX;
    public GameObject NozzleSmokeVFX;
    public GameObject DustCloudPrefab;
    // TBD: These need to be instantiated instead of variables so we don't
    // have to change it for every single level!

    private GameObject dustCloud;

    public AudioClip VacuumSFX;                   // vacuum sound
    int VacuumAudioIndex;                  // SoundBoard audio index
    public AudioClip ObjectSuckedSFX;
    int SuckedAudioIndex;

    // Start is called before the first frame update
    void Start()
    {
        VacuumAudioIndex = SoundBoard.Instance.AddSoundEffect(VacuumSFX);
        SuckedAudioIndex = SoundBoard.Instance.AddSoundEffect(ObjectSuckedSFX);
        setForce = PlayerPrefs.GetInt("PrefsCurrentVacuumPower"); // times another variable scaling factor
                                                                  // set in the inspector
                                                                  // (like forceMultiplier). 
    }

    // Update is called once per frame
    void Update()
    {
        int Capacity = PlayerPrefs.GetInt("PrefsCurrentVacuumPower");
        int TempScore = PlayerPrefs.GetInt("PrefsTempScore");

        if (Input.GetButtonDown("Fire1") && TempScore < Capacity)
        {
            //SoundBoard.Instance.PlaySFX(AudioIndex);    // needs a parameter for looping 
            SoundBoard.Instance.PlayLoopedSFX(VacuumAudioIndex);
            // Show Nozzle Effect
            if (SuckVFX) SuckVFX.SetActive(true);
            if (TrackVFX) TrackVFX.SetActive(true);
            if (NozzleSmokeVFX) NozzleSmokeVFX.SetActive(false);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // needs a parameter for stopping a sound that is playing by index
            SoundBoard.Instance.StopLoopedSFX();
            // Hide Nozzle Effect
            if (SuckVFX) SuckVFX.SetActive(false);
            if (TrackVFX) TrackVFX.SetActive(false);
            if (NozzleSmokeVFX) NozzleSmokeVFX.SetActive(true);
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
                    // Get the GameObject: hit.transform.gameObject;
                    // Instantiate as child: public static Object Instantiate(Object original, Transform parent);
                    if (DustCloudPrefab)
                    {
                        dustCloud = Instantiate(DustCloudPrefab, hit.transform);
                    }
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
                    StartCoroutine(ScaleToTargetCoroutine(rb, new Vector3(0.1f, 0.1f, 0.1f), 0.25f));
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
