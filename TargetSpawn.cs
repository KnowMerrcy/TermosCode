using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] targets;
    public GameObject coin;
    public float timeBetweenSpawn;
    public float timeToMakeHarder;
    public float timeToSpawnCoin;

    private int targetID = 0;
    private int spawnID;
    private float targetTime = 0.0f;
    private float coinTime = 0.0f;
    private float gameTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetID = 0;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime += Time.deltaTime;
        coinTime += Time.deltaTime;
        gameTime += Time.deltaTime;

        if (!EndGame.gameLost)
        {
            // Spawn fruit
            if (targetTime >= timeBetweenSpawn)
            {
                spawnID = Random.Range(0, spawnPoints.Length);

                Instantiate(targets[Random.Range(0, targetID)], spawnPoints[spawnID].position, Quaternion.identity);

                targetTime = 0.0f;
            }

            // Make game harder
            if (gameTime >= timeToMakeHarder)
            {
                if (timeBetweenSpawn >= 0.5f)
                {
                    timeBetweenSpawn -= 0.1f;
                }

                if (timeBetweenSpawn <= 1.6f)
                {
                    targetID = 2;
                }

                if (timeBetweenSpawn <= 1.1f)
                {
                    targetID = 3;
                }

                gameTime = 0.0f;
            }

            // Spawn coin
            if (coinTime >= timeToSpawnCoin)
            {
                spawnID = Random.Range(0, spawnPoints.Length);

                Instantiate(coin, spawnPoints[spawnID].position, Quaternion.identity);

                coinTime = 0.0f;
            }
        }
    }
}