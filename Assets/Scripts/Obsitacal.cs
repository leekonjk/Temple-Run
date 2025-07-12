using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Obsitacal : MonoBehaviour
{
    [SerializeField] GameObject[] gameobjects;
    float game_item_spwan = 0f;
    [SerializeField] Transform parent_Obsitacal;
    List<GameObject> gameobjectsList = new List<GameObject>();
    int lastObjectIndex = -1;
    int sameObjectCount = 0;

    void Start()
    {
        StartCoroutine(SpawnChunk());
    }
    IEnumerator SpawnChunk()
    {
        while (game_item_spwan < 10f)
        {
            yield return new WaitForSeconds(game_item_spwan);
            Vector3 spawnPosition;
            GameObject gameobject;
            RANDOMSPWANER(out spawnPosition, out gameobject);
            gameobjectsList.Add(Instantiate(gameobject, spawnPosition, Quaternion.identity, parent_Obsitacal));
            game_item_spwan++;
        }

    }

    private void RANDOMSPWANER(out Vector3 spawnPosition, out GameObject gameobject)
    {
        int randomIndex = UnityEngine.Random.Range(-4, 4);
        spawnPosition = new Vector3(randomIndex, 0, 0) + transform.position;

        int randomObjectIndex;
        int attempts = 0;

        // Try finding a different object if the same one was used 2 times already
        do
        {
            randomObjectIndex = UnityEngine.Random.Range(0, gameobjects.Length);
            attempts++;

            // Avoid infinite loop if all objects are the same
            if (attempts > 10) break;

        } while (randomObjectIndex == lastObjectIndex && sameObjectCount >= 2);

        // Check if it's the same as last
        if (randomObjectIndex == lastObjectIndex)
        {
            sameObjectCount++;
        }
        else
        {
            sameObjectCount = 1;
            lastObjectIndex = randomObjectIndex;
        }

        gameobject = gameobjects[randomObjectIndex];
    }

}
