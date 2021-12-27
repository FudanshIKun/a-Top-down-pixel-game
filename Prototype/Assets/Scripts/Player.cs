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
        animator.SetFloat("X", 0);
        animator.SetFloat("Y", -1);
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
        // Reset Player back to Idle
        if (movement.x == 0 && movement.y == 0)
        animator.SetBool("IsMoving", false);

        // Parameter Animation Controller
        if (movement.y == 1 && movement.x == 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", 1);
        }
        else if (movement.y == -1 && movement.x == 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", -1);

        }

        if (movement.x == -1 && movement.y == 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("X", -1);
            animator.SetFloat("Y", 0);

        }
        else if (movement.x == 1 && movement.y == 0)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("X", 1);
            animator.SetFloat("Y", 0);

        }
    }
    
}
