using UnityEngine;
using UnityEngine.SceneManagement;

public class JunkMeter : MonoBehaviour
{
	public Texture2D JunkMeterTexture;
	public int JunkCapacity; 				// it would be good to scale this as the nozzle is upgraded
	public int piecesOfJunk;
	public int nozzleRank;
	public GUIStyle HUDstyle2;       // set the text style of the frame counter
	public GUIStyle LVLstyle;       // set the text style of the frame counter
	public Rect HUDrect;

	public Texture2D nozzleIcon;

	Vacuum VacRef;

	// Use this for initialization
	void Start()
	{
		VacRef = GameObject.FindObjectOfType<Vacuum>();
		JunkCapacity = VacRef.GetCapacity();
		Debug.Log(JunkCapacity);
		piecesOfJunk = PlayerPrefs.GetInt("PrefsTotalScore");             // Gets the max score value (# of Junk in Level)
		nozzleRank = PlayerPrefs.GetInt("PrefsCurrentVacuumPower");

		HUDrect = new Rect(1400, 15, 500, 80);  // based on 1920x1080 screen
		HUDstyle2.alignment = TextAnchor.UpperLeft;      // sets text flow left to right from top
		HUDstyle2.fontSize = 75;                         // font size to 100 (for HD display
		HUDstyle2.normal.textColor = Color.red;		// text color Red
		HUDstyle2.normal.background = null;

		LVLstyle.alignment = TextAnchor.UpperLeft;      // sets text flow left to right from top
		LVLstyle.fontSize = 38;                         // font size to 100 (for HD display
		LVLstyle.normal.textColor = Color.red;		// text color Red
		LVLstyle.normal.background = null;
	}

	// Update is called once per frame
	void Update()
	{
		// cheat for Vacuum Nozzle Rank
		if (Input.GetKeyDown(KeyCode.U))
		{
			switch (PlayerPrefs.GetInt("PrefsCurrentVacuumPower"))
			{
				case 1:
					PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 2);
					break;
				case 2:
					PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 3);
					break;
				case 3:
					PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 4);
					break;
				case 4:
					PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 5);
					break;
				default:
					PlayerPrefs.SetInt("PrefsCurrentVacuumPower", 1);
					break;
			}
			PlayerPrefs.Save();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	// Initialize GUI
	void OnGUI()
	{
		if (Pause.bPaused == false)
		{
			//Calculate change aspects - WebGL can change - but render is HD 1920x1080
			float resX = (float)(Screen.width) / 1920f;
			float resY = (float)(Screen.height) / 1080f;
		
			//Set matrix
			GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));

			int tempScore = PlayerPrefs.GetInt("PrefsTempScore");
			
			GUI.DrawTexture(new Rect(1270, 5, 128f, 128f), nozzleIcon);

			GUI.Box(new Rect(1400, 20, 500, 80), "");                   // displays default GUI box without header around meter
			int meterValue = (tempScore > JunkCapacity) ? JunkCapacity : tempScore;   // set meter - but not over
			GUI.DrawTexture(new Rect(HUDrect.x + 5, HUDrect.y + 10, (HUDrect.width - 10) * meterValue / JunkCapacity, HUDrect.height - 10), JunkMeterTexture, ScaleMode.StretchToFill, false);
			GUI.Label(new Rect(1313, 15, 1920f - 20f, 1080f * 0.75f), "lvl", LVLstyle);      // displays "lvl" above the nozzle level number
			GUI.Label(new Rect(1310, 55, 1920f - 20f, 1080f * 0.75f), nozzleRank.ToString(), HUDstyle2); // displays the nozzle level number 
		}
	}
}
