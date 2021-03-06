﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int health = 3;
    public int shield = 0;
    public int cshield = 0;
    private bool invulnerable = false;
    private float time = 0;
    private float flashTimer = 0;
    public float invulnerableTime = 1;
    public Sprite[] sprite_health;
    public Sprite[] sprite_shield;
    public Sprite[] sprite_cshield;
    public Image health_image;
    public Image shield_image;
    public Image cshield_image;
    private bool gameOver = false;
    public float gameOverTime = 3;
    public float time2 = 0;
    private float speed;
    private static bool created = false;
    private GameObject player;
    private PlayerMovement playerMovement;
    public Image fadeCanvas;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        speed = playerMovement.speed;
        health_image.sprite = sprite_health[health];
        shield_image.sprite = sprite_shield[shield];
        cshield_image.sprite = sprite_cshield[cshield];
    }
    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        } else { Destroy(gameObject); }
    }
    // Update is called once per frame
    void Update () {
        if (gameOver)
        {
            playerMovement.speed = 0;
            time2 += Time.deltaTime;
            var tempColor = fadeCanvas.color;
            tempColor.a = time * (1 / gameOverTime);
            fadeCanvas.color = tempColor;
            if (time2 >= gameOverTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                transform.position = new Vector3(0, 0, 0);
                playerMovement.speed = speed;
                invulnerable = false;
                health = 3;
                health_image.sprite = sprite_health[health];
                gameOver = false;
            }
        }
        if (invulnerable && !gameOver)
        {
            flashTimer += Time.deltaTime;
            if (flashTimer < 0.1f)
            {
                Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
                color.w = 0.8f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            } else if (flashTimer>0.1f && flashTimer < 0.2f)
            {
                Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
                color.w = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
            else
            {
                flashTimer = 0f;
            }
            time += Time.deltaTime;
            if (time >= invulnerableTime)
            {
                Vector4 color = gameObject.GetComponent<SpriteRenderer>().color;
                color.w = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
                invulnerable = false;
                time = 0;
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && invulnerable == false)
        {
            if (cshield > 0)
            {
                cshield--;
                cshield_image.sprite = sprite_cshield[cshield];
            }
            else if (shield > 0)
            {
                shield--;
                shield_image.sprite = sprite_shield[shield];
            }
            else
            {
                health--;
                health_image.sprite = sprite_health[health];
            }
            invulnerable = true;
            if (health <= 0)
            {
                gameOver = true;
            }
        }
    }
}
