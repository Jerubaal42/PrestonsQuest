using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxes : MonoBehaviour
{
    public Canvas FlyingBirds;
    public Canvas PotSelect;
    private bool talkedToo = false;
    private PauseMenu pause;
    private GameObject player;
    private PlayerKey playerKey;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        pause = player.GetComponent<PauseMenu>();
        playerKey = player.GetComponent<PlayerKey>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnMouseDown()
    {
        if(FlyingBirds.enabled == true)
        {
            if (pause.paused == false) { Time.timeScale = 1; }
            FlyingBirds.enabled = false;
            if (talkedToo == false) { PotSelect.enabled = false; }
        }
        else
        {
            if (pause.paused == false) { Time.timeScale = 0; }
            FlyingBirds.enabled = true;
            if (talkedToo == false) { PotSelect.enabled = true; }
        }
    }

    public void WhitePot() {
        playerKey.bottle = 1; talkedToo = true;
        PotSelect.enabled = false;
        playerKey.potion.sprite = playerKey.potion_sprite[playerKey.bottle];
        if (pause.paused == false) { Time.timeScale = 1; }
        FlyingBirds.enabled = false;
    }
    public void RedPot() {
        playerKey.bottle = 2;
        talkedToo = true; PotSelect.enabled = false;
        playerKey.potion.sprite = playerKey.potion_sprite[playerKey.bottle];
        if (pause.paused == false) { Time.timeScale = 1; }
        FlyingBirds.enabled = false;
    }
    public void GreenPot() {
        playerKey.bottle = 3;
        talkedToo = true; PotSelect.enabled = false;
        playerKey.potion.sprite = playerKey.potion_sprite[playerKey.bottle];
        if (pause.paused == false) { Time.timeScale = 1; }
        FlyingBirds.enabled = false;
    }
}
