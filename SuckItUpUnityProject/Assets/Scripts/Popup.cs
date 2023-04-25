using UnityEngine;

// UI Pop-up object
// Create an empty object that will get and show alerts...
// GameObject.Find("Alert").GetComponent<Alert>().SetAlertText("Hello, World!");
public class Popup : MonoBehaviour
{
	public AudioClip ButtonSFX;     // audio for button
	public int indexSFX;
	public string PopupText;          // display text on the HUD
	public string SpeakerName;          
	public Texture2D SpeakerImg;

	[HideInInspector]
	public GUIStyle HUDstyle;       // set the text style of the frame counter
	[HideInInspector]
	public Rect HUDrect;            // area for HUD display

	AudioSource MyAudioSource;
	int ImageSize;

	// Start is called before the first frame update
	void Start()
	{
		ImageSize = 128;
		HUDstyle.alignment = TextAnchor.UpperLeft;      // sets text flow left to right from top
		HUDstyle.fontSize = 40;                         // font size to 40 (for HD display
		HUDstyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);  // text color white White
		HUDstyle.normal.background = null;
		HUDstyle.wordWrap = true;

		// sets HUD display to bottom quarter of screen
		HUDrect = new Rect(0, Screen.height * 0.75f, Screen.width, Screen.height * 0.25f);

		//Fetch the AudioSource from the GameObject
		MyAudioSource = GetComponent<AudioSource>();

		indexSFX = SoundBoard.Instance.AddSoundEffect(ButtonSFX);
	}

	private void Update()
	{
		// any button or key will clear the alert
		if (Input.anyKeyDown)
		{
			// if text is not empty, play SFX and empty string
			if (PopupText != "")
			{
				SoundBoard.Instance.PlaySFX(indexSFX);
				PopupText = "";
			}
		}
	}

	public void SetPopup(string newText, Texture2D newImage, string newName)
	{
		PopupText = newText;
		SpeakerImg = newImage;
		SpeakerName = newName;
	}


	// Display HUD values
	private void OnGUI()
	{
		// GUI font skin set by Pause.cs script

		// if text is not empty, display it
		if (PopupText != "")
		{
			GUI.Box(HUDrect, "");                   // displays default GUI box without header
			GUI.DrawTexture(new Rect(0, Screen.height * 0.75f, ImageSize, ImageSize), SpeakerImg);
			Rect textRect = HUDrect;
			textRect.x = ImageSize;
			GUI.Label(textRect, PopupText, HUDstyle);  // shows text in box with defined style
			//GUI.Label(textRect, SpeakerName, HUDstyle);  // shows text in box with defined style
			GUI.Box(new Rect(2, 343, 1920f, 1080f), SpeakerName + ":", HUDstyle);
		}
	}
}
