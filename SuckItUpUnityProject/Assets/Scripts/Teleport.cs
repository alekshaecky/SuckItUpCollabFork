using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform target;
    public AudioClip MySFX;
    public GameObject teleportFXPrefab;
    int AudioIndex;

    private Transform parent;
    private GameObject tp;
    private bool teleporting = false;

    private void Start()
    {
        AudioIndex = SoundBoard.Instance.AddSoundEffect(MySFX);
        parent = GameObject.Find("Crosshair").transform;
        // Because things aren't properly set up with Prefabs for all doors, it's pretty impossible to find and maintain
        // all of them and make sure the FX is added to the script. This is the foolproof way of adding the FX. 
        teleportFXPrefab = Resources.Load<GameObject>("TeleportFX");
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player") & (target != null))
        {
            if (!teleporting)
            {
                teleporting = true;
                tp = Instantiate(teleportFXPrefab, parent);
                StartCoroutine("teleportFX");
            }

            other.transform.position = target.position;
            other.transform.rotation = target.rotation;
            Physics.SyncTransforms();  // update transforms so Physics and Move controller work properly after teleport
            SoundBoard.Instance.PlaySFX(AudioIndex);


        }
        else
        {
            Debug.Log("No target transform for " + this.gameObject.name);
        }
    }
    private IEnumerator teleportFX() {
        yield return new WaitForSeconds(1.0f);
        Destroy(tp);
        teleporting = false;

    }
}