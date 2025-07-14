using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Level Spawner Settings")]
    [SerializeField] GameObject[] Chunks_Varinats;
    [SerializeField] GameObject CheckPoint;
    [Header("Chunk Settings")]
    [Tooltip("Parent object for the spawned chunks.")]
    [SerializeField] Transform Paraent_Platfrom;
    [SerializeField] int Chunk_Will_Reload;
    [SerializeField] float Space_between_chunk;
    [SerializeField] ScoreManager scoreManager;
    [Header("Chunk Speed Settings")]
    [HideInInspector] public int move_speed_chunk;
    [HideInInspector] public int min_move_speed_chunk;
    int chunks_counter = 0;
    [Tooltip("The speed at which the chunks will move towards the camera.")]
    [SerializeField] Camera_Controll camera_Controll;

    List<GameObject> chunks;
    void Start()
    {
        initialize();
        Create_Chunks();
    }
    void Update()
    {
        moveChunks();
    }
    public void Move_chunks_speed(int speed)
    {
        float new_move_speed_chunk = move_speed_chunk + speed;
        new_move_speed_chunk = Mathf.Clamp(new_move_speed_chunk, 5f, 20f); // Clamp the speed to a reasonable range
        if (new_move_speed_chunk != move_speed_chunk)
        {
            move_speed_chunk = (int)new_move_speed_chunk;
            float newG = Physics.gravity.z - speed;
            newG = Mathf.Clamp(newG, -22f, 2f); // Clamp the gravity to a reasonable range
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newG);
            camera_Controll.ChangeCameraFOV(speed);
        }
    }
    private void moveChunks()
    {
        for (int Chunk_Will_Destory = 0; Chunk_Will_Destory < chunks.Count; Chunk_Will_Destory++)
        {
            GameObject chunk = chunks[Chunk_Will_Destory];
            chunk.transform.Translate(move_speed_chunk * Time.deltaTime * -transform.forward);
            if (chunk.transform.position.z <= Camera.main.transform.position.z - Space_between_chunk)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                calculate_SpwanPosition_Z();
            }
        }
    }

    private void initialize()
    {
        //C# does not allow instance fields to reference each other in field initializers because initializers run before the constructor.
        Chunk_Will_Reload = 10;
        Space_between_chunk = 10f;
        move_speed_chunk = 10;
        min_move_speed_chunk = 4;
        chunks = new List<GameObject>();
    }

    private void Create_Chunks()
    {
        // For loop to the Chunk will reload    
        for (int chunk_Strat = 0; chunk_Strat < Chunk_Will_Reload; chunk_Strat++)
        {
            //Quaternion.identity Show (0,0,0) rotation 
            calculate_SpwanPosition_Z();
        }
    }

    private void calculate_SpwanPosition_Z()
    {
        Vector3 positon_Next = get_Position();
        GameObject chunk = ChoseChunks(positon_Next);
        chunks.Add(chunk);
        obstacle_spwaner newChunk = chunk.GetComponent<obstacle_spwaner>();
        newChunk.Init(this, scoreManager);
        chunks_counter++;
    }

    private GameObject ChoseChunks(Vector3 positon_Next)
    {
        GameObject chunk;
        if (chunks_counter % 5 == 0 && chunks_counter > 0)
        {
            chunk = Instantiate(CheckPoint, positon_Next, Quaternion.identity, Paraent_Platfrom);
        }
        else
        {
            chunk = Instantiate(OnSelectRandomChunk(), positon_Next, Quaternion.identity, Paraent_Platfrom);
        }

        return chunk;
    }

    GameObject OnSelectRandomChunk()
    {
        // Define chunk weights: 0 is common (weight 1), 1 is .2, 2 is .12, 3 is .1
        float[] weights = new float[] { 1f, 0.2f, 0.15f, 0.1f };
        // Prevent immediate repetition
        int lastIndex = -1;
        if (chunks.Count > 0)
        {
            GameObject lastChunk = chunks[chunks.Count - 1];
            lastIndex = System.Array.IndexOf(Chunks_Varinats, lastChunk.name.Contains("(Clone)") ? lastChunk.name.Replace(" (Clone)", "") : lastChunk.name);
        }

        // Build a list of valid indices and their weights
        List<int> validIndices = new List<int>();
        List<float> validWeights = new List<float>();
        for (int i = 0; i < Chunks_Varinats.Length; i++)
        {
            if (i != lastIndex)
            {
                validIndices.Add(i);
                validWeights.Add(weights[i]);
            }
        }

        // Weighted random selection
        float totalWeight = 0f;
        foreach (float w in validWeights) totalWeight += w;
        float rnd = UnityEngine.Random.value * totalWeight;
        float accum = 0f;
        for (int i = 0; i < validIndices.Count; i++)
        {
            accum += validWeights[i];
            if (rnd <= accum)
                return Chunks_Varinats[validIndices[i]];
        }
        // Fallback
        return Chunks_Varinats[validIndices[0]];
    }

    private Vector3 get_Position()
    {
        if (chunks.Count > 0)
        {
            Vector3 lastChunkPos = chunks[chunks.Count - 1].transform.position;
            return new Vector3(lastChunkPos.x, lastChunkPos.y, lastChunkPos.z + Space_between_chunk);
        }
        return transform.position;
    }
}
