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
    
    /// <summary>
    /// Clamps a value and returns whether it was changed
    /// </summary>
    public static bool ClampValue(ref float value, float min, float max)
    {
        float originalValue = value;
        value = Mathf.Clamp(value, min, max);
        return !Mathf.Approximately(originalValue, value);
    }
    
    /// <summary>
    /// Clamps an integer value and returns whether it was changed
    /// </summary>
    public static bool ClampValue(ref int value, int min, int max)
    {
        int originalValue = value;
        value = Mathf.Clamp(value, min, max);
        return originalValue != value;
    }
}
