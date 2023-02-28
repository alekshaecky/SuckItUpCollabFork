using UnityEngine;
using System.Collections;

public class Vacuum : MonoBehaviour
{
    // Apply a force to a rigidbody in the Scene at the point
    // where it is clicked.

    // The force with which the target is "poked" when hit.
    public float suckForce;

    public AudioClip VacuumSFX;                   // vacuum sound
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
            SoundBoard.Instance.PlayLoopedSFX(AudioIndex);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // needs a parameter for stopping a sound that is playing by index
            SoundBoard.Instance.StopLoopedSFX(AudioIndex);
        }

        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            Debug.DrawLine(ray.origin, ray.GetPoint(10.0f));

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
        Rigidbody rb;

        //Debug.Log("Triggered by " + other.gameObject.name);

        // get the objects rigidbody
        rb = other.gameObject.GetComponent<Rigidbody>();
        // if it has a rigidbody
        if (rb != null)
        {
            // see if rigidbody is affected by physics
            if (rb.isKinematic == false)
            {
                StartCoroutine(ScaleToTargetCoroutine(rb, new Vector3(0.1f, 0.1f, 0.1f), 0.5f));
            }
        }
    }

    private IEnumerator ScaleToTargetCoroutine(Rigidbody rbody, Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;
        GameObject gObject;

        gObject = rbody.gameObject;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (6f * t - 15f) + 10f); // magic here???
            gObject.transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        int ScoreAmount = PlayerPrefs.GetInt("PrefsTempScore");
        ScoreAmount += (int)(rbody.mass);
        PlayerPrefs.SetInt("PrefsTempScore", ScoreAmount);
        PlayerPrefs.Save();
        Destroy(gObject);
        yield return null;
    }
}
