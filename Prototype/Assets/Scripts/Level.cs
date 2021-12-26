using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Level : MonoBehaviour
{
    public TilemapCollider2D bridge;
    public TilemapCollider2D underBridge;

    public void toggle_collider(bool state)
    {
        Debug.Log(gameObject.name + " " + state);
        if (bridge == null) return;
        bridge.enabled = state;
        underBridge.enabled = !state;
    }
}
