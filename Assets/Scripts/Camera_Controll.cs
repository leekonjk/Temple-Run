using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Camera_Controll : MonoBehaviour
{
    CinemachineCamera cinemachineCamera; // Reference to the Cinemachine camera component
    float min_fov = 30f; // Minimum field of view
    float max_fov = 70f; // Maximum field of view
    float zoomSpeed = 1f; // Speed of zooming in and out
    float zooming = 5f; // Amount to change the field of view when zooming
    [Header("Zoom Settings")]
    [Tooltip("Amount to zoom in or out when changing FOV")]
    [SerializeField] ParticleSystem zoomEffect; // Particle system to play when zooming
    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>(); // Get the Cinemachine camera component attached to this GameObject
    }
    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines(); // Stop any ongoing coroutines to prevent multiple zooming actions from overlapping
        StartCoroutine(ChangeFOVRoutine(speedAmount)); // Start the coroutine to change the field of view
        if(speedAmount > 0)
        {
            zoomEffect.Play(); // Play the zoom effect particle system when zooming in
        }
    }
    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float stratFOV = cinemachineCamera.Lens.FieldOfView; // Get the current field of view
        float targetFOV = Mathf.Clamp(stratFOV + speedAmount * zooming, min_fov, max_fov); // Calculate the target field of view within the specified limits  
        float elapsedTime = 0f; // Initialize elapsed time
        while (elapsedTime < zoomSpeed)
        {
            elapsedTime += Time.deltaTime;
            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(stratFOV, targetFOV, elapsedTime / zoomSpeed); // Smoothly interpolate the field of view
            yield return null; // Wait for the next frame
        }
        cinemachineCamera.Lens.FieldOfView = targetFOV; // Set the final field of view to the target value
    }
}
