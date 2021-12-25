using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapDetection : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            Debug.Log("Raycast is working");
        }
    }
}
