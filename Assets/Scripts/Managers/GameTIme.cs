using System;
using UnityEngine;

public class GameTIme : MonoBehaviour
{
    [Header("Game Time Settings")]
    [SerializeField] TMPro.TextMeshProUGUI timerText;
    [SerializeField] float timeLimit = 10f; // Set the time limit in seconds
    [SerializeField] ScoreManager scoreManager;                                      // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float timeRemaining;
    void Start()
    {
        timeRemaining = timeLimit;
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

    private void EndGame()
    {
        scoreManager.GameOver();
    }
}
