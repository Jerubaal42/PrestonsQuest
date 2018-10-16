using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 3.0f;
    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (Mathf.Abs(y) < Mathf.Abs(x))
        {
            if (x > 0) { animator.SetTrigger("MoveRight"); }
            if (x < 0) { animator.SetTrigger("MoveLeft"); }
        }
        else
        {
            if (y > 0) { animator.SetTrigger("MoveUp"); }
            if (y < 0) { animator.SetTrigger("MoveDown"); }
        }
        if (x == 0 && y == 0) { animator.SetTrigger("MoveNone"); }
        Vector2 velocity = new Vector2(x, y);
        GetComponent<Rigidbody2D>().velocity = velocity * speed;
    }
}
