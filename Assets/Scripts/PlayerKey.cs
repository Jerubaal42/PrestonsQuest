using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKey : MonoBehaviour {
    public bool key = false;
    public bool knife = false;
    public bool hammer = false;
    public int bottle = 0;
    public bool eye = false;
    public bool r_orb = false;
    public bool m_orb = false;
    public bool l_orb = false;
    public Image[] images;
    public Sprite[] sprites;
    public Sprite blank;
    public Image potion;
    public Sprite[] potion_sprite;
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMove;
    private PauseMenu pause;
    private float time = 0;
    private float time2 = 0;
    public float potion_duration = 60f;
    private bool inv_active = false;
    private bool spd_active = false;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMove = player.GetComponent<PlayerMovement>();
        pause = player.GetComponent<PauseMenu>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && bottle!=0 && !pause.paused)
        {
            if (bottle==1 && inv_active==false)
            {
                inv_active = true;
                playerHealth.invulnerableTime += 2;
                bottle = 0;
            }
            if(bottle==2 && playerHealth.health<3)
            {
                playerHealth.health = 3;
                playerHealth.health_image.sprite = playerHealth.sprite_health[playerHealth.health];
                bottle = 0;
            }
            if(bottle==3 && spd_active==false)
            {
                spd_active = true;
                playerMove.speed += 2;
                bottle = 0;
            }
            if(bottle>3 || bottle < 0) { bottle = 0; }
            potion.sprite = potion_sprite[bottle];
        }
        if (inv_active)
        {
            time += Time.deltaTime;
            if (time >= potion_duration)
            {
                playerHealth.invulnerableTime -= 2;
                inv_active = false;
            }
        }
        if (spd_active)
        {
            time2 += Time.deltaTime;
            if (time2 >= potion_duration)
            {
                playerMove.speed -= 2;
                spd_active = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            if (collision.gameObject.name == "Key" && key == false) { key = true; images[0].sprite = sprites[0]; Destroy(collision.gameObject); }
            if(collision.gameObject.name == "Knife") { knife = true; images[1].sprite = sprites[1]; Destroy(collision.gameObject); }
            if (collision.gameObject.name == "Hammer") { hammer = true; images[2].sprite = sprites[2]; Destroy(collision.gameObject); }
            if (collision.gameObject.name == "Eye") { eye = true; images[3].sprite = sprites[3]; Destroy(collision.gameObject); }
            if (collision.gameObject.name == "R_Orb") { r_orb = true; images[4].sprite = sprites[4]; Destroy(collision.gameObject); }
            if (collision.gameObject.name == "L_Orb") { l_orb = true; images[5].sprite = sprites[5]; Destroy(collision.gameObject); }
            if (collision.gameObject.name == "M_Orb") { m_orb = true; images[6].sprite = sprites[6]; Destroy(collision.gameObject); }
        }
    }
}
