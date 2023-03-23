using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Initialize PlayerPrefs
// Create an empty object & attach this script in your opening scene (usually MENU)
// modify as needed for your own PlayerPrefs needs
// to reset PlayerPrefs in the Unity Editor you can use Edit > Clear All PlayerPrefs
public class Init : MonoBehaviour
{
	int StartingScene = 3;          // currently first actual game scene = HUB world
	int StartingVacuumPower = 1;	// 1 to 5

	// Start is called before the first frame update
	void Start()
	{
		if (!PlayerPrefs.HasKey("PrefsApp") || (PlayerPrefs.GetString("PrefsApp") == ""))
		{
			// initialize PlayerPrefs
			InitializePlayerPrefs();

			// finish by immediately saving current PlayerPrefs
			PlayerPrefs.Save();
		}

		// upgrade (or decide to delete) stored player prefs for new version
		string PrefsVersion = PlayerPrefs.GetString("PrefsVersion");
		if (PrefsVersion != Application.version)
		{
			Debug.Log("Convert PlayerPrefs from old version " + PrefsVersion);
			// convert old version to new version of PlayerPrefs settings
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// call function to initialize the PlayerPrefs (save game)
	public void InitializePlayerPrefs()
	{
		Debug.Log("Reseting/Initializing PlayerPrefs");
		PlayerPrefs.DeleteAll(); // be very careful, this resets your saves
		PlayerPrefs.SetString("PrefsApp", Application.productName);     // set to Player Setting
		PlayerPrefs.SetString("PrefsVersion", Application.version);     // set to Player Setting
		PlayerPrefs.SetInt("PrefsStartingSceneIndex", StartingScene);   // up to game
		PlayerPrefs.SetInt("PrefsCurrentVacuumPower", StartingVacuumPower);		// start at power 0, can leave HUB until it is 1
		PlayerPrefs.GetInt("PrefsTotalScore", 0);                       // up to game
		PlayerPrefs.GetInt("PrefsTempScore", 0);						// score of current level run
		PlayerPrefs.SetInt("PrefsLevel1HighScore", 0);                  // level 1 high score
		PlayerPrefs.SetInt("PrefsLevel2HighScore", 0);                  // level 2 high score
		PlayerPrefs.SetInt("PrefsLevel3HighScore", 0);                  // level 3 high score
		PlayerPrefs.SetInt("PrefsLevel4HighScore", 0);                  // level 4 high score
		PlayerPrefs.SetInt("PrefsLevel5HighScore", 0);                  // level 5 high score
																		// add and initialize any additional presistent data
																		// for your game below using SetInt, SetFloat, or SetString
	}
}
