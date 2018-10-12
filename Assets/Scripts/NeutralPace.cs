using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralPace : MonoBehaviour
{
    public float paceSpeed = 0.5f;
    private float pspeed;
    private Animator animator;
    private Vector2 destination;
    private int waypointMax;
    private int currentWaypoint = 0;
    public Vector3 paceDirection = new Vector3(0f, 0f, 0f);
    public float paceDistance = 2.0f;
    private float time2;
    private float time3;
    public bool immobile = false;
    public float trapTime = 5.0f;
    public float pauseTime = 1.0f;
    public float[] x_waypoint;
    public float[] y_waypoint;
    //waypointPause is pause time for waypoint BEFORE listed point
    public float[] waypointPause;
    private bool destArrive = false;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        destination = new Vector2(x_waypoint[0], y_waypoint[0]);
        waypointMax = x_waypoint.Length - 1;
        pspeed = paceSpeed;
    }

    // Update is called once per frame
    void Update()
    {
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
            time3 += Time.deltaTime;
            if (time3 >= trapTime)
            {
                time3 = 0;
                paceSpeed = pspeed;
                immobile = false;
            }
        }
        Vector2 destDirection = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        if (destDirection.magnitude < 0.3f)
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
        if (paceSpeed == 0) { animator.SetTrigger("MoveNone"); }
        else if (Mathf.Abs(destDirection.y) < Mathf.Abs(destDirection.x))
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
