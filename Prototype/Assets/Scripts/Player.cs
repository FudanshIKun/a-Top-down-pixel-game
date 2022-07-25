using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Component")]
    public Animator animator;
    public Sprite firstSprite;
    public Vector2 movement;

    [Header("Animation & Interaction")]
    public bool interacting;
    public Transform raycastPoint;
    Vector2 directionalAim;
    public LayerMask interactionLayer;

    [Header("Movement Setting")]
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        Debug.Log("Gag");
    }

    private void Start()
    {
        setup();
    }


    private void Update()
    {
        player_controller();
        setDirection();
        interaction();
        player_animatior();
        tile_detection();
    }
    //Setting Up player at the start of the scene
    public override void setup()
    {
        base.setup();
        rb = GetComponent<Rigidbody2D>();
        interactionLayer = LayerMask.GetMask("sad");
    }
    void player_controller()
    {
        if (interacting)
        {

            return;
        }

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
        if (interacting)
        {

            return;
        }

        // Reset Player back to Idle
        if (movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
        if (Mathf.Abs(movement.x) > 0 && movement.y == 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
        if (Mathf.Abs(movement.y) > 0 && movement.x == 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
    }
    void setDirection()
    {
        if (movement.x == 1 && movement.y == 0) { directionalAim = Vector2.right; }
        if (movement.x == -1 && movement.y == 0) { directionalAim = Vector2.left; }
        if (movement.y == 1 && movement.x == 0) { directionalAim = Vector2.up; }
        if (movement.y == -1 && movement.x == 0) { directionalAim = Vector2.down; }
    }

    void interaction()
    {
        //RaycastHit2D aiming = Physics2D.Raycast(raycastPoint.position, directionalAim, 0.1f, interactionLayer);
        //Debug.Log(aiming.collider.name);
    }
}
