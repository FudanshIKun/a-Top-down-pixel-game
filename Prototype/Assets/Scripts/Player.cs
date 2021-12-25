using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public TileManager tilemanager;
    public Collider2D hit;
    public LayerMask mask;
    private void Start()
    {
        
    }


    private void Update()
    {
        Movement();
        tile_Detection();
    }
    void FixedUpdate()
    {
        movement.Normalize();

        // Moving
        rb.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }
    void Movement()
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
    void tile_Detection()
    {
        Collider2D current;
        current = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.down, 1.0f, mask).collider ;
        if (hit.name != current.name)
        {
            hit = current;
            tilemanager.checkLevel(hit);
            Debug.Log(hit.name);
        }
    }
}
