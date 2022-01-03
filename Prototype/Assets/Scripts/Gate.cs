using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [Header("Gate management")]
    public LevelManager levelmanager;
    public string nextScene;
    public string destinationGate;

    

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
            transition.SetTrigger("Start");
            levelmanager.checkGate(nextScene, destinationGate);
            gameObject.SetActive(false);
        }
    }
}
