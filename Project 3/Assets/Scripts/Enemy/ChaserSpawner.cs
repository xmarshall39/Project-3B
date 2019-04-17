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
        nextEnemy -= Time.deltaTime;

        if(nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            
            //Makes a random vector
            Vector3 offset = Random.onUnitSphere;
            offset.z = 0;
            
            //Spawn the enemy somewhere offscreen
            offset = offset.normalized * spawnDistance;

            GameObject enemy = Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
            
            //Want Turrets to move to a random spot on the screen from offscreen
            if(enemy.name == "Turret(Clone)")
            {
                Vector3 movePos = Random.onUnitSphere * Random.Range(-1, 1);
                print("should be moving");
                enemy.transform.position = Vector3.MoveTowards
                    (enemy.transform.position, movePos, turretSpeed *Time.deltaTime);
                
            }
            //Spawn more enemies over time
            enemyRate *= .95f;
        }
    }


}
