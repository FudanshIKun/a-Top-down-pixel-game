using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public Player player;
    public Level[] levels;
    
    
    void Start()
    {
        
    }
        
    void Update()
    {

    }
        
    public void checkLevel(Collider2D hit, SpriteRenderer sprite)  
    {       
        for (int i = 0; i < levels.Length; i++)
        {
            if (hit.name == levels[i].name)
            {
                levels[i].toggle_collider(true);
                toggle_layer(9 + (10 * i), sprite);
            }
            else
            {
                levels[i].toggle_collider(false);
            }
        }
    }
    public void toggle_layer(int level, SpriteRenderer sprite)
    {
        sprite.sortingOrder = level;
    }
}