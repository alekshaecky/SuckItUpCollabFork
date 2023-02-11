using UnityEngine;

// Updates the GrindCurrency readout display once every 1-second
// attach to a Legacy TextMesh object for HUD or Shop
// if the lag is too much at 1-second, shorten to 0.5 or 0.25 second
public class Score : MonoBehaviour
{
    public int TempScoreAmount;
    TextMesh ScoreText;
    int TotalScoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        TempScoreAmount = 0;
        PlayerPrefs.SetInt("PrefsTempScore", TempScoreAmount);
        PlayerPrefs.Save();
        TotalScoreAmount = PlayerPrefs.GetInt("PrefsTotalScore");
        ScoreText = GetComponent<TextMesh>();
        ScoreText.text = "Current: " + TempScoreAmount.ToString() + "\nTotal: " + TotalScoreAmount.ToString();
        InvokeRepeating("ScoreUpdate", 1.0f, 1.0f);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    // Update is called once per second
    void ScoreUpdate()
    {
        TempScoreAmount = PlayerPrefs.GetInt("PrefsTempScore");
        ScoreText.text = "Current: " + TempScoreAmount.ToString() + "\nSaved: " + TotalScoreAmount.ToString();
    }
}
