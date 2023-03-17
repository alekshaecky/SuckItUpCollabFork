using UnityEngine;

public class Fps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // just to display the framerate - comment out when not needed
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 50, 100, 50, 50), ((int)(1.0f / Time.deltaTime)).ToString());
    }
}
