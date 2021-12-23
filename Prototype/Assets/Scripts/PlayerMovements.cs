using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    private void Start()
    {
        
    }


    private void Update()
    {
        // Reset Vector2
        movement = Vector2.zero;

        // Input
        float x = movement.x = Input.GetAxisRaw("Horizontal");
        float y = movement.y = Input.GetAxisRaw("Vertical");
        
        // Parameter Animation Controller
        if (Input.GetKey(KeyCode.A) && movement.y == 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (Input.GetKey(KeyCode.D) && movement.y == 0)
        {
            animator.SetInteger("Direction", 3);
        }

        if (Input.GetKey(KeyCode.S) && movement.x == 0)
        {
            animator.SetInteger("Direction", 0);
        }
        else if (Input.GetKey(KeyCode.W) && movement.x == 0)
        {
            animator.SetInteger("Direction", 1);
        }
    }
    void FixedUpdate()
    {
        // Turn Vector2 to direction
        movement.Normalize();
        //Debug.Log(movement.x);
        //Debug.Log(movement.y);

        // Moving
        rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }
}
