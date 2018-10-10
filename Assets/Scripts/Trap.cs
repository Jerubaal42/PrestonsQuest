using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = GameObject.Find(collision.gameObject.name);
            EnemyChase script = enemy.GetComponent<EnemyChase>();
            script.immobile = true;
            Destroy(gameObject);
        }
    }
}
