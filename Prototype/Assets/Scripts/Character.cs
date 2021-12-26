using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public bool male, female;
    public bool moveable;

    [Header("Ground Dectection")]
    public Collider2D hit;
    public LevelManager levelManager;
    public Transform rayCastPoint;
    public LayerMask layerMask;

    [Header("Layer Sorting")]
    public SpriteRenderer sprite;
    protected void tile_detection_start()
    {
        RaycastHit2D newHit = Physics2D.Raycast(rayCastPoint.position, Vector2.down, 0.05f, layerMask);
        levelManager.checkLevel(hit, sprite);

    }

    protected void tile_detection()
    {
        RaycastHit2D newHit = Physics2D.Raycast(rayCastPoint.position, Vector2.down, 0.05f, layerMask);
        if (newHit.collider == null || newHit.collider.name == "BridgeArea")
        {
            return;
        }
        Collider2D currentHit = newHit.collider;
        if (currentHit != hit)
        {
            Debug.Log("new" + currentHit.name + " " + hit.name);
            hit = currentHit;
            levelManager.checkLevel(hit, sprite);

        }
    }
}
