using System;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_collison_handler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Animator playerAnimator; // Reference to the Animator component
    const string playerAnimationTrigger = "Hit"; // Animation trigger name
    const string ClawingPlayer = "Claw"; // Animation trigger name
    [SerializeField] float animationDelay = 1f; // Delay before the animation plays
    float CollisionCo = 0f; // Collision delay threshold
    [SerializeField] int perHitScoreLimit = 2; // Reference to the player GameObject
    int HitScore = 0; // Score variable to track the number of hits
    LevelSpawner levelSpawner; // Reference to the Obsitacal_spwaner script
    void Start()
    {
        // Get the LevelSpawner component attached to the same GameObject
        levelSpawner = FindAnyObjectByType<LevelSpawner>();
    }
    void Update()
    {
        CollisionCo += Time.deltaTime; // Increment the delay by the time since the last frame
        CheckHIT(); // Check if the hit score has reached the limit
    }
    void OnCollisionEnter(Collision collision)
    {
       HandleHitAnimation();
    }

    private void HandleHitAnimation()
    {
        if (CollisionCo >= animationDelay) // Check if the delay is greater than or equal to 0.5 seconds
        {  
            levelSpawner.Move_chunks_speed(-1); // Decrease the speed of the level spawner
            playerAnimator.SetTrigger(playerAnimationTrigger); // Trigger the hit animation
            CollisionCo = 0; // Reset the delay
            HitScore ++; // Increment the hit score
            Debug.Log("HitScore: " + HitScore); // Log the hit score to the console
        }
    }
    private void CheckHIT()
    {
        if (HitScore >= perHitScoreLimit) // Check if the hit score is greater than or equal to the limit
        {
            playerAnimator.SetTrigger(ClawingPlayer);  // Trigger the on-hit animation
            HitScore = 0; // Reset the hit score
            levelSpawner.move_speed_chunk = 5; // Stop the level spawner
            // Start the coroutine to wait for 1 second and then resume the level spawner
            StartCoroutine(WaitAndResumeLevelSpawner(2f)); // Wait for 1 second before resuming the level spawner
        }
    }
    private IEnumerator WaitAndResumeLevelSpawner(float v)
    {
        // Wait for the specified time and then resume the level spawner
        yield return new WaitForSeconds(v); // Wait for 1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
