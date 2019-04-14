using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float time;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene == SceneManager.GetSceneByName("GameScene"))
            time += Time.deltaTime;
    }


    //Restarts the timer when the gameScene is reloaded
    private void OnEnable()
    {
        PlayGame.OnGameStart += RestartTimer;
    }

    private void OnDisable()
    {
        PlayGame.OnGameStart -= RestartTimer;
    }

    public void RestartTimer()
    {
        time = 0;
    }
}
