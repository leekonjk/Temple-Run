using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class obstacle_spwaner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Obstacle Spawner Settings")]
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject Apple;
    [SerializeField] GameObject Coin;

    [Header("Spawning Chances")]
    [SerializeField]  float AppleSpwanChance = 0.3f;
    [SerializeField] float CoinSpwanChance = 0.5f;
    [SerializeField] float[] distance_at_which_lane_spwan = { 2.6f, 0, -2.6f };
    [SerializeField] float distance_between_coin_y = 2f;
    List<int> avaliablelanes = new List<int> { 0, 1, 2 };
    LevelSpawner levelGenerator;
    ScoreManager scoreManager;
    public void Init(LevelSpawner levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }

        void Start()
        {
            spwanObstracle();
            spwanApple();
            spwanCoin();
        }

  

    private void spwanObstracle()
    {


        int seletcedLane_2 = Random.Range(0, distance_at_which_lane_spwan.Length);
        for (int i = 0; i < seletcedLane_2; i++)
        {
            if (avaliablelanes.Count <= 0)
            {
                return;
            }
            int randomIndex = SpwanRandomNumber(avaliablelanes);

            Vector3 spwanLocation = new Vector3(distance_at_which_lane_spwan[randomIndex], transform.position.y, transform.position.z);
            Instantiate(obstacle, spwanLocation, Quaternion.identity, this.transform);
        }

    }


    private void spwanApple()
    {
        if (Random.value > AppleSpwanChance || avaliablelanes.Count <= 0)
        {
            return;
        }
        int randomIndex = SpwanRandomNumber(avaliablelanes);

        Vector3 spwanLocation = new Vector3(distance_at_which_lane_spwan[randomIndex], transform.position.y, transform.position.z);
        apple Apple2 = Instantiate(Apple, spwanLocation, Quaternion.identity, this.transform).GetComponent<apple>();
        Apple2.initialize(levelGenerator);
    }
    private void spwanCoin()
    {
            if(Random.value > CoinSpwanChance || avaliablelanes.Count <= 0)
            {
                return;
            }
 
            int xyz = Random.Range(0, 6);
            int randomIndex = SpwanRandomNumber(avaliablelanes);
            float topvalueOFZ = transform.position.z + (distance_between_coin_y * 2F);
        for (int i = 0; i < xyz; i++)
        {
            float randomz = topvalueOFZ - (i * distance_between_coin_y);
            Vector3 spwanLocation = new Vector3(distance_at_which_lane_spwan[randomIndex], transform.position.y, randomz);
            coin coin2 = Instantiate(Coin, spwanLocation, Quaternion.identity, this.transform).GetComponent<coin>();
            coin2.initialize(scoreManager);
            }

    }
    private static int SpwanRandomNumber(List<int> avaliablelanes)
    {
        int selectedLane = Random.Range(0, avaliablelanes.Count);
        int randomIndex = avaliablelanes[selectedLane];
        avaliablelanes.RemoveAt(selectedLane);
        return randomIndex;
    }
}
