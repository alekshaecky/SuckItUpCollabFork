using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitHUB : MonoBehaviour
{

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {

        
        if (PlayerPrefs.GetInt("PrefsTutorialComplete", 0) == 1) // true
        {
            positionPlayerInHUB();
        }
        else
        {
            positionPlayerInTutorial();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void positionPlayerInHUB()
    {
        player.transform.position = new Vector3(700f, 1241f, -795.5f);
        player.transform.Rotate(new Vector3(0f, -24f, -0f));
    }

    private void positionPlayerInTutorial()
    {
        player.transform.position = new Vector3(698f, 1269f, -799.5f);
        player.transform.Rotate(new Vector3(0f, -54f, -0f));
    }
}
