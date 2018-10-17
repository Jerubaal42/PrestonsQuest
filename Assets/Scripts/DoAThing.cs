using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAThing : MonoBehaviour {
    public AudioClip soundPlay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(soundPlay);
        }	
	}
}
