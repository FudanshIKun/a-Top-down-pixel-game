using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detect_ground();
    }
    void detect_ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.Log(hit.transform.name);
    }
}
