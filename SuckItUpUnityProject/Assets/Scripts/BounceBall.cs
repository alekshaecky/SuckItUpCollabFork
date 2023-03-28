using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{

    public AudioClip BounceSFX;
    int BounceAudioIndex;

    public Transform target;
    public float speed = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        BounceAudioIndex = SoundBoard.Instance.AddSoundEffect(BounceSFX);
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.tag)
        {
            case "BounceVertical":
                bounceVertical();
                break;
            case "BounceHorizontalX":
                bounceHorizontalX();
                break;
            case "BounceHorizontalZ":
                bounceHorizontalZ();
                break;
            case "BounceRandom":
                bounceRandom();
                break;
            case "FloatRandom":
                floatRandom();
                break;
            default:
                Debug.Log("Not a ball.");
                break; 
        }
    }

    /* Note: Could just implement one function that bounces on a supplied axis,
     * and a boolean for random, and a float for speed. 
     * I decided this is easier to debug, and easier to understand
     * at a glance.
     */

    /*
     * Bounce vertically between two colliders.
     * Expects gravity to be enabled. 
     * 
     */
    void bounceVertical()
    {
        if (rb.velocity.y < 0) rb.velocity = new Vector3(0, -speed, 0);
        if (rb.velocity.y > 0) rb.velocity = new Vector3(0, speed, 0);
    }
    
    /* Bounce horizontally between two colliders on the X axis.
     * Expcets NO gravity.
     */
    void bounceHorizontalX()
    {
        if (rb.velocity.x <= 0) rb.velocity = new Vector3(-speed, 0, 0);
        if (rb.velocity.x > 0) rb.velocity = new Vector3(speed, 0, 0);
    }

    /* Bounce horizontally between two colliders on the Z axis.
     * Expcets NO gravity.
     */
    void bounceHorizontalZ()
    {
        if (rb.velocity.z <= 0) rb.velocity = new Vector3(0, 0, -speed);
        if (rb.velocity.z > 0) rb.velocity = new Vector3(0, 0, speed);
    }

    /*
     * Bounce in random directions. 
     * Expects gravity to be enabled.
     */
    void bounceRandom()
    {
        
    }

    /*
     * Float randomly in varying directions.
     * Expects NO gravity.
     */
    void floatRandom()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            SoundBoard.Instance.PlaySFX(BounceAudioIndex);
            // Move the Player to Start; nothing is lost.
            if (target != null)
            {
                other.transform.position = target.position;
                other.transform.rotation = target.rotation;
                Physics.SyncTransforms();  // update transforms so Physics and Move controller work properly after teleport

                // Lose Score based on mass of ball
                int TempScore = PlayerPrefs.GetInt("PrefsTempScore");
                TempScore -= (int)rb.mass;
                PlayerPrefs.SetInt("PrefsTempScore", TempScore);
                PlayerPrefs.Save();
            }
        }
    }
}
