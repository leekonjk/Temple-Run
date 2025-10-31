using UnityEngine;

/// <summary>
/// Contains constant values used throughout the game to avoid magic strings and duplicated values
/// </summary>
public static class GameConstants
{
    // Tags
    public const string PlayerTag = "Player";
    
    // Speed constraints
    public const float MinMoveSpeed = 5f;
    public const float MaxMoveSpeed = 20f;
    
    // Gravity constraints
    public const float MinGravityZ = -22f;
    public const float MaxGravityZ = 2f;
}
