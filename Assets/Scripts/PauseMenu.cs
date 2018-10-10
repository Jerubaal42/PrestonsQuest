using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    public bool paused = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused) {
                Time.timeScale = 1;
                paused = false;
            } else {
                Time.timeScale = 0;
                paused = true;
            }
        }
	}
}
