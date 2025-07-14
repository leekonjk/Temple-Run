using UnityEngine;

public class GameTIme : MonoBehaviour
{
    [Header("Game Time Settings")]
    [SerializeField] TMPro.TextMeshProUGUI timerText;
    readonly float timeLimit = 5f;
    private float timeRemaining;
    private ScoreManager scoreManager; // Reference to the ScoreManager script
    void Start()
    {
        timeRemaining = timeLimit;
        scoreManager = FindAnyObjectByType<ScoreManager>(); // Find the ScoreManager script in the scene
    }
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Max(0, Mathf.RoundToInt(timeRemaining)).ToString();
        if (timeRemaining <= 0)
        {
            EndGame();
        }

    }
    public void IncreaseTime(float amount)
    {
        timeRemaining += amount;
        if (timeRemaining > timeLimit)
        {
            timeRemaining = timeLimit; // Cap the time at the limit
        }
    }
    private void EndGame()
    {
        scoreManager.GameOver();
    }
}
