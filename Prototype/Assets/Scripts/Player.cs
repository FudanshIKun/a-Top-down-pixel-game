using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [Header("Player management")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    
    private void Start()
    {
        tile_detection_start();
    }


    private void Update()
    {
        player_controller();
        player_animator();
        tile_detection();
    }
    void FixedUpdate()
    {
        movement.Normalize();
        rb.MovePosition(rb.position + new Vector2(movement.x, movement.y) * moveSpeed * Time.fixedDeltaTime);
    }
    void player_controller()
    {
        // Reset Vector2
        movement = Vector2.zero;

        // Input
        float x = movement.x = Input.GetAxisRaw("Horizontal");
        float y = movement.y = Input.GetAxisRaw("Vertical");
    }
    void player_animator()
    {
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

}
