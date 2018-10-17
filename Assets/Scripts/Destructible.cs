using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    public int destType;
    private GameObject player;
    private PlayerKey playerKey;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerKey = player.GetComponent<PlayerKey>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerKey.key && destType==0) { Destroy(gameObject); playerKey.key = false; playerKey.images[0].sprite = playerKey.blank; }
            if (playerKey.knife && destType==1) { Destroy(gameObject); }
            if (playerKey.hammer && destType==2) { Destroy(gameObject); }
            if (playerKey.eye && destType==3) { Destroy(gameObject); }
        }
    }
}
