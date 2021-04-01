using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnWave : MonoBehaviour
{
    public GameObject enemyObject;
    public Transform spawnPosition;
    public float enemySpawnRate = 1f;
    float spawnCountdown = 0f;


    private void Update()
    {
        if (spawnCountdown <= 0f)
        {
            //spawnEnemy();
            Instantiate(enemyObject, spawnPosition.position, spawnPosition.rotation);
            spawnCountdown = 1f / enemySpawnRate;
        }

        spawnCountdown -= Time.deltaTime;
    }

    void spawnEnemy()
    {
        //Instantiate(enemyObject, spawnPosition.position, spawnPosition.rotation);
    }


}
