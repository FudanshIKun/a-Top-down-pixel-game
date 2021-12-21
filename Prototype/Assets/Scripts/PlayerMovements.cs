using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private void Start()
    {
        
    }


    private void Update()
    {
        // Reset Vector2
        Vector2 movement = Vector2.zero;

        // Input
        float x = movement.x = Input.GetAxisRaw("Horizontal");
        float y = movement.y = Input.GetAxisRaw("Vertical");

        // Detect direction of animation or sprite
        if (x == -1)
        {
            
        }
        else if (x == 1)
        {
            
        }

        if (y == -1)
        {
            
        }
        else if (y == 1)
        {
            
        }

        movement.Normalize();
        Debug.Log(x);
        Debug.Log(y);
    }
    private void FixedUpdate()
    {
        // Moving
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

    }
}
