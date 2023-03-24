using UnityEngine;
using System.Collections;

public class UpgradeMeter : MonoBehaviour
{
    public Texture2D UpgradeMeterTexture;
	public int NozzleLevel; 				
	public int MaxJunk;
	public int VacuumedJunk; 

	// Use this for initialization
	void Start()
	{
		NozzleLevel = PlayerPrefs.GetInt("PrefsCurrentVacuumPower");       // The level of the players nozzle 
		MaxJunk = PlayerPrefs.GetInt("PrefsTotalScore");                  // Gets the max score of game
		VacuumedJunk = PlayerPrefs.GetInt("PrefsTempScore");             // Gets the current score value (# of Junk the player has Vacuumed)
	}

	// Update is called once per frame
	void Update()
	{
		MaxJunk = MaxJunk + VacuumedJunk;
	}

	// Initialize GUI
	void OnGUI()
	{
		Rect HUDrect = new Rect(1400, 950, 500, 80);
		
		//Calculate change aspects - WebGL can change - but render is HD 1920x1080
		float resX = (float)(Screen.width) / 1920f;
		float resY = (float)(Screen.height) / 1080f;
		
		//Set matrix
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));
        
		GUI.Box(HUDrect, "");                   // displays default GUI box without header around meter
		GUI.DrawTexture(new Rect(HUDrect.x + 5, HUDrect.y + 5, (HUDrect.width - MaxJunk) * VacuumedJunk / NozzleLevel, HUDrect.height - 10), UpgradeMeterTexture, ScaleMode.StretchToFill, false);
	}
}
