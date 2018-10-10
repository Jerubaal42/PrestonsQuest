using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLife : MonoBehaviour {
    public float lifeTime = 5.0f;
    private float time = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= lifeTime) { Destroy(gameObject); }
	}
}
