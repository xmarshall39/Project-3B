using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
   
    //Current Player
    private GameObject playerInstance;

    public int Lives = 4;

    private float respawn;

    void Spawn()
    {
        Lives--;
        respawn = 1;
        playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if(playerInstance == null && Lives > 0)
        {
            respawn -= Time.deltaTime;

            if(respawn <= 0)
            {
                Spawn();
            }
        }
    }

    void OnGUI()
    {
        if (Lives > 0 || playerInstance != null)
        {
            GUI.Label(new Rect(0, 0, 100, 50), "Lives Left: " + Lives);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over, Man!");

        }
    }

}
