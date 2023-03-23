using UnityEngine;
using System.Collections;

public class JunkMeter : MonoBehaviour
{
	public Texture2D JunkMeterTexture;
	public int JunkCapacity; 				// it would be good to scale this as the nozzle is upgraded
	public int piecesOfJunk;

	Vacuum VacRef;

	// Use this for initialization
	void Start()
	{
		VacRef = GameObject.FindObjectOfType<Vacuum>();
		JunkCapacity = VacRef.GetCapacity();
		piecesOfJunk = PlayerPrefs.GetInt("PrefsTotalScore");             // Gets the max score value (# of Junk in Level)
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// Initialize GUI
	void OnGUI()
	{
		Rect HUDrect = new Rect(1400, 15, 500, 80);
		
		//Calculate change aspects - WebGL can change - but render is HD 1920x1080
		float resX = (float)(Screen.width) / 1920f;
		float resY = (float)(Screen.height) / 1080f;
		
		//Set matrix
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));

		int tempScore = PlayerPrefs.GetInt("PrefsTempScore");

		GUI.Box(HUDrect, "");                   // displays default GUI box without header around meter
		int meterValue = (tempScore > JunkCapacity) ? JunkCapacity : tempScore;   // set meter - but not over
		GUI.DrawTexture(new Rect(HUDrect.x + 5, HUDrect.y + 5, (HUDrect.width - 10) * meterValue / JunkCapacity, HUDrect.height - 10), JunkMeterTexture, ScaleMode.StretchToFill, false);
	}
}
