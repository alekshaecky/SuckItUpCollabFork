using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Bounce a a GameObject with a Collider, a Triggering Collider, 
 * and a Rigidbody around a space delimited by Colliders.
 * 
 * Expects Gravity of Rigidbody to be off, 
 * though turning it might have interesting effects...
 */
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
        switch (gameObject.tag)
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
            case "BounceRandomHorizontal": // Enemy patrol
                bounceRandomHorizontal();
                break;
            case "BounceRandom":
                bounceRandom();
                break;
            case "NoBounce":
                stopBounceVelocity();
                break;
            default:
                //Debug.Log("Not a ball.");
                break; 
        }
    }

    /**
     * Note: Could just implement one function that bounces on a supplied axis,
     * and a boolean for random, and a float for speed. 
     * I decided this is easier to debug, and easier to understand.
     */

    /**
     * As implemented, objects are not very suckable, resisting the pull. 
     * So, once they are being sucked, we change their label in Vacuum.cs to NoBounce. 
     * Then this function is calle to set velocity to 0.
     * IMPORTANT: The ball is now and forever under control of the Vacuum algorithms/physics.
     */
    void stopBounceVelocity()
    {
        rb.velocity = new Vector3(0, 0, 0);
        this.tag = "Untagged";
    }

    /**
     * Bounce vertically between two colliders.
     */
    void bounceVertical()
    {
        if (rb.velocity.y <= 0) rb.velocity = new Vector3(0, -speed, 0);
        if (rb.velocity.y > 0) rb.velocity = new Vector3(0, speed, 0);
    }
    
    /**
     * Bounce horizontally between two colliders on the X axis.
     */
    void bounceHorizontalX()
    {
        if (rb.velocity.x <= 0) rb.velocity = new Vector3(-speed, 0, 0);
        if (rb.velocity.x > 0) rb.velocity = new Vector3(speed, 0, 0);
    }

    /**
     * Bounce horizontally between two colliders on the Z axis.
     */
    void bounceHorizontalZ()
    {
        if (rb.velocity.z <= 0) rb.velocity = new Vector3(0, 0, -speed);
        if (rb.velocity.z > 0) rb.velocity = new Vector3(0, 0, speed);
    }

    /**
     * Basically, patrol and bounce off walls.
     * The randomized speed vector alters the direction.
     */
    void bounceRandomHorizontal()
    {
        if (rb.velocity.z <= 0) rb.velocity = new Vector3(rb.velocity.x, 0, Random.Range(-speed, -speed/2));
        if (rb.velocity.z > 0) rb.velocity = new Vector3(rb.velocity.x, 0, Random.Range(speed/2, speed));

        if (rb.velocity.x <= 0) rb.velocity = new Vector3(Random.Range(-speed, -speed / 2),0, rb.velocity.z);
        if (rb.velocity.x > 0) rb.velocity = new Vector3(Random.Range(speed / 2, speed), 0, rb.velocity.z);
    }


    /*
     * Bounce in random directions. 
     * The randomized speed vector alters the direction.
     */
    void bounceRandom()
    {
        if (rb.velocity.z <= 0) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Random.Range(-speed, -speed / 2));
        if (rb.velocity.z > 0) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, Random.Range(speed / 2, speed));

        if (rb.velocity.x <= 0) rb.velocity = new Vector3(Random.Range(-speed, -speed / 2), rb.velocity.y, rb.velocity.z);
        if (rb.velocity.x > 0) rb.velocity = new Vector3(Random.Range(speed / 2, speed), rb.velocity.y, rb.velocity.z);

        if (rb.velocity.y <= 0) rb.velocity = new Vector3(rb.velocity.x, Random.Range(-speed, -speed / 2), rb.velocity.z);
        if (rb.velocity.y > 0) rb.velocity = new Vector3(rb.velocity.x, Random.Range(speed / 2, speed), rb.velocity.z);
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
                // Teleport the Player, usually back to start.
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
