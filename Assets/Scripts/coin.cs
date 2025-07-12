using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class coin : PICKUP_LOGIC
{
    private ScoreManager scoreManager;

    public void initialize(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickupCollected()
    {
        scoreManager.AddScore(100);
    }

}