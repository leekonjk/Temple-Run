using UnityEngine;
public class apple : PICKUP_LOGIC
{   
    LevelSpawner levelSpawner;
    public void initialize(LevelSpawner levelSpawner)
    {
        this.levelSpawner = levelSpawner;
    }
    protected override void OnPickupCollected()
    {
        levelSpawner.Move_chunks_speed(2); // Increase the speed of the level spawner
    }
}