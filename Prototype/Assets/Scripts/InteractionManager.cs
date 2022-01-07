using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Player player;
    
    void Start()
    {
        player = GameManager.Instance.player;
    }

    
    void Update()
    {
        
    }
}
