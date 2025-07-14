using System;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    [Header("Increase Time Settings")]
    GameTIme gameTime; // Reference to the GameTIme script
    void Start()
    {
        // Find the GameTIme script in the scene
        gameTime = FindAnyObjectByType<GameTIme>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameTime.IncreaseTime(10f); // Increase time by 10 seconds
            Destroy(gameObject); // Destroy the object after increasing time
        }
    }
}
