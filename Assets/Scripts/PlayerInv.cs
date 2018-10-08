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
    private string input;
    // Use this for initialization
    void Start () {
        front_image.sprite = sprites[front_number];
        front_text.text = inventory[front_number].ToString();
        left_number = sprites.Length - 1;
        left_image.sprite = sprites[left_number];
        left_text.text = inventory[left_number].ToString();
        right_image.sprite = sprites[right_number];
        right_text.text = inventory[right_number].ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            front_number++; left_number++; right_number++;
            if (front_number >= sprites.Length) { front_number = 0; }
            if (left_number >= sprites.Length) { left_number = 0; }
            if (right_number >= sprites.Length) { right_number = 0; }
            front_image.sprite = sprites[front_number];
            front_text.text = inventory[front_number].ToString();
            left_image.sprite = sprites[left_number];
            left_text.text = inventory[left_number].ToString();
            right_image.sprite = sprites[right_number];
            right_text.text = inventory[right_number].ToString();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            front_number--; left_number--; right_number--;
            if (front_number < 0) { front_number = sprites.Length-1; }
            if (left_number < 0) { left_number = sprites.Length - 1; }
            if (right_number < 0) { right_number = sprites.Length - 1; }
            front_image.sprite = sprites[front_number];
            front_text.text = inventory[front_number].ToString();
            left_image.sprite = sprites[left_number];
            left_text.text = inventory[left_number].ToString();
            right_image.sprite = sprites[right_number];
            right_text.text = inventory[right_number].ToString();
        }
    }
}
