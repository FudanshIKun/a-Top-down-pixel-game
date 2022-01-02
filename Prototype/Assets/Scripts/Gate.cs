using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [Header("Gate management")]
    public LevelManager levelmanager;
    public string nextScene;
    public int spawn;
    public Vector2 direction;

    Animator transition;
    void Start()
    {
        transition = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            transition.SetTrigger("Start");
            levelmanager.checkGate(nextScene, spawn, direction);
        }
    }
}
