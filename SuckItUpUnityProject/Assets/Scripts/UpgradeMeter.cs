using UnityEngine;

public class UpgradeMeter : MonoBehaviour
{
    public float PercentageFull;

    Vector3 SpriteScale;
    float YScale;
    SpriteRenderer vertSprite;

    // Start is called before the first frame update
    void Start()
    {
        // get the sprite render component
        vertSprite = GetComponent<SpriteRenderer>();
        // get original scale (in example 1, 10, 1)
        SpriteScale = vertSprite.gameObject.transform.localScale;
        // save Yscale based on current object scale as 100%
        YScale = SpriteScale.y;
		// NextUpgradeAmount is the denominator in the percentage
		float NextUpgradeAmount = GetUpgradeScore(PlayerPrefs.GetInt("PrefsCurrentVacuumPower"));
		// TotatScoreAmount is the numerator in the percentage
		float TotalScoreAmount = PlayerPrefs.GetInt("PrefsTotalScore");
		// calculate PercentageFull from PrefsTotalScore divided by GetUpgradeScore() amount
		PercentageFull = TotalScoreAmount/NextUpgradeAmount;
    }

    // Update is called once per frame
    void Update()
    {
        // range check PercentageFull value 0 to 1.0 aka 100%
        if(PercentageFull > 1.0f)
		{
            PercentageFull = 1.0f;
		}
        if(PercentageFull < 0.0f)
		{
            PercentageFull = 0.0f;
		}
        // recalculate sprite scale
        SpriteScale = new Vector3(SpriteScale.x, PercentageFull * YScale, SpriteScale.z);
        // set sprite transform
        vertSprite.gameObject.transform.localScale = SpriteScale;
    }

	public float GetUpgradeScore(int nozzleRank)
	{
		// capacity based on current nozzleRank
		if (nozzleRank == 1)
		{
			return 1000f;
		}
		if (nozzleRank == 2)
		{
			return 10000f;
		}
		if (nozzleRank == 3)
		{
			return 50000f;
		}
		if (nozzleRank == 4)
		{
			return 250000f;
		}
		// else nozzleRank is 5
		return 1000000f;
	}
}
