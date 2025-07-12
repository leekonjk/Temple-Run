using UnityEngine;
public class ScoreManager : MonoBehaviour
{

    [Header("Text to display score")]
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
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
}