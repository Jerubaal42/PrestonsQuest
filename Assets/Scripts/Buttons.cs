using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour { 
    public void StartGame()
    {
        Time.timeScale = 1;
        GameObject player = GameObject.Find("Player");
        SceneChange sceneChange = player.GetComponent<SceneChange>();
        PauseMenu pause = player.GetComponent<PauseMenu>();
        pause.pauseMenu.enabled = false;
        pause.paused = false;
        sceneChange.end = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        GameObject player = GameObject.Find("Player");
        SceneChange sceneChange = player.GetComponent<SceneChange>();
        PauseMenu pause = player.GetComponent<PauseMenu>();
        pause.pauseMenu.enabled = false;
        pause.paused = false;
        sceneChange.menu = true;
        sceneChange.end = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
