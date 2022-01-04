using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [Header("Gate management")]
    public LevelManager levelmanager;
    public string nextScene;
    public string destinationGate;
    public bool horizontal, vertical;
    public bool integer;

    

    Animator transition;
    void Start()
    {
        transition = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            if (checkDirection())
            {
                transition.SetTrigger("Start");
                levelmanager.checkGate(nextScene, destinationGate);
                gameObject.SetActive(false);
            }
        }
    }
    private bool checkDirection()
    {
        if (horizontal)
        {
            if (integer)
            {
                if (GameManager.player.movement.x == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (GameManager.player.movement.x == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else if (vertical)
        {
            if (integer)
            {
                if (GameManager.player.movement.y == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (GameManager.player.movement.y == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        
    }
}
