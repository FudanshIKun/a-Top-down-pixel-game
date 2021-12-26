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
        movement = Vector2.zero;

        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

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
        movement.Normalize();
        rb.velocity = movement * moveSpeed;
    }
    void tile_detection_start()
    {
        RaycastHit2D newHit = Physics2D.Raycast(rayCastPoint.position, Vector2.down, 0.05f, layerMask);
        tilemanager.checkLevel(hit);
    }
    void tile_detection() // เช็คว่า player อยู่บน tile อะไร และส่งค่า Collider ที่พบให้กับ Script ที่ต้องการ
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
            tilemanager.checkLevel(hit);

        } 
    }
}
