using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
   // private GameObject player;
   // private PlayerMovement playerMovement;
    public Image FadeCanvas;
    public string nextScene;
    private float time;
    private int opacity;
    private bool end = false;
    private bool begin = true;
    public float fadeTime;
    private float speed;
	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player");
        //playerMovement = player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (end)
        {
            time += Time.deltaTime;
            var tempColor = FadeCanvas.color;
            tempColor.a = time * (1/fadeTime);
            FadeCanvas.color = tempColor;
            if (time >= fadeTime)
            {
                end = false;
                //playerMovement.speed = speed;
                SceneManager.LoadScene(nextScene);
                begin = true;
                transform.position = new Vector3 (0, 0, 0);
            }
        }
        if (begin)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                begin = false;
            }
            var tempColor = FadeCanvas.color;
            tempColor.a = time * (1 / fadeTime);
            FadeCanvas.color = tempColor;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            //speed = playerMovement.speed;
            time = 0;
            //playerMovement.speed = 0;
            end = true;
        }
    }
}
