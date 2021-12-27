using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Player management")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    
    private void Start()
    {
        tile_detection_start();
    }


    private void Update()
    {
        player_controller();
        player_animatior();
        tile_detection();
    }
    void player_controller()
    {
        // Reset Vector2
        movement = Vector2.zero;

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        movement.Normalize();
        rb.velocity = movement * moveSpeed;
    }
    void player_animatior()
    {
        // Parameter Animation Controller
        if (Input.GetKey(KeyCode.A) && movement.y == 0)
        {
            animator.Play("A");
        }
        else if (Input.GetKey(KeyCode.D) && movement.y == 0)
        {
            animator.Play("D");
        }
        if (Input.GetKey(KeyCode.S) && movement.x == 0)
        {
            animator.Play("S");
        }
        else if (Input.GetKey(KeyCode.W) && movement.x == 0)
        {
            animator.Play("W");
        }
    }
    
}
