using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBall : MonoBehaviour
{

    public AudioClip BounceSFX;
    int BounceAudioIndex;

    private Rigidbody rb;
    public Transform target;

    private Image hitEffectImage;


    // Start is called before the first frame update
    void Start()
    {
        BounceAudioIndex = SoundBoard.Instance.AddSoundEffect(BounceSFX);
        rb = this.GetComponent<Rigidbody>();

        hitEffectImage = GameObject.Find("HitEffect").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitEffectImage.color.a > 0)
        {
            var color = hitEffectImage.color;
            color.a -= 0.1f * Time.deltaTime;
            hitEffectImage.color = color;

            if (hitEffectImage.color.a <= 0)
            {
                teleportPlayer();
            }
        }
    }

   void teleportPlayer()
    {
        // Move the Player to Start; nothing is lost.
        if (target != null)
        {
            GameObject p = GameObject.FindWithTag("Player"); // so we don't move just the Crosshair.
                                                             // Teleport the Player, usually back to start.
            p.transform.position = target.position;
            p.transform.rotation = target.rotation;
            Physics.SyncTransforms();  // update transforms so Physics and Move controller work properly after teleport

            // Lose Score based on mass of ball
            int TempScore = PlayerPrefs.GetInt("PrefsTempScore");
            TempScore -= (int)rb.mass;
            if (TempScore < 0) TempScore = 0;
            PlayerPrefs.SetInt("PrefsTempScore", TempScore);
            PlayerPrefs.Save();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Player") || (other.gameObject.name == "Crosshair"))
        {
            // Play a hit sound.
            SoundBoard.Instance.PlaySFX(BounceAudioIndex);

            // Show visual hit effect.
            if (hitEffectImage)
            {
                // You cannot change the values of color, so you have to get it, change it, and set it.
                var color = hitEffectImage.color;
                color.a = 0.8f;
                hitEffectImage.color = color;
            }
        }
    }
}
