using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNozzle : MonoBehaviour
{
	// All Nozzles must be active at Start!!!
	// Doing this programmatically so it easily works for all the levels. 
	// Normally, we would instantiate the correct Nozzle and put it in the right place. That's the easy way!
	// The next easy way is to have public game objects for the nozzles; but then every level has to set that up.
	// But the way this is set up right now, is that we get the named game objects and set them. Not very efficient. 

	private GameObject Nozzle1;
	private GameObject Nozzle01;
	private GameObject Nozzle2;
	private GameObject Nozzle3;
	private GameObject Nozzle4;
	private GameObject Nozzle04;
	private GameObject Nozzle5;
	private GameObject Nozzle05;


    // Start is called before the first frame update
    void Start()
    {
		// All Nozzles must be active at Start!!!

		Nozzle1 = GameObject.Find("Nozzle1");
		Nozzle01 = GameObject.Find("Nozzle01");
		Nozzle2 = GameObject.Find("Nozzle2");
		Nozzle3 = GameObject.Find("Nozzle3");
		Nozzle4 = GameObject.Find("Nozzle4");
		Nozzle04 = GameObject.Find("Nozzle04");
		Nozzle5 = GameObject.Find("Nozzle5");
		Nozzle05 = GameObject.Find("Nozzle05");

		// After we get a reference, deactivate them. 
		deactivateNozzles();

		switch (PlayerPrefs.GetInt("PrefsCurrentVacuumPower"))
		{
			case 1:
				//Activate Nozzle 1.
				Nozzle01.SetActive(true);
				break;
			case 2:
				//Activate Nozzle 2.
				Nozzle2.SetActive(true);
				break;
			case 3:
				//Activate Nozzle 3.
				Nozzle3.SetActive(true);
				break;
			case 4:
				//Activate Nozzle 4.
				//Nozzle04.SetActive(true);
				Nozzle4.SetActive(true);
				break;
			case 5:
				//Activate Nozzle 5.
				//Nozzle05.SetActive(true);
				Nozzle5.SetActive(true);
				break;
			default:
				//Activate Nozzle 1.
				Nozzle01.SetActive(true);
				break;
		}
	}

	private void deactivateNozzles()
    {
		Nozzle1.SetActive(false);
		Nozzle01.SetActive(false);
		Nozzle2.SetActive(false);
		Nozzle3.SetActive(false);
		Nozzle4.SetActive(false);
		Nozzle04.SetActive(false);
		Nozzle5.SetActive(false);
		Nozzle05.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
