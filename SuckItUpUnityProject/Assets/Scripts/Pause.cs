using UnityEngine;
using UnityEngine.SceneManagement;

// Pause Mode
// attach to empty object or Main Camera
// handles pressing ESCAPE to display simple Pause Menu with instructions
// can add GUI.DrawTexture(...) to display images with text and buttons
public class Pause : MonoBehaviour
{
	public string HowToPlayText;
	public static bool bPaused;            //Boolean to check if the game is paused or not
	public Texture2D BGImg;

	[HideInInspector]
	public GUIStyle PauseStyle;       // set the text style of the frame counter
	[HideInInspector]
	public GUIStyle HowToStyle;
	public GUIStyle GamePausedStyle;
	[HideInInspector]
	public GUIStyle ButtonStyle1;       // set the text style of the frame counter
	public Texture2D ButtonImg1;

	public GUIStyle ButtonStyle2;       // set the text style of the frame counter
	public Texture2D ButtonImg2;

	public AudioClip ButtonSFX;
	public int indexSFX;
	public Font guiFont;            // default font to use for OnGui elements
	public Font PauseFont;            // Pause Menu font to use for OnGui elements

	void Start()
	{
		HowToStyle.alignment = TextAnchor.UpperCenter;      // sets text flow left to right from top
		HowToStyle.fontSize = 40;                         // font size to 40 (for HD display
		HowToStyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);  // text color white White
		HowToStyle.wordWrap = true;

		GamePausedStyle.alignment = TextAnchor.UpperCenter;      // sets text flow left to right from top
		GamePausedStyle.fontSize = 120;                         // font size to 40 (for HD display
		GamePausedStyle.normal.textColor = new Color(0.0f, 1.0f, 1.0f, 1.0f);  // text color Light Blue
		GamePausedStyle.wordWrap = true;

		ButtonStyle1.alignment = TextAnchor.MiddleCenter;    // sets button text flow to middle centered
		ButtonStyle1.fontSize = 40;                          // font size is 40 pixels
		ButtonStyle1.fontStyle = FontStyle.Bold;
		ButtonStyle1.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);   // text color is solid white
		ButtonStyle1.normal.background = (Texture2D)Resources.GetBuiltinResource(typeof(Texture2D), "GameSkin/button.png");  // use a default button
		ButtonStyle1.normal.background = ButtonImg1;  // use custom button

		ButtonStyle2.alignment = TextAnchor.MiddleCenter;    // sets button text flow to middle centered
		ButtonStyle2.fontSize = 40;                          // font size is 40 pixels
		ButtonStyle2.fontStyle = FontStyle.Bold;
		ButtonStyle2.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);   // text color is solid white
		ButtonStyle2.normal.background = (Texture2D)Resources.GetBuiltinResource(typeof(Texture2D), "GameSkin/button.png");  // use a default button
		ButtonStyle2.normal.background = ButtonImg2;  // use custom button

		// process string and display
		string temp;
		temp = HowToPlayText.Replace("\\n", "\n");
		temp = temp.Replace("\\t", "\t");
		HowToPlayText = temp;

		indexSFX = SoundBoard.Instance.AddSoundEffect(ButtonSFX);
	}

	// Update is called once per frame
	void Update()
	{
		// detects PC or Mac keyboard Escape = Menu
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (bPaused)
			{
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				UnPause();                              // stop pausing
				SoundBoard.Instance.PlaySFX(indexSFX);  // confirm audio
			}
			else
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				// no audio, because pausing
				DoPause();                              // begin pausing
			}
		}
	}

	void DoPause()
	{
		//Set bPaused to true
		bPaused = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		SoundBoard.Instance.DoPause();
	}

	void UnPause()
	{
		//Set bPaused to false
		bPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		SoundBoard.Instance.UnPause();
	}

	void OnGUI()
	{
		if ((guiFont != null) && (GUI.skin.font != guiFont))
		{
			// sets the global font used by OnGUI() UI stuff
			GUI.skin.font = guiFont;
		}

		if (bPaused)
		{
			if ((guiFont != null) && (GUI.skin.font != PauseFont))
			{
			// sets the global font used by OnGUI() UI stuff
			GUI.skin.font = PauseFont;
			}

			//Calculate change aspects
			float resX = (float)(Screen.width) / 1920f;
			float resY = (float)(Screen.height) / 1080f;

			//Set matrix
			GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));

			GUI.DrawTexture(new Rect(0, 0, 1920f, 1385f), BGImg);

			GUI.Box(new Rect(0, 20, 1920f, 1080f), "Game Paused", GamePausedStyle);                   // displays default GUI box without header

			GUI.Label(new Rect(10, 175, 1920f - 20f, 1080f * 0.75f), HowToPlayText, HowToStyle);

			if (GUI.Button(new Rect(1920f / 2 - -35, 1080f * 0.75f + -465, 300, 160), " ", ButtonStyle2))  // Quit to Main Menu Button
			{
				if ((guiFont != null) && (GUI.skin.font != guiFont))
				{
					// sets the global font used by OnGUI() UI stuff
					GUI.skin.font = guiFont;
				}
				UnPause();
				SoundBoard.Instance.PlaySFX(indexSFX);
				SceneManager.LoadScene(0);  // quit to menu
			}
			if (GUI.Button(new Rect(1920f / 2 - 360, 1080f * 0.75f + -465, 300, 160), " ", ButtonStyle1))  // Resume game Button
			{
				if ((guiFont != null) && (GUI.skin.font != guiFont))
				{
					// sets the global font used by OnGUI() UI stuff
					GUI.skin.font = guiFont;
				}
				UnPause();                  // resume game
				SoundBoard.Instance.PlaySFX(indexSFX);
			}
		}
	}
}
