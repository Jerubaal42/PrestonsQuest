using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public bool paused = false;
    public Canvas pauseMenu;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (paused)
        {
            pauseMenu.enabled = false;
            Time.timeScale = 1;
            paused = false;
        }
        else
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            paused = true;
        }
    }
}
