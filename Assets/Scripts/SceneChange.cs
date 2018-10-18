using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
    private GameObject player;
    // private PlayerMovement playerMovement;
    private PlayerKey playerKey;
    private GameObject EndSquare;
    private EndSquareDataDump dataDump;
    public Image FadeCanvas;
    private string nextScene;
    private float time;
    private int opacity;
    public bool end = false;
    private bool begin = true;
    private AudioSource music;
    public float fadeTime;
    public bool menu = false;
    private float speed;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        //playerMovement = player.GetComponent<PlayerMovement>();
        playerKey = player.GetComponent<PlayerKey>();
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
                EndSquare = GameObject.Find("InvisibleEndSquare");
                dataDump = EndSquare.GetComponent <EndSquareDataDump>();
                //playerMovement.speed = speed;
                music = Camera.main.GetComponent<AudioSource>();
                music.clip = dataDump.MusicChange;
                music.Play();
                if (playerKey.l_orb && playerKey.m_orb && playerKey.r_orb && (dataDump.HappyChange != ""))
                {
                    SceneManager.LoadScene(dataDump.HappyChange);
                    music.clip = dataDump.HappyMusic;
                    music.Play();
                }
                else if (menu == true) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); menu = false; }
                else { SceneManager.LoadScene(dataDump.SceneChange); }
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
