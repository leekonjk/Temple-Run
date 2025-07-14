using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Level Spawner Settings")]
    [SerializeField] GameObject Platfrom;
    [SerializeField] Transform Paraent_Platfrom;
    [SerializeField] int Chunk_Will_Reload;
    [SerializeField] float Space_between_chunk;
    [SerializeField] ScoreManager scoreManager;
    [Header("Chunk Speed Settings")]
    [HideInInspector] public int move_speed_chunk;
    [HideInInspector] public int min_move_speed_chunk;
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
        float new_move_speed_chunk = move_speed_chunk +  speed;
        new_move_speed_chunk = Mathf.Clamp(new_move_speed_chunk, 5f, 20f); // Clamp the speed to a reasonable range
        if (new_move_speed_chunk != move_speed_chunk)
        {
            move_speed_chunk =(int) new_move_speed_chunk;
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
        GameObject chunk = Instantiate(Platfrom, positon_Next, Quaternion.identity, Paraent_Platfrom);
        chunks.Add(chunk);
        obstacle_spwaner newChunk = chunk.GetComponent<obstacle_spwaner>();
        newChunk.Init(this, scoreManager);

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
