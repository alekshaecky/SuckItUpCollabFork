using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
	public string SignText;         // text if it should be displayed

	[HideInInspector]
	public GUIStyle HUDstyle;       // set the text style of the frame counter
	[HideInInspector]
	public string HUDtext;          // display text on the HUD
	[HideInInspector]
	public Rect HUDrect;            // area for HUD display

	AudioSource MyAudioSource;

	// Start is called before the first frame update
	void Start()
	{
		HUDstyle.alignment = TextAnchor.MiddleCenter;      // sets text flow left to right from top
		HUDstyle.fontSize = 24;
		HUDstyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);  // text color white White
		HUDstyle.wordWrap = true;

		// sets HUD display rectangle
		//HUDrect = new Rect(Screen.width/4, Screen.height/3 + 200, Screen.width/2, 60);
		HUDrect = new Rect(0, Screen.height, Screen.width, -60);

		//Fetch the AudioSource from the GameObject
		MyAudioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{

	}

	// Display HUD values
	private void OnGUI()
	{
		// if text is not empty, display it
		if (HUDtext != "")
		{
			GUI.Box(HUDrect, "");                   // displays default GUI box without header
			GUI.Label(HUDrect, HUDtext, HUDstyle);  // shows text in box with defined style
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// if audio clip is designated, play it
			if (MyAudioSource != null)
			{
				MyAudioSource.Play();
			}

			// process string and display
			string temp;
			temp = SignText.Replace("\\n", "\n");
			temp = temp.Replace("\\t", "\t");
			HUDtext = temp;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// stop designated audio clip
			if (MyAudioSource != null)
			{
				MyAudioSource.Stop();
			}

			// clear trigger text because we left encounter
			HUDtext = "";
		}
	}
}
