using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Component")]
    public Animator animator;
    public Sprite firstSprite;
    public Vector2 movement;

    [Header("Animation")]
    public bool playerInStopMode;
    public Transform raycastPoint;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Awake()
    {
        
    }

    private void Start()
    {
        setup();
    }


    private void Update()
    {
        player_controller();
        player_animatior();
        tile_detection();
    }
    //Setting Up player at the start of the scene
    public override void setup()
    {
        base.setup();
        rb = GetComponent<Rigidbody2D>();
    }
    void player_controller()
    {
        if (playerInStopMode)
        {
            interact();
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
        if (playerInStopMode)
        {
            interact();
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
    void interact()
    {
        /*
        if (GameManager.Instance.interacting)
        {
            if (GameManager.Instance.objectType == "enterBuilding")
            {
                movement = new Vector2(0, 0);
            }
        }
        return;*/
    }
}
