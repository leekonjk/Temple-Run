using UnityEngine;

/// <summary>
/// Helper utilities for common Unity operations to reduce code duplication
/// </summary>
public static class UnityHelpers
{
    /// <summary>
    /// Safely finds an object of the specified type in the scene
    /// </summary>
    /// <typeparam name="T">Type of component to find</typeparam>
    /// <returns>The found component or null if not found</returns>
    public static T FindObjectOfType<T>() where T : Object
    {
        return Object.FindAnyObjectByType<T>();
    }
}
