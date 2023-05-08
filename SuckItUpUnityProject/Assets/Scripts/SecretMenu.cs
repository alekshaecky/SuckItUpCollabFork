using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretMenu : MonoBehaviour
{
	public GUIStyle MenuStyle;      // set the text style of the frame counter
	public GUIStyle ButtonStyle;    // special for the button to have a background grahic
	public int NumberOfModules;
	Rect MenuRect;

	// Start is called before the first frame update
	void Start()
	{
		MenuStyle.alignment = TextAnchor.UpperCenter;   // sets text flow upper centered
		MenuStyle.fontSize = 40;                        // font size to 40 (for HD display)
		MenuStyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);  // text color solid white
		MenuStyle.wordWrap = true;

		ButtonStyle.alignment = TextAnchor.MiddleCenter;    // sets button text flow to middle centered
		ButtonStyle.fontSize = 30;                          // font size is 30 pixels
		ButtonStyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);   // text color is solid white
		ButtonStyle.normal.background = (Texture2D)Resources.GetBuiltinResource(typeof(Texture2D), "GameSkin/button.png");  // use a default button

		MenuRect = new Rect(0f, 0f, 960f, 600f);    // default WebGL width = 960, height = 600
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnGUI()
	{
		//Calculate change aspects
		float resX = (float)(Screen.width) / MenuRect.width;
		float resY = (float)(Screen.height) / MenuRect.height;

		int sceneIndex;     // index into Build Setting scene list	
		int buttonIndex;    //buttons have index of 1 less than build setting scene index

		//Set matrix
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));

		// set full screen menu box
		GUI.Box(MenuRect, "SECRET MENU", MenuStyle);
		// loop for all scenes in Build Settings - skipping menu scene at index 0
		for (sceneIndex = 2; sceneIndex < SceneManager.sceneCountInBuildSettings; sceneIndex++)
		{
			buttonIndex = sceneIndex - 1;
			string SceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(sceneIndex));    // convert index to scene file name
																																 // make & check if button pressed
			if (GUI.Button(new Rect((buttonIndex / 7) * 330, 60 + (buttonIndex % 7) * 80, 300, 45), SceneName, ButtonStyle))  // 3 Columns 330 pixels wide, each new button 80 pixels apart (offset 60 pixels)
			{
				SceneManager.LoadScene(sceneIndex);   // load scene by build setting scene index
			}
		}

		if (GUI.Button(new Rect(785 - 25, 600 - 10 - 75, 100, 45), "BACK"))
		{
			SceneManager.LoadScene(0);      // load the MENU scene at index 0
		}
	}
}
