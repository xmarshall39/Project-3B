using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TripleLaserMovement : MonoBehaviour
{
    public float maxSpeed = 5f;

    //Instantiate three lasers
    public GameObject laserPrefab;
    private GameObject[] laserInstances;
    
    

    bool SpawnLasers()
    {
        int rotation = 135;
        foreach(GameObject laser in laserInstances)
        {

            rotation -= 45;
        }

        return true;
    }


    void Update()
    {
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }

}

