using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name;
    public bool male, female;
    public bool moveable;


    [Header("Sprites")]
    public SpriteRenderer[] characterSprites;

    [Header("Ground Dectection")]
    private Collider2D lastHit;
    private LevelManager levelManager;
    public Transform rayCastPoint;
    public LayerMask layerMask;


    
    public virtual void setup()
    {
        levelManager = GameManager.Instance.levelmanager;
        //Create Array of All Sprites
        characterSprites = GetComponentsInChildren<SpriteRenderer>();
    }
    protected void tile_detection()
    {
        RaycastHit2D newHit = Physics2D.Raycast(rayCastPoint.position, Vector2.down, 0.05f, layerMask);
        if (lastHit == null && newHit.collider != null)
        {
            lastHit = newHit.collider;
            return;
        }
        if (newHit.collider == null || newHit.collider.name == "BridgeArea")
        {
            return;
        }
        Collider2D currentHit = newHit.collider;
        if (currentHit != lastHit || lastHit == null)
        {
            Debug.Log("now on " + currentHit.name);
            lastHit = currentHit;
            foreach (var item in characterSprites)
            {
                levelManager.checkLevel(lastHit, item);
            }
        }
    }
}
