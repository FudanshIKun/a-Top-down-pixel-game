using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGate : MonoBehaviour
{
    [Header("Gate management")]
    public LevelManager levelmanager;
    public string nextScene;
    public string destinationGate;
    public bool horizontal, vertical;
    public bool integer;
    public bool building, map;
    

    Animator transition;
    Collider2D gate;
    void Start()
    {
        gate = GetComponent<Collider2D>();
        transition = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            if (map)
            {
                if (checkDirection())
                {
                    transition.SetTrigger("Start");
                    levelmanager.checkGate(nextScene, destinationGate);
                    gameObject.SetActive(false);
                }
            }
            if (building)
            {
                if (checkDirection())
                {
                    GameManager.Instance.enterBuilding();
                    if (GameManager.Instance.interacting && (GameManager.Instance.objectType == "enterBuilding"))
                    {
                        transition.SetTrigger("Start");
                        levelmanager.checkGate(nextScene, destinationGate);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    private bool checkDirection()
    {
        if (horizontal)
        {
            if (integer)
            {
                if (GameManager.Instance.player.movement.x == 1)
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
                if (GameManager.Instance.player.movement.x == -1)
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
                if (GameManager.Instance.player.movement.y == 1)
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
                if (GameManager.Instance.player.movement.y == -1)
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
