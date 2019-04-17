using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
   
    //Current Player
    private GameObject playerInstance;
    private GameTimer gt;

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
        gt = GetComponent<GameTimer>();
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

            GUI.Label(new Rect(165, 200, 100, 50), ("Time: " + Math.Round(gt.time, 2)));
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over, Man!");

        }
    }

}
