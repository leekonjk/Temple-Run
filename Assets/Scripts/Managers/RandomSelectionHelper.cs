using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility class for random selection operations with various constraints
/// </summary>
public static class RandomSelectionHelper
{
    /// <summary>
    /// Selects a random index from a list and removes it to prevent reuse
    /// </summary>
    public static int SelectAndRemoveRandomIndex(List<int> availableIndices)
    {
        if (availableIndices == null || availableIndices.Count == 0)
        {
            Debug.LogWarning("Attempted to select from empty or null list");
            return -1;
        }
        
        int selectedIndex = Random.Range(0, availableIndices.Count);
        int value = availableIndices[selectedIndex];
        availableIndices.RemoveAt(selectedIndex);
        return value;
    }
    
    /// <summary>
    /// Performs weighted random selection from an array of options
    /// </summary>
    /// <typeparam name="T">Type of items to select from</typeparam>
    /// <param name="items">Array of items to select from</param>
    /// <param name="weights">Weights for each item (must match items length)</param>
    /// <param name="excludeIndex">Optional index to exclude from selection</param>
    /// <returns>Selected item</returns>
    public static T WeightedRandomSelection<T>(T[] items, float[] weights, int excludeIndex = -1)
    {
        if (items == null || items.Length == 0)
        {
            Debug.LogError("Items array is null or empty");
            return default(T);
        }
        
        if (weights == null || weights.Length != items.Length)
        {
            Debug.LogError("Weights array is null or does not match items length");
            return default(T);
        }
        
        // Calculate total weight, excluding the specified index
        float totalWeight = 0f;
        for (int i = 0; i < items.Length; i++)
        {
            if (i != excludeIndex)
            {
                totalWeight += weights[i];
            }
        }
        
        if (totalWeight <= 0f)
        {
            Debug.LogWarning("No valid items after exclusion or all weights are zero");
            // Return first non-excluded item
            for (int i = 0; i < items.Length; i++)
            {
                if (i != excludeIndex)
                {
                    return items[i];
                }
            }
            return items[0];
        }
        
        // Weighted random selection without allocating lists
        float randomValue = Random.value * totalWeight;
        float accumulator = 0f;
        
        for (int i = 0; i < items.Length; i++)
        {
            if (i != excludeIndex)
            {
                accumulator += weights[i];
                if (randomValue <= accumulator)
                {
                    return items[i];
                }
            }
        }
        
        // Fallback to first non-excluded item
        for (int i = 0; i < items.Length; i++)
        {
            if (i != excludeIndex)
            {
                return items[i];
            }
        }
        return items[0];
    }
}
