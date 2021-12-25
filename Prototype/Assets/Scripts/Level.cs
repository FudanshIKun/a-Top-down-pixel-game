using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level : MonoBehaviour
{
    public TilemapCollider2D bridge;
    public TilemapCollider2D underBridge;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void toggle_collider(bool state)
    {
        if (bridge == null) return;
        bridge.enabled = state;
        underBridge.enabled = !state;
    }
}
