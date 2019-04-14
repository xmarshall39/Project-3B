using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public delegate void GameStart();
    public static event GameStart OnGameStart;

    public void Play()
    {

        //Load the game scene
        SceneManager.LoadScene("GameScene");
        OnGameStart?.Invoke();
         
    }

    //Event Trigger for the beginning of a new game
}
