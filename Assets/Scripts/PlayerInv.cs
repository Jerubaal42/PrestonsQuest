using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInv : MonoBehaviour {
    public Image front_image;
    public Image left_image;
    public Image right_image;
    public Text front_text;
    public Text left_text;
    public Text right_text;
    private int front_number = 0;
    private int left_number = 2;
    private int right_number = 1;
    public Sprite[] sprites;
    public int[] inventory;
    public GameObject[] items;
    private GameObject player;
    private PlayerHealth playerHealth;
    private PauseMenu pause;
    private float time = 0f;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        pause = player.GetComponent<PauseMenu>();
        front_image.sprite = sprites[front_number];
        front_text.text = inventory[front_number].ToString();
        if (inventory[front_number] <= 0) { front_image.GetComponent<Image>().color = new Color32(128, 128, 128, 255); } else { front_image.GetComponent<Image>().color = new Color32(255, 255, 255, 255); }
        left_number = sprites.Length - 1;
        left_image.sprite = sprites[left_number];
        left_text.text = inventory[left_number].ToString();
        if (inventory[left_number] <= 0) { left_image.GetComponent<Image>().color = new Color32(128, 128, 128, 128); } else { left_image.GetComponent<Image>().color = new Color32(255, 255, 255, 128); }
        right_image.sprite = sprites[right_number];
        right_text.text = inventory[right_number].ToString();
        if (inventory[right_number] <= 0) { right_image.GetComponent<Image>().color = new Color32(128, 128, 128, 128); } else { right_image.GetComponent<Image>().color = new Color32(255, 255, 255, 128); }
    }
	
	// Update is called once per frame
	void Update () {
        if (!pause.paused)
        {
            time += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.E))
            {
                front_number++; left_number++; right_number++;
                if (front_number >= sprites.Length) { front_number = 0; }
                if (left_number >= sprites.Length) { left_number = 0; }
                if (right_number >= sprites.Length) { right_number = 0; }
                front_image.sprite = sprites[front_number];
                front_text.text = inventory[front_number].ToString();
                if (inventory[front_number] <= 0) { front_image.GetComponent<Image>().color = new Color32(128, 128, 128, 255); } else { front_image.GetComponent<Image>().color = new Color32(255, 255, 255, 255); }
                left_image.sprite = sprites[left_number];
                left_text.text = inventory[left_number].ToString();
                if (inventory[left_number] <= 0) { left_image.GetComponent<Image>().color = new Color32(128, 128, 128, 128); } else { left_image.GetComponent<Image>().color = new Color32(255, 255, 255, 128); }
                right_image.sprite = sprites[right_number];
                right_text.text = inventory[right_number].ToString();
                if (inventory[right_number] <= 0) { right_image.GetComponent<Image>().color = new Color32(128, 128, 128, 128); } else { right_image.GetComponent<Image>().color = new Color32(255, 255, 255, 128); }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                front_number--; left_number--; right_number--;
                if (front_number < 0) { front_number = sprites.Length - 1; }
                if (left_number < 0) { left_number = sprites.Length - 1; }
                if (right_number < 0) { right_number = sprites.Length - 1; }
                front_image.sprite = sprites[front_number];
                front_text.text = inventory[front_number].ToString();
                if (inventory[front_number] <= 0) { front_image.GetComponent<Image>().color = new Color32(128, 128, 128, 255); } else { front_image.GetComponent<Image>().color = new Color32(255, 255, 255, 255); }
                left_image.sprite = sprites[left_number];
                left_text.text = inventory[left_number].ToString();
                if (inventory[left_number] <= 0) { left_image.GetComponent<Image>().color = new Color32(128, 128, 128, 128); } else { left_image.GetComponent<Image>().color = new Color32(255, 255, 255, 128); }
                right_image.sprite = sprites[right_number];
                right_text.text = inventory[right_number].ToString();
                if (inventory[right_number] <= 0) { right_image.GetComponent<Image>().color = new Color32(128, 128, 128, 128); } else { right_image.GetComponent<Image>().color = new Color32(255, 255, 255, 128); }
            }
            if (Input.GetKeyDown(KeyCode.Space) && inventory[front_number] != 0 && time > 0.1f)
            {
                if ((items[front_number] == null) && (playerHealth.shield < 3))
                {
                    playerHealth.shield++;
                    playerHealth.shield_image.sprite = playerHealth.sprite_shield[playerHealth.shield];
                    inventory[front_number]--;
                    front_text.text = inventory[front_number].ToString();
                    if (inventory[front_number] <= 0) { front_image.GetComponent<Image>().color = new Color32(128, 128, 128, 255); }
                }
                else if (items[front_number] != null)
                {
                    Instantiate(items[front_number], transform.position, Quaternion.identity);
                    inventory[front_number]--;
                    front_text.text = inventory[front_number].ToString();
                    if (inventory[front_number] <= 0) { front_image.GetComponent<Image>().color = new Color32(128, 128, 128, 255); }
                }
                time = 0;
            }
        }
    }
}
