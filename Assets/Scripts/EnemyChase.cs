using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {
    public GameObject player;
    public float chaseSpeed = 1.0f;
    public float chaseTriggerDistance = 10f;
    public float paceSpeed = 0.5f;
    private Vector3 startPosition;
    private bool home = true;
    public Vector3 paceDirection = new Vector3(0f, 0f, 0f);
    public float paceDistance = 2.0f;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPosition = player.transform.position;
        Vector2 chaseDirection = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, chaseDirection, out hit, chaseTriggerDistance))
        {
            Debug.DrawRay(transform.position, chaseDirection * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, chaseDirection * chaseTriggerDistance, Color.black);
        }
    }
}
