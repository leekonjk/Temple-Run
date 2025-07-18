using UnityEngine;
public class ScoreManager : MonoBehaviour
{

    [Header("Text to display score")]
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] Player_Movement playerMovement;
    [SerializeField] private GameObject GameOverText;
    private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void GameOver()
    {
        GameOverText.SetActive(true);
        Time.timeScale = 0.5f;
        playerMovement.enabled = false;
    }
}