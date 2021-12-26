using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Collider2D hit;
    [Header("GroundDectection")]
    public Transform rayCastPoint;
    public LayerMask layerMask;
    private void Start()
    {
        
    }


    private void Update()
    {
        Movement();
        tile_detection();
    }
    void FixedUpdate()
    {

    }
    void Movement()
    {
        // Reset Vector2
        Vector2 movement = Vector2.zero;

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


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
        movement.Normalize();
        rb.velocity = movement * moveSpeed;
    }
    void tile_detection_start()
    {
        RaycastHit2D newHit = Physics2D.Raycast(rayCastPoint.position, Vector2.down, 0.05f, layerMask);
    }
    void tile_detection()
    {
        RaycastHit2D newHit = Physics2D.Raycast(rayCastPoint.position, Vector2.down, 0.05f, layerMask);
        if(newHit.collider == null || newHit.collider.name == "BridgeArea" )
        {
            return;
        }
        Collider2D currentHit = newHit.collider;
        if (currentHit != hit)
        {
            Debug.Log("new" + currentHit.name + " " + hit.name);
            hit = currentHit;

        } 
    }
}
