using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour {
    public GameObject player;
    public float chaseSpeed = 1.0f;
    public float chaseTriggerDistance = 10f;
    public float paceSpeed = 0.5f;
    private float speed;
    private float pspeed;
    private Animator animator;
    private Vector2 destination;
    private int waypointMax;
    private int currentWaypoint = 0;
    public Vector3 paceDirection = new Vector3(0f, 0f, 0f);
    public float paceDistance = 2.0f;
    private float time;
    private float time2;
    private float time3;
    private bool hitPlayer = false;
    public bool immobile = false;
    public float trapTime = 5.0f;
    public float pauseTime = 1.0f;
    public float[] x_waypoint;
    public float[] y_waypoint;
    //waypointPause is for the waypoint BEFORE
    public float[] waypointPause;
    private bool destArrive = false;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        destination = new Vector2(x_waypoint[0], y_waypoint[0]);
        waypointMax = x_waypoint.Length - 1;
        speed = chaseSpeed;
        pspeed = paceSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (hitPlayer)
        {
            time += Time.deltaTime;
            if (time >= pauseTime)
            {
                time = 0;
                chaseSpeed = speed;
                hitPlayer = false;
            }
        }
        if (destArrive)
        {
            time2 += Time.deltaTime;
            if (time2 >= waypointPause[currentWaypoint])
            {
                time2 = 0;
                paceSpeed = pspeed;
                destArrive = false;
            }
        }
        if (immobile)
        {
            paceSpeed = 0;
            chaseSpeed = 0;
            time3 += Time.deltaTime;
            if (time3 >= trapTime)
            {
                time3 = 0;
                chaseSpeed = speed;
                paceSpeed = pspeed;
                immobile = false;
            }
        }
        Vector3 playerPosition = player.transform.position;
        Vector2 chaseDirection = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,chaseDirection,10f);
        if (hit.collider.name == "Player")
        {
            chaseDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
            if (Mathf.Abs(chaseDirection.y) < Mathf.Abs(chaseDirection.x))
            {
                if (chaseDirection.x > 0) { animator.SetTrigger("MoveRight"); }
                if (chaseDirection.x < 0) { animator.SetTrigger("MoveLeft"); }
            }
            else
            {
                if (chaseDirection.y > 0) { animator.SetTrigger("MoveUp"); }
                if (chaseDirection.y < 0) { animator.SetTrigger("MoveDown"); }
            }
        } else
        {
            Vector2 destDirection = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
            if(destDirection.magnitude < 0.3f)
            {
                destArrive = true;
                paceSpeed = 0f;
                currentWaypoint++;
                if (currentWaypoint > waypointMax)
                {
                    currentWaypoint = 0;
                }
                destination = new Vector2(x_waypoint[currentWaypoint], y_waypoint[currentWaypoint]);
            }
            destDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = destDirection * paceSpeed;
            if (Mathf.Abs(destDirection.y) < Mathf.Abs(destDirection.x))
            {
                if (destDirection.x > 0) { animator.SetTrigger("MoveRight"); }
                if (destDirection.x < 0) { animator.SetTrigger("MoveLeft"); }
            }
            else
            {
                    if (destDirection.y > 0) { animator.SetTrigger("MoveUp"); }
                if (destDirection.y < 0) { animator.SetTrigger("MoveDown"); }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hitPlayer = true;
            chaseSpeed = chaseSpeed * 0.1f;
        }
    }
}
