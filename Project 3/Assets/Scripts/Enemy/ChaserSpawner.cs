using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float spawnDistance = 20f;
    public float enemyRate = 10;
    public float turretSpeed = 3.5f;

    float nextEnemy = 1;


    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player(Clone)");
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0 && Player)
        {
            nextEnemy = enemyRate;
            
            //Makes a random vector
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            
            //Spawn the enemy somewhere offscreen
            offset = offset.normalized * spawnDistance;

            GameObject enemy = Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
            
            
            //Spawn more enemies over time
            enemyRate *= .95f;
        }
    }


}
