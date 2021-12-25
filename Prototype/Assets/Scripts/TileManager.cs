using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Player player;
    public Level[] levels;
    
    
    void Start()
    {
        
    }
        
    void Update()
    {

    }
        
    public void checkLevel(Collider2D hit)  
    {
        
        for (int i = 0; i < levels.Length; i++)
        {
            if (hit.name == levels[i].name)
            {
                levels[i].toggle_collider(true);
            }
            else
            {
                levels[i].toggle_collider(false);
            }
        }
    }
    
}